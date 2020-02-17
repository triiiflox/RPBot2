using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot.Modules
{
    public class PromptModule : ModuleBase<SocketCommandContext>
    {
        [Command("prompt")]
        public Task Prompt()
            => ReplyAsync(
                $"The current prompt is: **{Properties.Settings.Default.Prompt}**");
    }
}