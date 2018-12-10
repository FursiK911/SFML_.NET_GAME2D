using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2D.GameLogick
{
    class World : Transformable, Drawable
    {
        //кл-во тайлов в одном чанке по ширине и высоте
        public const int WORLD_SIZE = 25;
        Chunk[][] chunks;
        
        public World()
        {
            chunks = new Chunk[WORLD_SIZE][];

            for (int i = 0; i < WORLD_SIZE; i++)
            {
                chunks[i] = new Chunk[WORLD_SIZE];
            }

            chunks[0][0] = new Chunk();
        }

        void Drawable.Draw(RenderTarget target, RenderStates states)
        {
            for(int x = 0; x < WORLD_SIZE; x++)
            {
                for(int y = 0; y < WORLD_SIZE; y++)
                {
                    if (chunks[x][y] == null)
                        continue;
                
                    target.Draw(chunks[x][y]);
                }
            }
        }
    }
}
