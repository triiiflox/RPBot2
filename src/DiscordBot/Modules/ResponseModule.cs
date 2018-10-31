using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot.Modules
{
    public class ResponseModule : ModuleBase<SocketCommandContext>
    {
        [Command("respond")]
        public Task Respond(params string[] response)
        {
            if (this.Context.IsPrivate)
            {
                if (string.Join(" ", response).Contains(","))
                {
                    return ReplyAsync(
                            $"At this point you cant use a comma in your response.\n" +
                            $"This is because this bot stores your response in a format where commas make everything wierd.\n" +
                            $"sorry for this, **you can use ; instead.**");
                }

                if (!Directory.Exists($"/MEAT S{Resources.Variables.Season}"))
                {
                    Directory.CreateDirectory($"/MEAT S{Resources.Variables.Season}");
                }

                if (!File.Exists($"/MEAT S{Resources.Variables.Season}/" + $"S{Resources.Variables.Season}E{Resources.Variables.Round} - Responses.csv"))
                {
                    var Firstline = new StringBuilder();
                    Firstline.Append("DateTime");
                    Firstline.Append(",UserName");
                    Firstline.Append(",UserID");
                    Firstline.Append(",Response");
                    Firstline.Append(",Word count");

                    File.AppendAllText($"/MEAT S{Resources.Variables.Season}/" + $"S{Resources.Variables.Season}E{Resources.Variables.Round} - Responses.csv", Firstline.ToString() + "\n");
                }

                var csv = new StringBuilder();
                csv.Append(DateTime.Now);
                csv.Append("," + this.Context.User.Username);
                csv.Append(",#" + this.Context.User.Discriminator);
                csv.Append("," + string.Join(" ", response));
                csv.Append("," + response.Length);

                File.AppendAllText($"/MEAT S{Resources.Variables.Season}/" + $"S{Resources.Variables.Season}E{Resources.Variables.Round} - Responses.csv", csv.ToString() + "\n");

                return ReplyAsync(
                    $"Thanks {this.Context.User.Username}, your response:\n" +
                    $"{string.Join(" ", response)}\n" +
                    $"has been **recorded** :thumbsup:");
            }
            else
            {
                this.Context.Message.DeleteAsync();
                return ReplyAsync(
                    $"Please send me your response in a Private/Direct Message.");
            }
        }
    }
}