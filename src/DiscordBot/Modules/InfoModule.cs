using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("info")]
        public Task Info()
            => ReplyAsync(
                $"Hello, I am a bot called {Context.Client.CurrentUser.Username} written in Discord.Net 1.0\n" +
                $"I'll be here to help papi meatyflesh with his MEAT.\n" +
                $"**when I'm online, meatyflesh is testing me.**");
    }
}