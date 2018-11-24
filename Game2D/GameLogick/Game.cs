using Magazin_for_game.GameLogick.Main_Menu;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_for_game.GameLogick
{
    class Game
    {
        public enum GameStatus{
            AUTHORIZATION = 0,
            MENU = 1,
            SHOP = 2,
            GAME = 3,
        }

        public static GameStatus gs = GameStatus.MENU;
        World world;
        MainMenu menu;

        public Game()
        {
            world = new World();
            menu = new MainMenu();
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
                    break;
            }
        }
    }
}
