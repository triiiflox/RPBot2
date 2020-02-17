﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot.Modules
{
    public class ResponseModule : ModuleBase<SocketCommandContext>
    {
        [Command("respond")]
        public Task Respond(params string[] response)
        {
            if (Context.IsPrivate)
            {
                var Season = Properties.Settings.Default.Season;
                var Episode = Properties.Settings.Default.Episode;

                if (string.Join(" ", response).Contains(","))
                {
                    return ReplyAsync(
                            $"At this point you cant use a comma in your response.\n" +
                            $"This is because this bot stores your response in a format where commas make everything wierd.\n" +
                            $"sorry for this, **you can use ; instead.**");
                }

                if (!Directory.Exists($"Resources/MEAT S{Season}"))
                {
                    Directory.CreateDirectory($"Resources/MEAT S{Season}");
                }

                if (!File.Exists($"Resources/MEAT S{Season}/S{Season}E{Episode} - Responses.csv"))
                {
                    var Firstline = new StringBuilder();
                    Firstline.Append("DateTime");
                    Firstline.Append(",UserName");
                    Firstline.Append(",UserID");
                    Firstline.Append(",Response");
                    Firstline.Append(",Word count");

                    File.AppendAllText($"Resources/MEAT S{Season}/S{Season}E{Episode} - Responses.csv", Firstline.ToString() + "\n");
                }

                var csv = new StringBuilder();
                csv.Append(DateTime.Now);
                csv.Append(",").Append(Context.User.Username);
                csv.Append(",#").Append(Context.User.Discriminator);
                csv.Append(",").Append(string.Join(" ", response));
                csv.Append(",").Append(response.Length);

                File.AppendAllText($"Resources/MEAT S{Season}/S{Season}E{Episode} - Responses.csv", csv.ToString() + "\n");

                return ReplyAsync(
                    $"Thanks {Context.User.Username}, your response:\n" +
                    $"{string.Join(" ", response)}\n" +
                    $"has been **recorded** :thumbsup:");
            }
            else
            {
                Context.Message.DeleteAsync();
                return ReplyAsync(
                    $"Please send me your response in a Private/Direct Message.");
            }
        }
    }
}