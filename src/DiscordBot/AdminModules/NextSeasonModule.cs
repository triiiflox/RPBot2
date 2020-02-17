using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.AdminModules
{
    public class NextSeasonModule : ModuleBase<SocketCommandContext>
    {
        [Command("nextSeason")]
        public Task NextSeason()
        {
            if (CheckRole.CheckUserRole(Context.User as SocketGuildUser))
            {
                var Settings = Properties.Settings.Default;

                Settings.Season++;
                Settings.Episode = 1;
                Settings.Upgrade();

                return ReplyAsync($"Allright, we are now on {Settings.Season}:{Settings.Episode}");
            }
            else
            {
                return ReplyAsync("Sorry, you do not have permission to do that.");
            }
        }
    }
}