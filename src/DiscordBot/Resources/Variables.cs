using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DiscordBot.Resources
{
    internal static class Variables
    {
        public static readonly long BotChannel = 503905356733480960;

        public static int Season { get; set; } = 1;
        public static int Round { get; set; } = 1;
        public static string Host { get; set; } = "Meatyflesh";
        public static string Prompt { get; set; } = "Not yet implemented";
        public static string RunDir { get; } = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    }
}