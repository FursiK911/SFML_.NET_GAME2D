using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_for_game.GameLogick.Interface
{
    class Statistics : Transformable, Drawable
    {
        Text mathesPlayed;
        Text mathesWin;
        Text commendations;
        Text reports;
        Text back;

        RectangleShape background;

        int initialPositionX = 100;
        int initialPositionY = 150;
        int step = 100;

        public Statistics()
        {
            var players = GetPlayersEf();
            mathesPlayed = new Text("Mathes Played : " + Program.selectedPlayer.MathesPlayed, Content.mainMenuFont, 50);
            mathesPlayed.Color = Color.White;
            mathesPlayed.Style = Text.Styles.Bold;
            mathesPlayed.Position = new SFML.System.Vector2f(initialPositionX, initialPositionY);

            mathesWin = new Text("Mathes Win : " + Program.selectedPlayer.MathesWin, Content.mainMenuFont, 50);
            mathesWin.Color = Color.White;
            mathesWin.Style = Text.Styles.Bold;
            mathesWin.Position = new SFML.System.Vector2f(initialPositionX, initialPositionY + step);

            commendations = new Text("Commendations : " + Program.selectedPlayer.Commendation, Content.mainMenuFont, 50);
            commendations.Color = Color.White;
            commendations.Style = Text.Styles.Bold;
            commendations.Position = new SFML.System.Vector2f(initialPositionX, initialPositionY + step * 2);

            reports = new Text("Reports : " + Program.selectedPlayer.Reports, Content.mainMenuFont, 50);
            reports.Color = Color.White;
            reports.Style = Text.Styles.Bold;
            reports.Position = new SFML.System.Vector2f(initialPositionX, initialPositionY + step * 3);

            back = new Text("Back", Content.mainMenuFont, 50);
            back.Color = Color.White;
            back.Style = Text.Styles.Bold;
            back.Position = new SFML.System.Vector2f(20, 700);

            background = new RectangleShape(new SFML.System.Vector2f(1024, 768));
            background.Texture = Content.mainMenuBackground;
        }

        void Drawable.Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(background, states);
            target.Draw(mathesPlayed, states);
            target.Draw(mathesWin, states);
            target.Draw(commendations, states);
            target.Draw(reports, states);
            target.Draw(back, states);
        }

        public void Update()
        {
            MouseHover();
            MousePress();
        }

        private void MousePress()
        {
            if(Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (Mouse.GetPosition(Program.Window).X > back.Position.X && Mouse.GetPosition(Program.Window).X < back.Position.X + 110 &&
                Mouse.GetPosition(Program.Window).Y > back.Position.Y && Mouse.GetPosition(Program.Window).Y < back.Position.Y + 50) // Shop
                {
                    Game.gs = Game.GameStatus.MENU;
                }
            }
        }

        private void MouseHover()
        {
            if (Mouse.GetPosition(Program.Window).X > back.Position.X && Mouse.GetPosition(Program.Window).X < back.Position.X + 110 &&
                Mouse.GetPosition(Program.Window).Y > back.Position.Y && Mouse.GetPosition(Program.Window).Y < back.Position.Y + 50) // Shop
            {
                back.Color = Color.Black;
            }
            else
            {
                back.Color = Color.White;
            }
        }

        private List<Players> GetPlayersEf()
        {
            var context = new shop_in_gameContext();

            var playersList = context.Players.ToList();

            return playersList;

        }
    }
}
