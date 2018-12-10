using Game2D.GameLogick.Interface;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2D.GameLogick
{
    class Game
    {
        public enum GameStatus{
            AUTHORIZATION = 0,
            MENU = 1,
            SHOP = 2,
            STATISTICS = 3,
            GAME = 4,
        }

        public static GameStatus gs = GameStatus.MENU;

        private World world { get; set; }
        private MainMenu menu { get; set; }
        private Shop shop { get; set; }
        private Statistics statistics { get; set; }

        public Game()
        {
            world = new World();
            menu = new MainMenu();
            shop = new Shop();
            statistics = new Statistics();
        }

        public void Update()
        {
            switch(gs)
            {
                case GameStatus.AUTHORIZATION:
                    break;
                case GameStatus.GAME:
                    break;
                case GameStatus.MENU:
                    menu.Update();
                    break;
                case GameStatus.SHOP:
                    shop.Update();
                    break;
                case GameStatus.STATISTICS:
                    statistics.Update();
                    break;
            }           
        }

        public void Draw()
        {
            switch (gs)
            {
                case GameStatus.AUTHORIZATION:
                    break;
                case GameStatus.GAME:
                    Program.Window.Draw(world);
                    break;
                case GameStatus.MENU:
                    Program.Window.Draw(menu);
                    break;
                case GameStatus.SHOP:
                    Program.Window.Draw(shop);
                    break;
                case GameStatus.STATISTICS:
                    Program.Window.Draw(statistics);
                    break;
            }
        }
    }
}
