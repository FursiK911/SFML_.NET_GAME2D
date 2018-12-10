using SFML;
using SFML.Audio;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2D.GameLogick
{
    class Content
    {
        public static Texture mainMenuBackground { get; set; }
        public static Texture shopBackground { get; set; }
        public static Texture scroll { get; set; }
        public static Texture rectangle { get; set; }
        public static Texture accept { get; set; }
        public static Texture cloud { get; set; }

        public static Texture smoke { get; set; }

        public static Texture headSprite { get; set; }
        public static Texture bodySprite { get; set; }
        public static Texture legSprite { get; set; }

        public static Texture tabHead { get; set; }
        public static Texture tabBody { get; set; }
        public static Texture tabLeg { get; set; }

        public static SoundBuffer clickBuf { get; set; }
        public static Sound click { get; set; }


        public static Texture texTile0 { get; set; }
        public static Font mainMenuFont { get; set; }

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
            cloud = new Texture(@"image/sprites/cloud.png");
            mainMenuFont = new Font(@"fonts/Carima.ttf");
            clickBuf = new SoundBuffer(@"sound/click.wav");
            click = new Sound(clickBuf);
            click.Pitch = 0.5f;
        }
    }
}
