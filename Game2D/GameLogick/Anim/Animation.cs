using Magazin_for_game.GameLogick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_for_game.GameLogick.Anim
{
    class Animation
    {
        AnimationFrame[] frames;

        float timer;
        AnimationFrame currFrame;
        int currFrameIndex;
        public static bool ReAnimating = false;

        public Animation(params AnimationFrame[] frames)
        {
            this.frames = frames;
            Reset();
        }

        // Начать проигрывание анимации сначала
        public void Reset()
        {
            timer = 0f;
            currFrameIndex = 0;
            currFrame = frames[currFrameIndex];
        }

        //Следующий кадр
        public void NextFrame()
        {
            ReAnimating = false;
            timer = 0f;
            currFrameIndex++;

            if(currFrameIndex == frames.Length)
            {
                currFrameIndex = 0;
                ReAnimating = true;
            }

            currFrame = frames[currFrameIndex];
        }
        
        // Получить текущий кадр
        public AnimationFrame GetFrame(float speed)
        {
            timer += speed;

            if (timer >= currFrame.time)
                NextFrame();

            return currFrame;
        }

    }
}
