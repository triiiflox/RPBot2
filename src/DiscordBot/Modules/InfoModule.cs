using System.Linq;
using System.Threading.Tasks;
using Discord;
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
                $"**I will be offline sometimes till I get my owne host.**");
    }
}