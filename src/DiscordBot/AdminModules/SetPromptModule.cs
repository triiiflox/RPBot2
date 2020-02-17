using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.AdminModules
{
    public class SetPromptModule : ModuleBase<SocketCommandContext>
    {
        [Command("setPrompt")]
        public Task SetPrompt(params string[] prompt)
        {
            if (CheckRole.CheckUserRole(Context.User as SocketGuildUser))
            {
                Properties.Settings.Default.Prompt = string.Join(" ", prompt);

                return ReplyAsync(
                    $"Succes!\n" +
                    $"Current Prompt is: **{Properties.Settings.Default.Prompt}**");
            }
            else
            {
                return ReplyAsync($"Failed, you do not have permission to do that.");
            }
        }
    }
}