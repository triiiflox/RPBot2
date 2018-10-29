using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.AdminModules
{
    public class GetResponsesModule : ModuleBase<SocketCommandContext>
    {
        [Command("getResponses")]
        public Task GetResponses(int S, int E)
        {
            if (!File.Exists(@"D:\Projects\TWOW\MEATWOW\Botout\" + $"S{S}E{E} - Responses.csv"))
            {
                return ReplyAsync($"Failed,That Season or Episode does not exist yet.");
            }

            if (CheckRole.CheckUserRole(Context.User as SocketGuildUser))
            {
                return Context.Channel.SendFileAsync(@"D:\Projects\TWOW\MEATWOW\Botout\" + $"S{S}E{E} - Responses.csv", "Here ya go");
            }
            else
            {
                return ReplyAsync($"Failed, you do not have permission to do that.");
            }
        }
    }
}