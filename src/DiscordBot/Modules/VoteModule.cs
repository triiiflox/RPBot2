using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot.Modules
{
    public class VoteModule : ModuleBase<SocketCommandContext>
    {
        [Command("vote")]
        public Task Vote(params string[] response)
        {
            if (this.Context.IsPrivate)
            {
                Regex rx = new Regex(@"[[]{1}[A-Z]{3,} [A-Z]{10}]");

                string input = string.Join(" ", response);
                if (!rx.IsMatch(input))
                {
                    return ReplyAsync(
                            $"Your vote has **not** been exepted.\n" +
                            $"Please check if you used the right format [KEYWORD ABCDEFGHIJ].\n" +
                            $"If your vote was correctly formatted and it you still get this message, please send the vote directly to @Meatyflesh#2138 .");
                }

                if (!Directory.Exists($"/MEAT S{Resources.Variables.Season}"))
                {
                    Directory.CreateDirectory($"/MEAT S{Resources.Variables.Season}");
                }

                if (!File.Exists($"/MEAT S{Resources.Variables.Season}/" + $"S{Resources.Variables.Season}E{Resources.Variables.Round} - Votes.csv"))
                {
                    var Firstline = new StringBuilder();
                    Firstline.Append("DateTime");
                    Firstline.Append(",UserName");
                    Firstline.Append(",UserID");
                    Firstline.Append(",Keyword");
                    Firstline.Append(",1");
                    Firstline.Append(",2");
                    Firstline.Append(",3");
                    Firstline.Append(",4");
                    Firstline.Append(",5");
                    Firstline.Append(",6");
                    Firstline.Append(",7");
                    Firstline.Append(",8");
                    Firstline.Append(",9");
                    Firstline.Append(",10");

                    File.AppendAllText($"/MEAT S{Resources.Variables.Season}/" + $"S{Resources.Variables.Season}E{Resources.Variables.Round} - Votes.csv", Firstline.ToString() + "\n");
                }

                var csv = new StringBuilder();
                csv.Append(DateTime.Now);
                csv.Append("," + this.Context.User.Username);
                csv.Append(",#" + this.Context.User.Discriminator);

                var RawVote = string.Join(" ", response);
                Regex vrx = new Regex(@"[[]{1}([A-Z]{3,}) ([A-Z]{10})]");
                var vote = vrx.Split(RawVote);
                csv.Append("," + vote[1]);
                foreach (var V in vote[2])
                {
                    csv.Append("," + V);
                }

                File.AppendAllText($"/MEAT S{Resources.Variables.Season}/" + $"S{Resources.Variables.Season}E{Resources.Variables.Round} - Votes.csv", csv.ToString() + "\n");

                return ReplyAsync(
                    $"Thanks {this.Context.User.Username}, your Vote:\n" +
                    $"{string.Join(" ", response)}\n" +
                    $"has been **recorded** :thumbsup:");
            }
            else
            {
                this.Context.Message.DeleteAsync();
                return ReplyAsync(
                    $"Please send me your Vote in a Private/Direct Message.");
            }
        }
    }
}