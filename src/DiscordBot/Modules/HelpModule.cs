using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot.Modules
{
    public class HelpModule : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public Task Info()
            => ReplyAsync(
                $"```\n" +
                $"info - Display some information about this bot.\n" +
                $"help - Display this message.\n" +
                $"Prompt - Display the current Prompt.\n" +
                $"Respond - SEND THIS IN A DM - Respond to the prompt.\n" +
                $"tr_me [optional opacity 0-100] - get a new tr_endy profile picture\n" +
                $"```");
    }
}