using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Modules
{
    public class RoleGiverModule : ModuleBase<SocketCommandContext>
    {
        [Command("GetRole")]
        public void GetRole(string role = null)
        {
            //var Safe_Roles = new Program().Configuration["BotConfig:safeRoles"];

            //if (role == null)
            //{
            //    return ReplyAsync("Use as GetRole <role>, Select one of these: /n"
            //                + Safe_Roles);
            //}

            //SocketGuildUser user = (SocketGuildUser)Context.User;
            //List<IRole> ServerRoles = AdminModules.CheckRole.GetServerRoles(Context.Guild);
            //IRole Role = null;
            //try
            //{
            //    Role = ServerRoles.Find(x => x.Name == role);
            //}
            //catch
            //{
            //    return ReplyAsync("The role " + role + " Doesn't exist.");
            //}

            //if (AdminModules.CheckRole.CheckUserRole(user, role))
            //{
            //    return ReplyAsync("You already have the role " + role + " you silly.");
            //}

            //user.AddRoleAsync(Role);
            //return ReplyAsync($"Well then {user.Nickname} I've given you the role {role}.");
        }
    }
}