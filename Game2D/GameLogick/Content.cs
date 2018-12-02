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
        public static Texture mainMenuBackground;
        public static Texture shopBackground;
        public static Texture scroll;
        public static Texture rectangle;
        public static Texture accept;

        public static Texture smoke;

        public static Texture headSprite;
        public static Texture bodySprite;
        public static Texture legSprite;

        public static Texture tabHead;
        public static Texture tabBody;
        public static Texture tabLeg;

        public static Texture texTile0;
        public static Font mainMenuFont;
        public static void LoadTexture()
        {
            texTile0 = new Texture(@"image/Tile0.png");
            mainMenuBackground = new Texture(@"image/menu2.png");
            shopBackground = new Texture(@"image/menu3.png");
            smoke = new Texture(@"image/smoke/TileSetSmoke2.png");
            headSprite = new Texture(@"image/sprites/Head.png");
            bodySprite = new Texture(@"image/sprites/Body.png");
            legSprite = new Texture(@"image/sprites/legs.png");
            tabHead = new Texture(@"image/tabs/Head.png");
            tabBody = new Texture(@"image/tabs/Body_armor.png");
            tabLeg = new Texture(@"image/tabs/leg.png");
            scroll = new Texture(@"image/sprites/scroll.png");
            rectangle = new Texture(@"image/sprites/Rectangle.png");
            accept = new Texture(@"image/sprites/accept.png");
            mainMenuFont = new Font(@"fonts/Carima.ttf");
        }
    }
}
