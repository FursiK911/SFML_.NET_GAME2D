using System;
using System.Runtime.InteropServices;
using SFML;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Collections.Generic;
using System.Linq;
using Magazin_for_game.GameLogick;

namespace Magazin_for_game
{
    class Program
    {
        static RenderWindow win;
        public static RenderWindow Window { get { return win; } }
        public static Game Game { private set; get; }
        static void Main(string[] args)
        {
            win = new RenderWindow(new SFML.Window.VideoMode(1024, 768), "Game2D");
            win.SetFramerateLimit(60);
            //win.SetVerticalSyncEnabled(true);
            //win.Resized += Win_Resized; //отменяет растягивание спрайтов на экране
            //var players = GetPlayersEf();

            //foreach (var player in players)
            //{
            //    Console.WriteLine("{0}, {1}", player.id, player.nickName);
            //}
            //Console.ReadLine();


            //    window = new RenderWindow(new SFML.Window.VideoMode(800, 600), "Shop");
            //    window.SetVerticalSyncEnabled(true);
            //    Image menuBackgroundImage = new Image("images/Menu/menu.jpg");
            //    Texture menuBackgroundTexture = new Texture(menuBackgroundImage);
            //    Sprite menuBackgroundSprite = new Sprite(menuBackgroundTexture);
            //    menuBackgroundSprite.Position = new Vector2f(0,0);

            //Загрузка контента
            Content.LoadTexture();

            Game = new Game();

            Window.Closed += Win_Closed;
            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                Game.Update();

                Window.Clear(Color.Black);

                //Отрисовка
                Game.Draw();

                Window.Display();
            }
        }

        private static void Win_Resized(object sender, SizeEventArgs e)
        {
            win.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }

        private static List<Player> GetPlayersEf()
        {
            var context = new shop_in_gameContext();

            var playersList = context.Players.ToList();

            return playersList;

        }
    }
}
