using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordBot.Modules
{
    public class InterestedModule : ModuleBase<SocketCommandContext>
    {
        [Command("interested")]
        public Task Interested()
        {
            var user = Context.User;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Virtual");
            (user as IGuildUser).AddRoleAsync(role).GetAwaiter().GetResult();

            return ReplyAsync($"Thanks *{Context.User.Username}* for having an interest in me :blush:");
        }
    }
}