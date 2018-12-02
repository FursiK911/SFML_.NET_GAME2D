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
    class Shop : Transformable, Drawable
    {

        enum Skins
        {
            HEAD,
            BODY,
            LEG
        }
        Text back;
        Text buy;
        Text budget;

        Text nameItem;
        Text descriptionItem;
        Text setItem;
        Text priceItem;
        Text rarityItem;
        Text dataItem;

        RectangleShape background;

        RectangleShape tabHead;
        RectangleShape tabBody;
        RectangleShape tabLeg;
        Skins selectTab;

        RectangleShape blackRectangle;
        RectangleShape selectRect;
        RectangleShape accept;

        RectangleShape selectHead;
        RectangleShape selectBody;
        RectangleShape selectLeg;

        List<RectangleShape> headSprite;
        List<RectangleShape> bodySprite; 
        List<RectangleShape> legSprite;

        int numberHead = 6, numberBody = 3, numberLeg = 3;

        public Shop()
        {
            background = new RectangleShape(new SFML.System.Vector2f(1024, 768));
            background.Texture = Content.shopBackground;

            tabHead = new RectangleShape(new SFML.System.Vector2f(141, 60));
            tabHead.Texture = Content.tabHead;
            tabHead.Position = new SFML.System.Vector2f(0, 100);

            tabBody = new RectangleShape(new SFML.System.Vector2f(141, 60));
            tabBody.Texture = Content.tabBody;
            tabBody.Position = new SFML.System.Vector2f(0, 200);

            tabLeg = new RectangleShape(new SFML.System.Vector2f(141, 60));
            tabLeg.Texture = Content.tabLeg;
            tabLeg.Position = new SFML.System.Vector2f(0, 300);

            selectTab = Skins.HEAD;

            headSprite = new List<RectangleShape>();

            bodySprite = new List<RectangleShape>();

            legSprite = new List<RectangleShape>();

            selectRect = new RectangleShape(new SFML.System.Vector2f(140, 140));
            selectRect.Texture = Content.rectangle;
            selectRect.Position = new Vector2f(600, 50);

            accept = new RectangleShape(new SFML.System.Vector2f(30, 30));
            accept.Texture = Content.accept;

            back = new Text("Back", Content.mainMenuFont, 50);
            back.Color = Color.Red;
            back.Style = Text.Styles.Bold;
            back.Origin = new Vector2f(0, 10);
            back.Position = new SFML.System.Vector2f(50, 700);

            buy = new Text("Buy", Content.mainMenuFont, 50);
            buy.Color = Color.Red;
            buy.Style = Text.Styles.Bold;
            buy.Origin = new Vector2f(0, 10);
            buy.Position = new SFML.System.Vector2f(900, 700);

            budget = new Text("Budget : " + Program.selectedPlayer.Budget, Content.mainMenuFont, 50);
            budget.Color = Color.Red;
            budget.Style = Text.Styles.Bold;
            budget.Origin = new Vector2f(0, 10);
            budget.Position = new SFML.System.Vector2f(300, 10);

            blackRectangle = new RectangleShape(new SFML.System.Vector2f(500, 300));
            blackRectangle.FillColor = Color.Black;
            blackRectangle.Position = new SFML.System.Vector2f(600, 50);

            CreateSprite(headSprite, 140, 140, numberHead, Content.headSprite);
            GetItemsEf();
        }

        void Drawable.Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(background, states);
            target.Draw(tabHead, states);
            target.Draw(tabBody, states);
            target.Draw(tabLeg, states);
            target.Draw(back, states);
            target.Draw(buy, states);
            target.Draw(blackRectangle, states);

            switch (selectTab)
            {
                case Skins.HEAD:
                    for (int i = 0; i < numberHead; i++)
                    {
                        target.Draw(headSprite[i], states);
                    }
                    break;
                case Skins.BODY:
                    for (int i = 0; i < numberBody; i++)
                    {
                        target.Draw(bodySprite[i], states);
                    }
                    break;
                case Skins.LEG:
                    for (int i = 0; i < numberLeg; i++)
                    {
                        target.Draw(legSprite[i], states);
                    }
                    break;
            }

            target.Draw(selectRect, states);
            if (selectLeg != null)
                target.Draw(selectLeg, states);
            if (selectBody != null)
                target.Draw(selectBody, states);
            if (selectHead != null)
                target.Draw(selectHead, states);

            target.Draw(accept, states);
        }

        public void Update()
        {
            MouseHover();
            MousePress();
        }

        private void BuildCharacter(int index)
        {
            switch (selectTab)
            {
                case Skins.HEAD:
                    selectHead = Clone(headSprite[index]);
                    selectHead.Origin = new Vector2f(selectHead.Size.X / 2, selectHead.Size.Y / 2);
                    selectHead.Position = new Vector2f(300, 595);
                    break;
                case Skins.BODY:
                    selectBody = Clone(bodySprite[index]);
                    selectBody.Origin = new Vector2f(selectBody.Size.X / 2, selectBody.Size.Y / 2);
                    selectBody.Position = new Vector2f(300, 650);
                    break;
                case Skins.LEG:
                    selectLeg = Clone(legSprite[index]);
                    selectLeg.Origin = new Vector2f(selectLeg.Size.X / 2, selectLeg.Size.Y / 2);
                    selectLeg.Position = new Vector2f(300, 675);
                    break;
            }
        }

        private RectangleShape Clone(RectangleShape rect)
        {
            RectangleShape newRect = new RectangleShape();
            newRect.Size = new Vector2f(rect.Size.X, rect.Size.Y);
            newRect.Texture = new Texture(rect.Texture);
            newRect.TextureRect = new IntRect(rect.TextureRect.Left, rect.TextureRect.Top, rect.TextureRect.Width, rect.TextureRect.Height);
            //newRect.Position = new Vector2f(rect.Position.X, rect.Position.Y);
            newRect.Origin = new Vector2f(rect.Origin.X, rect.Origin.Y);
            return newRect;
        }

        private void CreateSprite(List<RectangleShape> rect, int witdh, int height, int numberSprite, Texture texture)
        {
            int index = 0;
            for (int j = 0; j < numberSprite; j++)
            {
                rect.Add(new RectangleShape(new SFML.System.Vector2f(witdh, height)));
                rect[index].Texture = texture;
                rect[index++].TextureRect = new IntRect(0 + (j * witdh), 0, witdh, height);
            }

            index = 0;
            double d = numberSprite / 3.0;
            int rows = int.Parse(Math.Ceiling(d).ToString());
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    rect[index++].Position = new Vector2f(600 + (j * witdh), 50 + (height * i));
                    if (index >= numberSprite)
                        break;
                }
            }
            selectRect.Position = rect[0].Position;
        }

        private void MousePress()
        {
            bool clickOnButton = false; //Позволит уменьшить нагрузку на проверки
            if (Mouse.IsButtonPressed(Mouse.Button.Left)) // При нажатии на левую клавишу мыши
            {
                if (Mouse.GetPosition(Program.Window).X > back.Position.X && Mouse.GetPosition(Program.Window).X < back.Position.X + 110 &&
                Mouse.GetPosition(Program.Window).Y > back.Position.Y && Mouse.GetPosition(Program.Window).Y < back.Position.Y + 50)
                {
                    Game.gs = Game.GameStatus.MENU;
                    clickOnButton = true;
                }
                else if (Mouse.GetPosition(Program.Window).X > buy.Position.X && Mouse.GetPosition(Program.Window).X < buy.Position.X + 110 &&
                Mouse.GetPosition(Program.Window).Y > buy.Position.Y && Mouse.GetPosition(Program.Window).Y < buy.Position.Y + 50)
                {
                    Trade();
                    accept.Position = selectRect.Position;
                    clickOnButton = true;
                }
                else if (Mouse.GetPosition(Program.Window).X > tabHead.Position.X && Mouse.GetPosition(Program.Window).X < tabHead.Position.X + tabHead.Size.X &&
                Mouse.GetPosition(Program.Window).Y > tabHead.Position.Y && Mouse.GetPosition(Program.Window).Y < tabHead.Position.Y + tabHead.Size.Y)
                {
                    selectTab = Skins.HEAD;
                    CreateSprite(headSprite, 140, 140, 6, Content.headSprite);
                    selectRect.Size = new Vector2f(140, 140);
                    blackRectangle.Size = new Vector2f(500, 300);
                    clickOnButton = true;
                }
                else if (Mouse.GetPosition(Program.Window).X > tabBody.Position.X && Mouse.GetPosition(Program.Window).X < tabBody.Position.X + tabBody.Size.X &&
                Mouse.GetPosition(Program.Window).Y > tabBody.Position.Y && Mouse.GetPosition(Program.Window).Y < tabBody.Position.Y + tabBody.Size.Y)
                {
                    selectTab = Skins.BODY;
                    CreateSprite(bodySprite,75, 75, 3, Content.bodySprite);
                    selectRect.Size = new Vector2f(75, 75);
                    blackRectangle.Size = new Vector2f(250,150);
                    clickOnButton = true;
                }
                else if (Mouse.GetPosition(Program.Window).X > tabLeg.Position.X && Mouse.GetPosition(Program.Window).X < tabLeg.Position.X + tabLeg.Size.X &&
                Mouse.GetPosition(Program.Window).Y > tabLeg.Position.Y && Mouse.GetPosition(Program.Window).Y < tabLeg.Position.Y + tabLeg.Size.Y)
                {
                    selectTab = Skins.LEG;
                    CreateSprite(legSprite,50, 20, 3, Content.legSprite);
                    selectRect.Size = new Vector2f(50, 20);
                    blackRectangle.Size = new Vector2f(200, 40);
                    clickOnButton = true;
                }

                if(!clickOnButton) //Если ранее клик не был обнаружен
                {
                    switch (selectTab)
                    {
                        case Skins.HEAD:
                            for (int i = 0; i < numberHead; i++)
                            {
                                if (Mouse.GetPosition(Program.Window).X > headSprite[i].Position.X && Mouse.GetPosition(Program.Window).X < headSprite[i].Position.X + headSprite[i].Size.X &&
                                Mouse.GetPosition(Program.Window).Y > headSprite[i].Position.Y && Mouse.GetPosition(Program.Window).Y < headSprite[i].Position.Y + headSprite[i].Size.Y)
                                {
                                    selectRect.Position = headSprite[i].Position;
                                    BuildCharacter(i);
                                    break;
                                }
                            }
                            break;
                        case Skins.BODY:
                            for (int i = 0; i < numberBody; i++)
                            {
                                if (Mouse.GetPosition(Program.Window).X > bodySprite[i].Position.X && Mouse.GetPosition(Program.Window).X < bodySprite[i].Position.X + bodySprite[i].Size.X &&
                                Mouse.GetPosition(Program.Window).Y > bodySprite[i].Position.Y && Mouse.GetPosition(Program.Window).Y < bodySprite[i].Position.Y + bodySprite[i].Size.Y)
                                {
                                    selectRect.Position = bodySprite[i].Position;
                                    BuildCharacter(i);
                                    break;
                                }
                            }
                            break;
                        case Skins.LEG:
                            for (int i = 0; i < numberLeg; i++)
                            {
                                if (Mouse.GetPosition(Program.Window).X > legSprite[i].Position.X && Mouse.GetPosition(Program.Window).X < legSprite[i].Position.X + legSprite[i].Size.X &&
                                Mouse.GetPosition(Program.Window).Y > legSprite[i].Position.Y && Mouse.GetPosition(Program.Window).Y < legSprite[i].Position.Y + legSprite[i].Size.Y)
                                {
                                    selectRect.Position = legSprite[i].Position;
                                    BuildCharacter(i);
                                    break;
                                }
                            }
                            break;
                    }
                }
            }
        }

        private void MouseHover()
        {
            if (Mouse.GetPosition(Program.Window).X > back.Position.X && Mouse.GetPosition(Program.Window).X < back.Position.X + 110 &&
            Mouse.GetPosition(Program.Window).Y > back.Position.Y && Mouse.GetPosition(Program.Window).Y < back.Position.Y + 50) // back
            {
                back.Color = Color.Black;
            }
            else if (Mouse.GetPosition(Program.Window).X > buy.Position.X && Mouse.GetPosition(Program.Window).X < buy.Position.X + 110 &&
            Mouse.GetPosition(Program.Window).Y > buy.Position.Y && Mouse.GetPosition(Program.Window).Y < buy.Position.Y + 50) // buy
            {
                buy.Color = Color.Black;
            }
            else
            {
                back.Color = Color.Red;
                buy.Color = Color.Red;
            }
        }

        private void Trade()
        {
            //var context = new shop_in_gameContext();
            //Inventory p = context.Inventory.Add(new Inventory
            //{
            //    PlayerId = Program.selectedPlayer.Id,
            //    ItemsId = 
            //});
            //context.SaveChanges();
        }

        private System.Linq.IQueryable<Items> GetItemsEf()
        {
            var context = new shop_in_gameContext();

            switch (selectTab)
            {
                case Skins.HEAD:
                    var headList = from i in context.Items
                                    where i.TypeId == 1
                                    select i;
                    return headList;
                case Skins.BODY:
                    var bodyList = from i in context.Items
                                    where i.TypeId == 2
                                    select i;
                    return bodyList;
                case Skins.LEG:
                    var legList = from i in context.Items
                                    where i.TypeId == 3
                                    select i;
                    return legList;
            }
            return null;
        }

        private void GetInfoAboutItem(int index)
        {

        }
    }
}