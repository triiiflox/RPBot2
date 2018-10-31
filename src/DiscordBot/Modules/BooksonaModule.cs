using System;
using System.Net;
using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot.Modules
{
    public class BooksonaModule : ModuleBase<SocketCommandContext>
    {
        [Command("booksona")]
        public Task Booksona(string url)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(url, @"/Booksonas/" + Context.User.Username + ".png");
                }
                return ReplyAsync("Allright, your booksona is now: " + url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ReplyAsync($"That did not work, please send me the direct url of the picture.\n" +
                    $"You can do this with imgur.com for example.");
            }
        }
    }
}