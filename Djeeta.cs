using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace Djeeta_Bot
{
    class Djeeta
    {
        public Djeeta()
        {
            Start();
        }

        public static void Start()
        {
            DiscordClient client = new DiscordClient(g =>
            {
                g.AppName = "Djeeta";
                g.LogHandler = LogHandler;
            });

            client.UsingCommands(g =>
            {

                g.PrefixChar = '~';
                g.HelpMode = HelpMode.Public;

            });

            CommandService servcomm = client.GetService<CommandService>();

            servcomm.CreateCommand("Hello")
                .Alias(new string[] { "Hi", "Greetings", "Salutations"})
                .Description("Says hi to the person")
                .Do(async (e) =>
                {
                    string username = e.Message.User.ToString().Split('#')[0];
                    if (username == "Dorothinquisition")
                        await e.Channel.SendMessage("Hi Honey *hugs*");
                    else
                        await e.Channel.SendMessage("Hello " + username);

                });

            servcomm.CreateCommand("Shank")
                .Alias(new string[] { "Stab", "Poke"})
                .Description("Shanks person")
                .Parameter("Target", ParameterType.Optional)
                .Do(async (e) =>
                {
                    if (e.GetArg("Target") != "")
                        await e.Channel.SendMessage($"*Shanks* " + e.GetArg("Target"));
                    else
                        await e.Channel.SendMessage("*Shanks* " + e.User.Name);
                });

            servcomm.CreateCommand("RIP")
                .Description("The journey of Draws")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("https://lh3.googleusercontent.com/-Bb3i0I1vI5Q/WN6FlrKb_5I/AAAAAAABzOM/FV1haQN8acwsexU2I58NUUZR55JNfhJEACJoC/w530-h570-p-rw/__djeeta_granblue_fantasy_drawn_by_benitama__52863372d221f89ae853e466bba20d6b.png");
                });

            servcomm.CreateCommand("Stomp")
                .Description("Stomp")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("http://danbooru.donmai.us/data/sample/__carmelina_djeeta_and_vohu_manah_granblue_fantasy_drawn_by_ganesagi__sample-3b0882075fdc787c633dd994c0d2829f.jpg");
                });

            servcomm.CreateCommand("Green")
                .Description("Memes")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Markdown```css\n>Tfw can't green text irl\n```");
                });

            servcomm.CreateCommand("Nudes")
                .Description("Send Nudes")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("http://i.imgur.com/oIt8Qjc.jpg");
                });

            servcomm.CreateCommand("Friendzone")
                .Alias(new string[] { "Friend", "Zone" })
                .Description("You got Friendzoned")
                .Do(async (e) =>
               {
                   await e.Channel.SendMessage("http://i.imgur.com/FEYnLK5.png");
               });

            servcomm.CreateCommand("Pray")
                .Alias(new string[] { "RNG", "Pray to rng" })
                .Description("PRAY TO THE RNG GODDESS!")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("http://i.imgur.com/PjPq2Xn.gif");
                });
                
        
            client.MessageReceived += messageHandler;

            //I congratulate the person who took over the bot last night.  At least I won't forget to hide the token bot now 
            client.ExecuteAndWait(async () =>
            {
                await client.Connect("Insert Token Here", TokenType.Bot);
            });

        }

        public static void messageHandler(object sender, MessageEventArgs e)
        {
            switch (e.Message.Text)
            {
                case "What are we gonna do DJeeta?":
                    e.Channel.SendMessage("Take over the world Nekomimi~!");
                    break;
            }
        }
        public static void LogHandler(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
}
