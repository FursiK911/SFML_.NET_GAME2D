using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_for_game.GameLogick.Anim
{
    class AnimationFrame
    {
        //Кадр
        public int i, j;
        public float time;
        public AnimationFrame(int i, int j, float time)
        {
            this.i = i;
            this.j = j;
            this.time = time;
        }
    }
}
