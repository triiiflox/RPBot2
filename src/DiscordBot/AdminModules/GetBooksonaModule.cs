using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace DiscordBot.AdminModules
{
    public class GetBooksonaModule : ModuleBase<SocketCommandContext>
    {
        [Command("getBooksonas")]
        public Task GetBooksonas()
        {
            string folder = "Booksonas/";
            string output = "Booksonas.zip";

            if (CheckRole.CheckUserRole(Context.User as SocketGuildUser))
            {
                ZipFile.CreateFromDirectory(folder, output);
                Context.Channel.SendFileAsync(output, "Here are all booksonas.").GetAwaiter().GetResult();
                File.Delete(output);
                return ReplyAsync("Here you go, all the booksonas currently stored here.");
            }
            else
            {
                return ReplyAsync("You do not have the permission to do that.");
            }
        }
    }
}