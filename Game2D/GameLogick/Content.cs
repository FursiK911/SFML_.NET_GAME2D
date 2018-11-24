using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_for_game.GameLogick
{
    class Content
    {
        public static Texture menuBackground;
        public static Texture smoke;
        public static Texture texTile0;
        public static Font mainMenuFont;
        public static void LoadTexture()
        {
            texTile0 = new Texture(@"image/Tile0.png");
            menuBackground = new Texture(@"image/menu.png");
            smoke = new Texture(@"image/smoke/TileSetSmoke.png");
            mainMenuFont = new Font(@"fonts/Carima.ttf");
        }
    }
}
