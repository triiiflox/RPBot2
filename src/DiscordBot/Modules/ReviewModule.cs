using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordBot.Modules
{
    public class ReviewModule : ModuleBase<SocketCommandContext>
    {
        [Command("review")]
        public Task Review()
        {
            var user = Context.User;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Reviewer");
            (user as IGuildUser).AddRoleAsync(role).GetAwaiter().GetResult();

            return ReplyAsync($"Thanks *{Context.User.Username}* for assisting the reviewers.");
        }
    }
}