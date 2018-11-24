using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_for_game.GameLogick.Anim
{
    class SpriteSheet
    {
        public int SubWidth { get { return subW; } }
        public int SubHeight { get { return subH; } }

        IntRect rectTemp;

        int subW, subH; // Ширина и высота одного фрагмента текстуры
        int borderSize; //Толщина рамки между фрагментами

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="a">Кл-во фрагментов по Х или размер одного фрагмента в пикселях по ширине</param>
        /// <param name="b">Кл-во фрагментов по Y или размер одного фрагмента в пикселях по высоте</param>
        /// <param name="borderSize">Толщина рамки между фрагментами</param>
        /// <param name="texH">Ширина текстуры</param>
        /// <param name="texW">Высота текстуры</param>
        public SpriteSheet(int a, int b, int borderSize, int texW=0, int texH=0)
        {
            if (borderSize > 0)
            {
                this.borderSize = borderSize + 1; // Необходимо для алгоритма
            }
            if (texW != 0 && texH != 0)
            {
                subW = texW / a;
                subH = texH / b;
            }
            else
            {
                subW = a;
                subH = b;
            }
        }

        public IntRect GetTextureRect(int i, int j)
        {
            int x = i * subW + i * borderSize;
            int y = j * subH + j * borderSize;
            rectTemp = new IntRect(x, y, subW, subH);
            return rectTemp;
        }
    }
}
