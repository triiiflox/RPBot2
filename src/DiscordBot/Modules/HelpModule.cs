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
                $"~~~~ TWOW STUFF ~~~~\n" +
                $"prompt - Display the current Prompt.\n" +
                $"respond - SEND THIS IN A DM - Respond to the prompt.\n" +
                $"vote - SEND THIS IN A DM - Vote on a voting screen\n" +
                $"~~~~ NOT TWOW STUFF ~~~~\n" +
                $"interested - Gives you the Virtual role, use if interested in RPBot updates\n" +
                $"review - Gives you the Reviewer role, use if interested in revieuweing responses.\n" +
                $"booksona [URL] - Changes your booksona to the given URL.\n" +
                $"tr_me [optional opacity 0-100] - get a new tr_endy profile picture\n" +
                $"```");
    }
}