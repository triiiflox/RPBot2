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
        /// <summary>
        /// Check User Role
        /// </summary>
        /// <param name="user">SocketGuildUser too check</param>
        /// <param name="roleName">Role, Default = "The Director"</param>
        /// <returns>True if user has role</returns>
        internal static bool CheckUserRole(SocketGuildUser user, string roleName = "The Director")
        {
            IRole role = (user as IGuildUser)?.Guild.Roles.FirstOrDefault(x => x.Name == roleName);
            return user.Roles.Contains(role);
        }

        /// <summary>
        /// Get all Roles of User
        /// </summary>
        /// <param name="user">SocketGuildUser to get Roles from</param>
        /// <returns>List<IRole> of SocketGuildUser</returns>
        internal static List<IRole> GetUserRoles(SocketGuildUser user)
        {
            List<IRole> roles = (user as IGuildUser)?.Guild.Roles.ToList();
            return roles;
        }

        /// <summary>
        /// Get all Roles on the Guild
        /// </summary>
        /// <param name="guild">SocketGuild to get roles from</param>
        /// <returns>List<IRole> of SocketGuild</returns>
        internal static List<IRole> GetServerRoles(SocketGuild guild)
        {
            List<IRole> roles = (guild as IGuild)?.Roles.ToList();
            return roles;
        }
    }
}