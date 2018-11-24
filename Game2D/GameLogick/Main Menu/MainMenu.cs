using Magazin_for_game.GameLogick.Anim;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_for_game.GameLogick.Main_Menu
{

    class MainMenu : Transformable, Drawable
    {
        RectangleShape rectShape;

        AnimationSprite dispels;

        Random rn;

        public Text findGameText { get; set; }
        public Text shopText { get; set; }
        public Text aboutText { get; set; }
        public Text exitText { get; set; }

        public const int initialPositionX = 80;
        public const int initialPositionY = 150;
        public const int indent = 100;

        public MainMenu()
        {
            rectShape = new RectangleShape(new SFML.System.Vector2f(1024, 768));
            rectShape.Texture = Content.menuBackground;

            dispels = new AnimationSprite(Content.smoke, new SpriteSheet(5, 14, 0, 2000, 5600));
            dispels.Position = new Vector2f(500, 300);
            dispels.AddAnimation("dispel", new Animation(
                new AnimationFrame(0, 0, 0.3f),
                new AnimationFrame(1, 0, 0.3f),
                new AnimationFrame(2, 0, 0.3f),
                new AnimationFrame(3, 0, 0.22f),
                new AnimationFrame(4, 0, 0.22f),
                new AnimationFrame(0, 1, 0.2f),
                new AnimationFrame(1, 1, 0.2f),
                new AnimationFrame(2, 1, 0.2f),
                new AnimationFrame(3, 1, 0.2f),
                new AnimationFrame(4, 1, 0.2f),
                new AnimationFrame(0, 2, 0.2f),
                new AnimationFrame(1, 2, 0.2f),
                new AnimationFrame(2, 2, 0.2f),
                new AnimationFrame(3, 2, 0.2f),
                new AnimationFrame(4, 2, 0.2f),
                new AnimationFrame(0, 3, 0.2f),
                new AnimationFrame(1, 3, 0.2f),
                new AnimationFrame(2, 3, 0.2f),
                new AnimationFrame(3, 3, 0.2f),
                new AnimationFrame(4, 3, 0.2f),
                new AnimationFrame(0, 4, 0.2f),
                new AnimationFrame(1, 4, 0.2f),
                new AnimationFrame(2, 4, 0.2f),
                new AnimationFrame(3, 4, 0.2f),
                new AnimationFrame(4, 4, 0.2f),
                new AnimationFrame(0, 5, 0.2f),
                new AnimationFrame(1, 5, 0.2f),
                new AnimationFrame(2, 5, 0.2f),
                new AnimationFrame(3, 5, 0.2f),
                new AnimationFrame(4, 5, 0.2f),
                new AnimationFrame(0, 6, 0.2f),
                new AnimationFrame(1, 6, 0.2f),
                new AnimationFrame(2, 6, 0.2f),
                new AnimationFrame(3, 6, 0.2f),
                new AnimationFrame(4, 6, 0.2f),
                new AnimationFrame(0, 7, 0.2f),
                new AnimationFrame(1, 7, 0.2f),
                new AnimationFrame(2, 7, 0.2f),
                new AnimationFrame(3, 7, 0.2f),
                new AnimationFrame(4, 7, 0.2f),
                new AnimationFrame(0, 8, 0.2f),
                new AnimationFrame(1, 8, 0.2f),
                new AnimationFrame(2, 8, 0.2f),
                new AnimationFrame(3, 8, 0.2f),
                new AnimationFrame(4, 8, 0.2f),
                new AnimationFrame(0, 9, 0.2f),
                new AnimationFrame(1, 9, 0.2f),
                new AnimationFrame(2, 9, 0.2f),
                new AnimationFrame(3, 9, 0.2f),
                new AnimationFrame(4, 9, 0.2f),
                new AnimationFrame(0, 10, 0.2f),
                new AnimationFrame(1, 10, 0.2f),
                new AnimationFrame(2, 10, 0.2f),
                new AnimationFrame(3, 10, 0.2f),
                new AnimationFrame(4, 10, 0.2f),
                new AnimationFrame(0, 11, 0.2f),
                new AnimationFrame(1, 11, 0.2f),
                new AnimationFrame(2, 11, 0.2f),
                new AnimationFrame(3, 11, 0.2f),
                new AnimationFrame(4, 11, 0.2f),
                new AnimationFrame(0, 12, 0.2f),
                new AnimationFrame(1, 12, 0.2f),
                new AnimationFrame(2, 12, 0.2f),
                new AnimationFrame(3, 12, 0.2f),
                new AnimationFrame(4, 12, 0.2f),
                new AnimationFrame(0, 13, 0.22f),
                new AnimationFrame(1, 13, 0.22f),
                new AnimationFrame(2, 13, 0.3f),
                new AnimationFrame(3, 13, 0.3f),
                new AnimationFrame(4, 13, 0.3f)
                ));

            rn = new Random();
            CreateMenu();
        }

        void Drawable.Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(rectShape, states);
            target.Draw(dispels, states);
            target.Draw(findGameText);
            target.Draw(shopText);
            target.Draw(aboutText);
            target.Draw(exitText);
        }

        public void CreateMenu()
        {
            findGameText = new Text("Find Game", Content.mainMenuFont, 50);
            findGameText.Color = Color.Black;
            findGameText.Style = Text.Styles.Bold;
            findGameText.Position = new SFML.System.Vector2f(initialPositionX, initialPositionY);

            shopText = new Text("Shop", Content.mainMenuFont, 50);
            shopText.Color = Color.White;
            shopText.Style = Text.Styles.Bold;
            shopText.Position = new SFML.System.Vector2f(initialPositionX, initialPositionY + indent);

            aboutText = new Text("About", Content.mainMenuFont, 50);
            aboutText.Color = Color.White;
            aboutText.Style = Text.Styles.Bold;
            aboutText.Position = new SFML.System.Vector2f(initialPositionX, initialPositionY + (indent * 2));

            exitText = new Text("Exit", Content.mainMenuFont, 50);
            exitText.Color = Color.White;
            exitText.Style = Text.Styles.Bold;
            exitText.Position = new SFML.System.Vector2f(initialPositionX, initialPositionY + (indent * 3));
        }

        public void Update()
        {
            mouseHover();
            mousePress();
            if(Animation.ReAnimating == true) //Если анимация дыма в данном месте закончилась, отрисовать ее в другом месте
            {
                ChangeLocateSmoke();
            }
        }

        private void ChangeLocateSmoke()
        {
            dispels.Position = new Vector2f(rn.Next(300, 800), rn.Next(0, 800));
        }

        private void mouseHover()
        {
            if (Mouse.GetPosition(Program.Window).X > findGameText.Position.X && Mouse.GetPosition(Program.Window).X < findGameText.Position.X + 215 &&
                Mouse.GetPosition(Program.Window).Y > findGameText.Position.Y && Mouse.GetPosition(Program.Window).Y < findGameText.Position.Y + 50) // При наведении на Find game
                findGameText.Color = Color.Black;

            else if (Mouse.GetPosition(Program.Window).X > shopText.Position.X && Mouse.GetPosition(Program.Window).X < shopText.Position.X + 110 &&
                Mouse.GetPosition(Program.Window).Y > shopText.Position.Y && Mouse.GetPosition(Program.Window).Y < shopText.Position.Y + 50) // При наведении на Shop
                shopText.Color = Color.Black;

            else if (Mouse.GetPosition(Program.Window).X > aboutText.Position.X && Mouse.GetPosition(Program.Window).X < aboutText.Position.X + 140 &&
                    Mouse.GetPosition(Program.Window).Y > aboutText.Position.Y && Mouse.GetPosition(Program.Window).Y < aboutText.Position.Y + 50) // При наведении на About
                aboutText.Color = Color.Black;

            else if (Mouse.GetPosition(Program.Window).X > exitText.Position.X && Mouse.GetPosition(Program.Window).X < exitText.Position.X + 100 &&
                    Mouse.GetPosition(Program.Window).Y > exitText.Position.Y && Mouse.GetPosition(Program.Window).Y < exitText.Position.Y + 50) // При наведении на Exit
            {
                exitText.Color = Color.Black;

            }
            else
            {
                //findGameText.Color = Color.White;
                shopText.Color = Color.White;
                aboutText.Color = Color.White;
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
                else if (Mouse.GetPosition(Program.Window).X > exitText.Position.X && Mouse.GetPosition(Program.Window).X < exitText.Position.X + 100 &&
                    Mouse.GetPosition(Program.Window).Y > exitText.Position.Y && Mouse.GetPosition(Program.Window).Y < exitText.Position.Y + 50) // Exit
                {
                    Program.Window.Close();
                }
            }
        }
    }
}
