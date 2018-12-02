using Magazin_for_game.GameLogick.Anim;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_for_game.GameLogick.Interface
{

    class MainMenu : Transformable, Drawable
    {
        RectangleShape rectShape;

        AnimationSprite dispels;

        public Text findGameText { get; set; }
        public Text shopText { get; set; }
        public Text statisticText { get; set; }
        public Text exitText { get; set; }
        public Text greeting { get; set; }

        public const int initialPositionX = 80;
        public const int initialPositionY = 150;
        public const int indent = 100;

        public MainMenu()
        {
            rectShape = new RectangleShape(new SFML.System.Vector2f(1024, 768));
            rectShape.Texture = Content.mainMenuBackground;

            CreateSmoke();
            CreateMenu();
        }

        void Drawable.Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(rectShape, states);
            target.Draw(dispels, states);
            target.Draw(findGameText);
            target.Draw(shopText);
            target.Draw(statisticText);
            target.Draw(exitText);
            target.Draw(greeting);
        }

        private void CreateMenu()
        {
            findGameText = new Text("Find Game", Content.mainMenuFont, 50);
            findGameText.Color = Color.Black;
            findGameText.Style = Text.Styles.Bold;
            findGameText.Position = new SFML.System.Vector2f(initialPositionX, initialPositionY);

            shopText = new Text("Shop", Content.mainMenuFont, 50);
            shopText.Color = Color.White;
            shopText.Style = Text.Styles.Bold;
            shopText.Position = new SFML.System.Vector2f(initialPositionX, initialPositionY + indent);

            statisticText = new Text("Statistics", Content.mainMenuFont, 50);
            statisticText.Color = Color.White;
            statisticText.Style = Text.Styles.Bold;
            statisticText.Position = new SFML.System.Vector2f(initialPositionX, initialPositionY + (indent * 2));

            exitText = new Text("Exit", Content.mainMenuFont, 50);
            exitText.Color = Color.White;
            exitText.Style = Text.Styles.Bold;
            exitText.Position = new SFML.System.Vector2f(initialPositionX, initialPositionY + (indent * 3));

            greeting = new Text("Приветствуем, " + Program.selectedPlayer.Nickname, Content.mainMenuFont, 50);
            greeting.Color = Color.White;
            greeting.Style = Text.Styles.Bold;
            greeting.Position = new SFML.System.Vector2f(450, 100);
        }

        private void CreateSmoke()
        {
            dispels = new AnimationSprite(Content.smoke, new SpriteSheet(5, 14, 0, 2000, 5600));
            dispels.Position = new Vector2f(-200, -200);

            dispels.AddAnimation("dispel", new Animation(AddFrames(5, 12, 0.2f)));
            //dispels.AddAnimation("dispel", new Animation(
            //    new AnimationFrame(0, 0, 0.3f),
            //    new AnimationFrame(1, 0, 0.3f),
            //    new AnimationFrame(2, 0, 0.3f),
            //    new AnimationFrame(3, 0, 0.22f),
            //    new AnimationFrame(4, 0, 0.22f),
            //    new AnimationFrame(0, 1, 0.2f),
            //    new AnimationFrame(1, 1, 0.2f),
            //    new AnimationFrame(2, 1, 0.2f),
            //    new AnimationFrame(3, 1, 0.2f),
            //    new AnimationFrame(4, 1, 0.2f),
            //    new AnimationFrame(0, 2, 0.2f),
            //    new AnimationFrame(1, 2, 0.2f),
            //    new AnimationFrame(2, 2, 0.2f),
            //    new AnimationFrame(3, 2, 0.2f),
            //    new AnimationFrame(4, 2, 0.2f),
            //    new AnimationFrame(0, 3, 0.2f),
            //    new AnimationFrame(1, 3, 0.2f),
            //    new AnimationFrame(2, 3, 0.2f),
            //    new AnimationFrame(3, 3, 0.2f),
            //    new AnimationFrame(4, 3, 0.2f),
            //    new AnimationFrame(0, 4, 0.2f),
            //    new AnimationFrame(1, 4, 0.2f),
            //    new AnimationFrame(2, 4, 0.2f),
            //    new AnimationFrame(3, 4, 0.2f),
            //    new AnimationFrame(4, 4, 0.2f),
            //    new AnimationFrame(0, 5, 0.2f),
            //    new AnimationFrame(1, 5, 0.2f),
            //    new AnimationFrame(2, 5, 0.2f),
            //    new AnimationFrame(3, 5, 0.2f),
            //    new AnimationFrame(4, 5, 0.2f),
            //    new AnimationFrame(0, 6, 0.2f),
            //    new AnimationFrame(1, 6, 0.2f),
            //    new AnimationFrame(2, 6, 0.2f),
            //    new AnimationFrame(3, 6, 0.2f),
            //    new AnimationFrame(4, 6, 0.2f),
            //    new AnimationFrame(0, 7, 0.2f),
            //    new AnimationFrame(1, 7, 0.2f),
            //    new AnimationFrame(2, 7, 0.2f),
            //    new AnimationFrame(3, 7, 0.2f),
            //    new AnimationFrame(4, 7, 0.2f),
            //    new AnimationFrame(0, 8, 0.2f),
            //    new AnimationFrame(1, 8, 0.2f),
            //    new AnimationFrame(2, 8, 0.2f),
            //    new AnimationFrame(3, 8, 0.2f),
            //    new AnimationFrame(4, 8, 0.2f),
            //    new AnimationFrame(0, 9, 0.2f),
            //    new AnimationFrame(1, 9, 0.2f),
            //    new AnimationFrame(2, 9, 0.2f),
            //    new AnimationFrame(3, 9, 0.2f),
            //    new AnimationFrame(4, 9, 0.2f),
            //    new AnimationFrame(0, 10, 0.2f),
            //    new AnimationFrame(1, 10, 0.2f),
            //    new AnimationFrame(2, 10, 0.2f),
            //    new AnimationFrame(3, 10, 0.2f),
            //    new AnimationFrame(4, 10, 0.2f),
            //    new AnimationFrame(0, 11, 0.2f),
            //    new AnimationFrame(1, 11, 0.2f),
            //    new AnimationFrame(2, 11, 0.2f),
            //    new AnimationFrame(3, 11, 0.2f),
            //    new AnimationFrame(4, 11, 0.2f)
            //    ));

        }

        private AnimationFrame[] AddFrames(int col, int row, float speed)
        {
            AnimationFrame[] af = new AnimationFrame[col * row];
            int index = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    af[index++] = new AnimationFrame(j, i, speed);
                }
            }

            return af;
        }

        public void Update()
        {
            mouseHover();
            mousePress();
            //ChangeLocateSmoke();
            //if (Animation.ReAnimating == true) //Если анимация дыма в данном месте закончилась, отрисовать ее в другом месте
            //{
            //    ChangeLocateSmoke();
            //}
        }

        //private void ChangeLocateSmoke()
        //{
        //    dispels.Position = new Vector2f(rn.Next(300, 800), rn.Next(0, 800));
        //    //dispels.Position = new Vector2f(Mouse.GetPosition(Program.Window).X, Mouse.GetPosition(Program.Window).Y);
        //}

        private void mouseHover()
        {
            if (Mouse.GetPosition(Program.Window).X > findGameText.Position.X && Mouse.GetPosition(Program.Window).X < findGameText.Position.X + 215 &&
                Mouse.GetPosition(Program.Window).Y > findGameText.Position.Y && Mouse.GetPosition(Program.Window).Y < findGameText.Position.Y + 50) // При наведении на Find game
            {
                findGameText.Color = Color.Black;
                //dispels.Position = new Vector2f(initialPositionX + 100, initialPositionY);
            }


            else if (Mouse.GetPosition(Program.Window).X > shopText.Position.X && Mouse.GetPosition(Program.Window).X < shopText.Position.X + 110 &&
                Mouse.GetPosition(Program.Window).Y > shopText.Position.Y && Mouse.GetPosition(Program.Window).Y < shopText.Position.Y + 50) // При наведении на Shop
            {
                dispels.Position = new Vector2f(initialPositionX + 60, initialPositionY + indent);
                shopText.Color = Color.Black;
            }
                 

            else if (Mouse.GetPosition(Program.Window).X > statisticText.Position.X && Mouse.GetPosition(Program.Window).X < statisticText.Position.X + 230 &&
                    Mouse.GetPosition(Program.Window).Y > statisticText.Position.Y && Mouse.GetPosition(Program.Window).Y < statisticText.Position.Y + 50) // При наведении на Statistics
            {
                dispels.Position = new Vector2f(initialPositionX + 120, initialPositionY + (indent * 2));
                statisticText.Color = Color.Black;
            }
                

            else if (Mouse.GetPosition(Program.Window).X > exitText.Position.X && Mouse.GetPosition(Program.Window).X < exitText.Position.X + 100 &&
                    Mouse.GetPosition(Program.Window).Y > exitText.Position.Y && Mouse.GetPosition(Program.Window).Y < exitText.Position.Y + 50) // При наведении на Exit
            {
                dispels.Position = new Vector2f(initialPositionX + 50, initialPositionY + (indent * 3));
                exitText.Color = Color.Black;
            }
            else
            {
                dispels.Position = new Vector2f(-200, -200);
                //findGameText.Color = Color.White;
                shopText.Color = Color.White;
                statisticText.Color = Color.White;
                exitText.Color = Color.White;
            }
        }

        private void mousePress()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left)) // При нажатии на левую клавишу мыши
            {
                if (Mouse.GetPosition(Program.Window).X > shopText.Position.X && Mouse.GetPosition(Program.Window).X < shopText.Position.X + 110 &&
                Mouse.GetPosition(Program.Window).Y > shopText.Position.Y && Mouse.GetPosition(Program.Window).Y < shopText.Position.Y + 50) // Shop
                {
                    Game.gs = Game.GameStatus.SHOP;
                }
                else if (Mouse.GetPosition(Program.Window).X > statisticText.Position.X && Mouse.GetPosition(Program.Window).X < statisticText.Position.X + 150 &&
                    Mouse.GetPosition(Program.Window).Y > statisticText.Position.Y && Mouse.GetPosition(Program.Window).Y < statisticText.Position.Y + 50) // Statisctics
                {
                    Game.gs = Game.GameStatus.STATISTICS;
                }
                else if (Mouse.GetPosition(Program.Window).X > exitText.Position.X && Mouse.GetPosition(Program.Window).X < exitText.Position.X + 100 &&
                    Mouse.GetPosition(Program.Window).Y > exitText.Position.Y && Mouse.GetPosition(Program.Window).Y < exitText.Position.Y + 50) // Exit
                {
                    Program.Window.Close();
                }
            }
        }
    }
}
