using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_for_game.GameLogick
{
    enum TileType
    {
        NONE,
        GROUND
    }
    class Tile : Transformable, Drawable
    {
        public const int TILE_SIZE = 32;

        TileType type = TileType.GROUND;
        RectangleShape rectShape;

        public Tile()
        {
            rectShape = new RectangleShape(new SFML.System.Vector2f(TILE_SIZE, TILE_SIZE));

            switch (type)
            {
                case TileType.GROUND:
                    rectShape.Texture = Content.texTile0;
                    rectShape.TextureRect = new IntRect(0, 0, TILE_SIZE, TILE_SIZE);
                    break;
            }
        }

        void Drawable.Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(rectShape, states);
        }
    }
}
