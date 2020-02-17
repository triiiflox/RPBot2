using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Resources
{
    public class BotConfig
    {
        public string Prefix { get; set; }
        public string Token { get; set; }
        public List<string> SafeRoles { get; set; }
    }

    public class TwowConfig
    {
        public string Season { get; set; }
        public string Episode { get; set; }
    }
}