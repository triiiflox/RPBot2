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
            if (!File.Exists($"Resources/MEAT S{Resources.Variables.Season}/S{S}E{E} - Responses.csv"))
            {
                return ReplyAsync($"Failed,That Season or Episode does not exist yet.");
            }

            return CheckRole.CheckUserRole(Context.User as SocketGuildUser)
                ? Context.Channel.SendFileAsync($"Resources/MEAT S{Resources.Variables.Season}/S{S}E{E} - Responses.csv", "Here ya go")
                : (Task)ReplyAsync($"Failed, you do not have permission to do that.");
        }
    }
}