using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_for_game.GameLogick.Anim
{
    class AnimationSprite : Transformable, Drawable // Спрайт с анимацией
    {
        public float speed = 0.05f;

        RectangleShape rectShape;
        SpriteSheet ss; // Набор спрайтов
        SortedDictionary<string, Animation> animations = new SortedDictionary<string, Animation>();
        Animation currAnimation; // Текущая анимация
        IntRect rectTemp;
        string currAnimationName; // Имя текущей анимации

        public AnimationSprite(Texture texture, SpriteSheet ss)
        {
            this.ss = ss;

            rectShape = new RectangleShape(new SFML.System.Vector2f(ss.SubWidth, ss.SubHeight));
            rectShape.Origin = new SFML.System.Vector2f(ss.SubWidth / 2, ss.SubHeight / 2);
            rectShape.Texture = texture;
        }

        public void AddAnimation(string name, Animation animation)
        {
            animations[name] = animation;
            currAnimation = animation;
            currAnimationName = name;
        }

        public void Play(string name)
        {
            if (currAnimationName == name)
                return;

            currAnimation = animations[name];
            currAnimationName = name;
            currAnimation.Reset();
        }

        public IntRect GetTextureRect()
        {
            var currFrame = currAnimation.GetFrame(speed);
            rectTemp = ss.GetTextureRect(currFrame.i, currFrame.j);
            return rectTemp;
        }

        void Drawable.Draw(RenderTarget target, RenderStates states)
        {
            rectShape.TextureRect = GetTextureRect();

            states.Transform *= Transform;
            target.Draw(rectShape, states);
        }
    }
}
