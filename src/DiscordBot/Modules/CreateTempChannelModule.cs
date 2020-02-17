using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace DiscordBot.Modules
{
    public class CreateTempChannelModule : ModuleBase<SocketCommandContext>
    {
        [Command("CreateChannel")]
        public Task CreateTempChannel(string name)
        {
            SocketGuild guild = Context.Guild;
            guild.CreateVoiceChannelAsync(name);
            SocketGuildChannel channel = Context.Guild.VoiceChannels.FirstOrDefault(x => x.Name == name);
            ReplyAsync($"Channel {name} has been created.");
            while (true)
            {
                Task.Delay(TimeSpan.FromMinutes(5));
                if (Context.User.Status == Discord.UserStatus.Offline && channel.Users.Count() <= 0)
                {
                    channel.DeleteAsync();
                    break;
                }
            }
            return ReplyAsync($"Channel {name} has been removed due to inactivity.");
        }
    }
}