using System;
using System.Threading.Tasks;
using System.Timers;
using Discord.Commands;

namespace DiscordBot.AdminModules
{
    public class TimerModule : ModuleBase<SocketCommandContext>
    {
        [Command("timer")]
        public Task Info(int repeating, int time, string msg)
        {
            if (!CheckRole.CheckUserRole(Context.User as Discord.WebSocket.SocketGuildUser))
            {
                return ReplyAsync($"You no not have the required permission.");
            }
            else
            {
                for (int i = 0; i < repeating + 1; i++)
                {
                    if (time < 120 || i == 1)
                    {
                        break;
                    }

                    Task.Delay(TimeSpan.FromSeconds(time));

                    ReplyAsync("msg");
                }
                return ReplyAsync("msg");
            }
        }
    }
}