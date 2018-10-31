using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace DiscordBot.AdminModules
{
    internal static class CheckRole
    {
        internal static bool CheckUserRole(SocketGuildUser user, string roleName = "The Director")
        {
            var role = (user as IGuildUser)?.Guild.Roles.FirstOrDefault(x => x.Name == roleName);
            return user.Roles.Contains(role);
        }
    }
}