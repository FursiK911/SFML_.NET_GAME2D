using System;
using System.Runtime.InteropServices;
using SFML;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Collections.Generic;
using System.Linq;
using Game2D.GameLogick;
using System.Windows;
using System.Windows.Forms;
using View = SFML.Graphics.View;

namespace Game2D
{
    class Program
    {
        static RenderWindow win;
        public static RenderWindow Window { get { return win; } }
        public static Game Game { private set; get; }
        public static Players selectedPlayer { get; set; }

        [STAThread]
        static void Main(string[] args)
        {
            AuthorizationForm authorizationForm = new AuthorizationForm();

            DialogResult resultAuthorizationForm = authorizationForm.ShowDialog();
            if (resultAuthorizationForm == DialogResult.Cancel)
                return;

            win = new RenderWindow(new SFML.Window.VideoMode(1024, 768), "Game2D");
            win.SetFramerateLimit(60);
            //win.SetVerticalSyncEnabled(true);
            //win.Resized += Win_Resized; //отменяет растягивание спрайтов на экране

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
    }
}
