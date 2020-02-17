using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.AdminModules
{
    public class NextEpModule : ModuleBase<SocketCommandContext>
    {
        [Command("nextEp")]
        public Task NextEp()
        {
            if (CheckRole.CheckUserRole(Context.User as SocketGuildUser))
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Episode++;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();

                return base.ReplyAsync($"Allright, we are now on {Properties.Settings.Default.Season}:{Properties.Settings.Default.Episode}");
            }
            else
            {
                return ReplyAsync("Sorry, you do not have permission to do that.");
            }
        }
    }
}