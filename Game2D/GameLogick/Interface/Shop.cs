using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2D.GameLogick.Interface
{
    class Shop : Transformable, Drawable
    {

        enum Skins
        {
            head,
            body,
            leg
        }
        Text _back { get; set; }
        Text _buy { get; set; }
        Text _budget { get; set; }
        Text _top { get; set; }

        Text _nameItem { get; set; }
        Text _descriptionItem { get; set; }
        Text _setItem { get; set; }
        Text _priceItem { get; set; }
        Text _rarityItem { get; set; }
        Text _dataItem { get; set; }

        RectangleShape _background{ get; set; }

        RectangleShape _tabHead { get; set; }
        RectangleShape _tabBody { get; set; }
        RectangleShape _tabLeg { get; set; }
        Skins _selectTab { get; set; }

        RectangleShape _blackRectangle { get; set; }
        RectangleShape _selectRect { get; set; }
        List<RectangleShape> _accept { get; set; }
        List<RectangleShape> _cloud { get; set; }

        RectangleShape _selectHead { get; set; }
        RectangleShape _selectBody { get; set; }
        RectangleShape _selectLeg { get; set; }

        Dictionary<Items, RectangleShape> _headSprite { get; set; }
        Dictionary<Items, RectangleShape> _bodySprite { get; set; }
        Dictionary<Items, RectangleShape> _legSprite { get; set; }
        Dictionary<Items, RectangleShape> _popularItems { get; set; }

        int _numberHead = 6, _numberBody = 3, _numberLeg = 3;

        public Shop()
        {
            _background = new RectangleShape(new SFML.System.Vector2f(1024, 768));
            _background.Texture = Content.shopBackground;

            _tabHead = new RectangleShape(new SFML.System.Vector2f(141, 60));
            _tabHead.Texture = Content.tabHead;
            _tabHead.Position = new SFML.System.Vector2f(0, 150);

            _tabBody = new RectangleShape(new SFML.System.Vector2f(141, 60));
            _tabBody.Texture = Content.tabBody;
            _tabBody.Position = new SFML.System.Vector2f(0, 250);

            _tabLeg = new RectangleShape(new SFML.System.Vector2f(141, 60));
            _tabLeg.Texture = Content.tabLeg;
            _tabLeg.Position = new SFML.System.Vector2f(0, 350);

            _headSprite = new Dictionary<Items, RectangleShape>();
            _bodySprite = new Dictionary<Items, RectangleShape>();
            _legSprite = new Dictionary<Items, RectangleShape>();
            _popularItems = new Dictionary<Items, RectangleShape>();

            _selectRect = new RectangleShape(new SFML.System.Vector2f(140, 140));
            _selectRect.Texture = Content.rectangle;
            _selectRect.Position = new Vector2f(600, 50);

            _accept = new List<RectangleShape>();

            _back = new Text("Back", Content.mainMenuFont, 50);
            _back.Color = Color.Red;
            _back.Style = Text.Styles.Bold;
            _back.Origin = new Vector2f(0, 10);
            _back.Position = new SFML.System.Vector2f(50, 700);

            _buy = new Text("Buy", Content.mainMenuFont, 50);
            _buy.Color = Color.Red;
            _buy.Style = Text.Styles.Bold;
            _buy.Origin = new Vector2f(0, 10);
            _buy.Position = new SFML.System.Vector2f(900, 700);

            _budget = new Text("Budget : " + Program.selectedPlayer.Budget, Content.mainMenuFont, 40);
            _budget.Color = Color.Red;
            _budget.Style = Text.Styles.Bold;
            _budget.Origin = new Vector2f(0, 10);
            _budget.Position = new SFML.System.Vector2f(0, 450);

            _top = new Text("Топ продаж!", Content.mainMenuFont, 40);
            _top.Color = Color.White;
            _top.Style = Text.Styles.Bold;
            _top.Origin = new Vector2f(0, 10);

            _nameItem = new Text("", Content.mainMenuFont, 50);
            _nameItem.Color = Color.White;
            _nameItem.Style = Text.Styles.Bold;
            _nameItem.Origin = new Vector2f(0, 10);
            _nameItem.Position = new SFML.System.Vector2f(450, 500);

            _descriptionItem = new Text("", Content.mainMenuFont, 20);
            _descriptionItem.Color = Color.White;
            _descriptionItem.Style = Text.Styles.Bold;
            _descriptionItem.Origin = new Vector2f(0, 10);
            _descriptionItem.Position = new SFML.System.Vector2f(400, 550);

            _setItem = new Text("", Content.mainMenuFont, 30);
            _setItem.Color = Color.White;
            _setItem.Style = Text.Styles.Bold;
            _setItem.Origin = new Vector2f(0, 10);
            _setItem.Position = new SFML.System.Vector2f(400, 580);

            _priceItem = new Text("", Content.mainMenuFont, 50);
            _priceItem.Color = Color.White;
            _priceItem.Style = Text.Styles.Bold;
            _priceItem.Origin = new Vector2f(0, 10);
            _priceItem.Position = new SFML.System.Vector2f(400, 620);

            _rarityItem = new Text("", Content.mainMenuFont, 40);
            _rarityItem.Color = Color.White;
            _rarityItem.Style = Text.Styles.Bold;
            _rarityItem.Origin = new Vector2f(0, 10);
            _rarityItem.Position = new SFML.System.Vector2f(400, 660);

            _dataItem = new Text("", Content.mainMenuFont, 20);
            _dataItem.Color = Color.White;
            _dataItem.Style = Text.Styles.Bold;
            _dataItem.Origin = new Vector2f(0, 10);
            _dataItem.Position = new SFML.System.Vector2f(400, 710);

            _blackRectangle = new RectangleShape(new SFML.System.Vector2f(500, 300));
            _blackRectangle.FillColor = Color.Black;
            _blackRectangle.Position = new SFML.System.Vector2f(600, 50);

            _cloud = new List<RectangleShape>();

            //loadSprite();
            _selectTab = Skins.body;
            GetItemsEf();
            _selectTab = Skins.leg;
            GetItemsEf();
            _selectTab = Skins.head;
            GetItemsEf();
            BuildGrid(_numberHead, _headSprite, 140, 140);
            CheckPurchases(_headSprite);
            //CreateSprite(headSprite, 140, 140, numberHead, Content.headSprite);
            GetTopSales();
            BuildTop();
        }

        void Drawable.Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_background, states);
            target.Draw(_tabHead, states);
            target.Draw(_tabBody, states);
            target.Draw(_tabLeg, states);
            target.Draw(_back, states);
            target.Draw(_buy, states);
            target.Draw(_blackRectangle, states);
            if (_nameItem != null)
                target.Draw(_nameItem, states);
            if (_descriptionItem != null)
                target.Draw(_descriptionItem, states);
            if (_setItem != null)
                target.Draw(_setItem, states);
            if (_priceItem != null)
                target.Draw(_priceItem, states);
            if (_rarityItem != null)
                target.Draw(_rarityItem, states);
            if (_dataItem != null)
                target.Draw(_dataItem, states);
            target.Draw(_budget, states);
            switch (_selectTab)
            {
                case Skins.head:
                    foreach (KeyValuePair<Items, RectangleShape> i in _headSprite)
                    {
                        target.Draw(i.Value, states);
                    }
                    break;
                case Skins.body:
                    foreach (KeyValuePair<Items, RectangleShape> i in _bodySprite)
                    {
                        target.Draw(i.Value, states);
                    }
                    break;
                case Skins.leg:
                    foreach (KeyValuePair<Items, RectangleShape> i in _legSprite)
                    {
                        target.Draw(i.Value, states);
                    }
                    break;
            }

            target.Draw(_selectRect, states);
            if (_selectLeg != null)
                target.Draw(_selectLeg, states);
            if (_selectBody != null)
                target.Draw(_selectBody, states);
            if (_selectHead != null)
                target.Draw(_selectHead, states);

            if (_accept != null)
            {
                foreach (RectangleShape a in _accept)
                {
                    target.Draw(a, states);
                }
            }

            target.Draw(_top, states);

            for (int i = 0; i < _cloud.Count; i++)
            {
                target.Draw(_cloud[i], states);
            }
            foreach (KeyValuePair<Items, RectangleShape> i in _popularItems)
            {
                target.Draw(i.Value, states);
            }
        }

        public void Update()
        {
            MouseHover();
            MousePress();
        }

        private void loadSprite()
        {
            var context = new shop_in_gameContext();
            int index = 0;

            var headList = from i in context.Items
                           where i.TypeId == 1
                           select i;
            _headSprite.Clear();
            foreach (Items i in headList.ToList())
            {
                _headSprite.Add(i, CreateSprite(140, 140, Content.headSprite, index));
                index++;
            }

            var bodyList = from i in context.Items
                           where i.TypeId == 2
                           select i;
            _bodySprite.Clear();
            foreach (Items i in bodyList.ToList())
            {
                _bodySprite.Add(i, CreateSprite(75, 75, Content.bodySprite, index));
                index++;
            }

            var legList = from i in context.Items
                          where i.TypeId == 3
                          select i;
            _legSprite.Clear();
            foreach (Items i in legList.ToList())
            {
                _legSprite.Add(i, CreateSprite(50, 20, Content.legSprite, index));
                index++;
            }
        }

        private RectangleShape CloneRect(RectangleShape rect)
        {
            RectangleShape newRect = new RectangleShape();
            newRect.Size = new Vector2f(rect.Size.X, rect.Size.Y);
            newRect.Texture = new Texture(rect.Texture);
            newRect.TextureRect = new IntRect(rect.TextureRect.Left, rect.TextureRect.Top, rect.TextureRect.Width, rect.TextureRect.Height);
            //newRect.Position = new Vector2f(rect.Position.X, rect.Position.Y);
            newRect.Origin = new Vector2f(rect.Origin.X, rect.Origin.Y);
            return newRect;
        }

        //private void CreateSprite(Dictionary<string, RectangleShape> rect, int witdh, int height, int numberSprite, Texture texture)
        //{
        //    int index = 0;
        //    for (int j = 0; j < numberSprite; j++)
        //    {
        //        rect.Add(new RectangleShape(new SFML.System.Vector2f(witdh, height)));
        //        rect[index].Texture = texture;
        //        rect[index++].TextureRect = new IntRect(0 + (j * witdh), 0, witdh, height);
        //    }

        //    index = 0;
        //    double d = numberSprite / 3.0;
        //    int rows = int.Parse(Math.Ceiling(d).ToString());
        //    for (int i = 0; i < rows; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            rect[index++].Position = new Vector2f(600 + (j * witdh), 50 + (height * i));
        //            if (index >= numberSprite)
        //                break;
        //        }
        //    }
        //    selectRect.Position = rect[0].Position;
        //}

        private RectangleShape CreateSprite(int witdh, int height, Texture texture, int index)
        {
            RectangleShape rect = new RectangleShape(new SFML.System.Vector2f(witdh, height));
            rect.Texture = texture;
            rect.TextureRect = new IntRect(0 + (index * witdh), 0, witdh, height);
            return rect;
        }

        private void BuildGrid(int numberSprite, Dictionary<Items, RectangleShape> rect, int witdh, int height)
        {
            int index = 0;
            double d = numberSprite / 3.0;
            int rows = int.Parse(Math.Ceiling(d).ToString());
            Items[] keys = new Items[numberSprite];
            foreach (KeyValuePair<Items, RectangleShape> i in rect)
            {
                keys[index++] = i.Key;
            }
            index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    rect[keys[index++]].Position = new Vector2f(600 + (j * witdh), 50 + (height * i));
                    if (index >= numberSprite)
                        break;
                }
            }
            _selectRect.Position = rect[keys[0]].Position;
        }

        private void BuildCharacter(RectangleShape rectangleShape)
        {
            switch (_selectTab)
            {
                case Skins.head:
                    _selectHead = CloneRect(rectangleShape);
                    _selectHead.Origin = new Vector2f(_selectHead.Size.X / 2, _selectHead.Size.Y / 2);
                    _selectHead.Position = new Vector2f(300, 595);
                    break;
                case Skins.body:
                    _selectBody = CloneRect(rectangleShape);
                    _selectBody.Origin = new Vector2f(_selectBody.Size.X / 2, _selectBody.Size.Y / 2);
                    _selectBody.Position = new Vector2f(300, 650);
                    break;
                case Skins.leg:
                    _selectLeg = CloneRect(rectangleShape);
                    _selectLeg.Origin = new Vector2f(_selectLeg.Size.X / 2, _selectLeg.Size.Y / 2);
                    _selectLeg.Position = new Vector2f(300, 675);
                    break;
            }
        }

        private void BuildTop()
        {
            int step = 0;
            int positionY = 50, positionX = 60;
            _top.Position = new SFML.System.Vector2f(positionX + 310, positionY - 40);
            for (int i = 0; i < 3; i++)
            {
                _cloud.Add(new RectangleShape(new SFML.System.Vector2f(150, 150)));
                _cloud[i].Texture = Content.cloud;
                _cloud[i].Origin = new Vector2f(_cloud[i].Size.X / 2, _cloud[i].Size.Y / 2);
                _cloud[i].Position = new Vector2f(positionX + i * 120, positionY);
            }
            foreach (KeyValuePair<Items, RectangleShape> i in _popularItems)
            {
                if(i.Key.TypeId == 1)
                {
                    i.Value.Size = new Vector2f(90, 90);
                    i.Value.Origin = new Vector2f(i.Value.Size.X / 2, i.Value.Size.Y / 2);
                    i.Value.Position = new Vector2f(positionX + step++ * 115, positionY);
                }
                if (i.Key.TypeId == 2)
                {
                    i.Value.Size = new Vector2f(75, 75);
                    i.Value.Origin = new Vector2f(i.Value.Size.X / 2, i.Value.Size.Y / 2);
                    i.Value.Position = new Vector2f(positionX + step++ * 115, positionY + 5);
                }
                if (i.Key.TypeId == 3)
                {
                    i.Value.Size = new Vector2f(70, 40);
                    i.Value.Origin = new Vector2f(i.Value.Size.X / 2, i.Value.Size.Y / 2);
                    i.Value.Position = new Vector2f(positionX + step++ * 120, positionY);
                }
            }
        }

        private void MousePress()
        {
            bool clickOnButton = false; //Позволит уменьшить нагрузку на проверки
            if (Mouse.IsButtonPressed(Mouse.Button.Left)) // При нажатии на левую клавишу мыши
            {
                if(Content.click.Status != SoundStatus.Playing)
                {
                    Content.click.Play();
                }
                    
                if (Mouse.GetPosition(Program.Window).X > _back.Position.X && Mouse.GetPosition(Program.Window).X < _back.Position.X + 110 &&
                Mouse.GetPosition(Program.Window).Y > _back.Position.Y && Mouse.GetPosition(Program.Window).Y < _back.Position.Y + 50)
                {
                    Game.gs = Game.GameStatus.MENU;
                    clickOnButton = true;
                }
                else if (Mouse.GetPosition(Program.Window).X > _buy.Position.X && Mouse.GetPosition(Program.Window).X < _buy.Position.X + 110 &&
                Mouse.GetPosition(Program.Window).Y > _buy.Position.Y && Mouse.GetPosition(Program.Window).Y < _buy.Position.Y + 50)
                {
                    clickOnButton = true;
                    Trade();
                }
                else if (Mouse.GetPosition(Program.Window).X > _tabHead.Position.X && Mouse.GetPosition(Program.Window).X < _tabHead.Position.X + _tabHead.Size.X &&
                Mouse.GetPosition(Program.Window).Y > _tabHead.Position.Y && Mouse.GetPosition(Program.Window).Y < _tabHead.Position.Y + _tabHead.Size.Y)
                {
                    _selectTab = Skins.head;
                    CheckPurchases(_headSprite);
                    GetItemsEf();
                    BuildGrid(_numberHead, _headSprite, 140, 140);
                    _selectRect.Size = new Vector2f(140, 140);
                    _blackRectangle.Size = new Vector2f(500, 300);
                    clickOnButton = true;
                }
                else if (Mouse.GetPosition(Program.Window).X > _tabBody.Position.X && Mouse.GetPosition(Program.Window).X < _tabBody.Position.X + _tabBody.Size.X &&
                Mouse.GetPosition(Program.Window).Y > _tabBody.Position.Y && Mouse.GetPosition(Program.Window).Y < _tabBody.Position.Y + _tabBody.Size.Y)
                {
                    _selectTab = Skins.body;
                    CheckPurchases(_bodySprite);
                    GetItemsEf();
                    BuildGrid(_numberBody, _bodySprite, 75, 75);
                    _selectRect.Size = new Vector2f(75, 75);
                    _blackRectangle.Size = new Vector2f(250, 150);
                    clickOnButton = true;
                }
                else if (Mouse.GetPosition(Program.Window).X > _tabLeg.Position.X && Mouse.GetPosition(Program.Window).X < _tabLeg.Position.X + _tabLeg.Size.X &&
                Mouse.GetPosition(Program.Window).Y > _tabLeg.Position.Y && Mouse.GetPosition(Program.Window).Y < _tabLeg.Position.Y + _tabLeg.Size.Y)
                {
                    _selectTab = Skins.leg;
                    CheckPurchases(_legSprite);
                    GetItemsEf();
                    BuildGrid(_numberLeg, _legSprite, 50, 20);
                    _selectRect.Size = new Vector2f(50, 20);
                    _blackRectangle.Size = new Vector2f(200, 40);
                    clickOnButton = true;
                }

                if(!clickOnButton) //Если ранее клик не был обнаружен
                {
                    switch (_selectTab)
                    {
                        case Skins.head:
                            foreach (KeyValuePair<Items,RectangleShape> i in _headSprite)
                            {
                                if (Mouse.GetPosition(Program.Window).X > i.Value.Position.X && Mouse.GetPosition(Program.Window).X < i.Value.Position.X + i.Value.Size.X &&
                                Mouse.GetPosition(Program.Window).Y > i.Value.Position.Y && Mouse.GetPosition(Program.Window).Y < i.Value.Position.Y + i.Value.Size.Y)
                                {
                                    _selectRect.Position = i.Value.Position;
                                    BuildCharacter(i.Value);
                                    GetInfoAboutItem(i.Key);
                                    break;
                                }
                            }
                            break;
                        case Skins.body:
                            foreach (KeyValuePair<Items, RectangleShape> i in _bodySprite)
                            {
                                if (Mouse.GetPosition(Program.Window).X > i.Value.Position.X && Mouse.GetPosition(Program.Window).X < i.Value.Position.X + i.Value.Size.X &&
                                Mouse.GetPosition(Program.Window).Y > i.Value.Position.Y && Mouse.GetPosition(Program.Window).Y < i.Value.Position.Y + i.Value.Size.Y)
                                {
                                    _selectRect.Position = i.Value.Position;
                                    BuildCharacter(i.Value);
                                    GetInfoAboutItem(i.Key);
                                    break;
                                }
                            }
                            break;
                        case Skins.leg:
                            foreach(KeyValuePair<Items, RectangleShape> i in _legSprite)
                            {
                                if (Mouse.GetPosition(Program.Window).X > i.Value.Position.X && Mouse.GetPosition(Program.Window).X < i.Value.Position.X + i.Value.Size.X &&
                                Mouse.GetPosition(Program.Window).Y > i.Value.Position.Y && Mouse.GetPosition(Program.Window).Y < i.Value.Position.Y + i.Value.Size.Y)
                                {
                                    _selectRect.Position = i.Value.Position;
                                    BuildCharacter(i.Value);
                                    GetInfoAboutItem(i.Key);
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
            if (Mouse.GetPosition(Program.Window).X > _back.Position.X && Mouse.GetPosition(Program.Window).X < _back.Position.X + 110 &&
            Mouse.GetPosition(Program.Window).Y > _back.Position.Y && Mouse.GetPosition(Program.Window).Y < _back.Position.Y + 50) // back
            {
                _back.Color = Color.Black;
            }
            else if (Mouse.GetPosition(Program.Window).X > _buy.Position.X && Mouse.GetPosition(Program.Window).X < _buy.Position.X + 110 &&
            Mouse.GetPosition(Program.Window).Y > _buy.Position.Y && Mouse.GetPosition(Program.Window).Y < _buy.Position.Y + 50) // buy
            {
                _buy.Color = Color.Black;
            }
            else
            {
                _back.Color = Color.Red;
                _buy.Color = Color.Red;
            }
        }

        private void Trade()
        {
            switch (_selectTab)
            {
                case Skins.head:
                    foreach (KeyValuePair<Items, RectangleShape> i in _headSprite)
                    {
                        if (i.Value.Position == _selectRect.Position && PurchaseMade(i.Key.ItemPrice, i.Key.Id))
                        {
                            Purchase(i.Key.ItemPrice);
                            SetInfoAboutSale(i.Key.Id);
                            _budget.DisplayedString = "Budget : " + Program.selectedPlayer.Budget.ToString();
                            PurchaseAcceptDraw();
                            break;
                        }
                    }
                    break;
                case Skins.body:
                    foreach (KeyValuePair<Items, RectangleShape> i in _bodySprite)
                    {
                        if (i.Value.Position == _selectRect.Position && PurchaseMade(i.Key.ItemPrice, i.Key.Id))
                        {
                            Purchase(i.Key.ItemPrice);
                            SetInfoAboutSale(i.Key.Id);
                            _budget.DisplayedString = "Budget : " + Program.selectedPlayer.Budget.ToString();
                            PurchaseAcceptDraw();
                            break;
                        }
                    }
                    break;
                case Skins.leg:
                    foreach (KeyValuePair<Items, RectangleShape> i in _legSprite)
                    {
                        if (i.Value.Position == _selectRect.Position && PurchaseMade(i.Key.ItemPrice, i.Key.Id))
                        {
                            Purchase(i.Key.ItemPrice);
                            SetInfoAboutSale(i.Key.Id);
                            _budget.DisplayedString = "Budget : " + Program.selectedPlayer.Budget.ToString();
                            PurchaseAcceptDraw();
                            break;
                        }
                    }
                    break;
            }
        }

        private bool PurchaseMade(int price, int id)
        {
            List<Sale> inventories = GetInfoAboutSale();
            if(Program.selectedPlayer.Budget >= price)
            {
                for (int i = 0; i < inventories.Count; i++)
                {
                    if (inventories[i].ItemId == id)
                        return false;
                }
                return true;
            }
            return false;
        }
        
        private void Purchase(int price) // С использованием EF запроса
        {
            Program.selectedPlayer.Budget -= price;
            var context = new shop_in_gameContext();
            var player = context.Players
                .Where(p => p.Id == Program.selectedPlayer.Id);
            List<Players> players = player.ToList();
            players[0].Budget = Program.selectedPlayer.Budget;
            context.SaveChanges();
        }

        private void PurchaseAcceptDraw()
        {
            _accept.Add(new RectangleShape(new SFML.System.Vector2f(15, 15)));
            _accept[_accept.Count - 1].Texture = Content.accept;
            _accept[_accept.Count - 1].Position = _selectRect.Position;
        }

        private void GetItemsEf()
        {
            var context = new shop_in_gameContext();
            int index = 0;
            switch (_selectTab)
            {
                case Skins.head:
                    var headList = from i in context.Items
                                   where i.TypeId == 1
                                   select i;
                    _headSprite.Clear();
                    foreach (Items i in headList.ToList())
                    {
                        _headSprite.Add(i, CreateSprite(140, 140, Content.headSprite, index));
                        index++;
                    }
                    break;
                case Skins.body:
                    var bodyList = from i in context.Items
                                   where i.TypeId == 2
                                   select i;
                    _bodySprite.Clear();
                    foreach (Items i in bodyList.ToList())
                    {
                        _bodySprite.Add(i, CreateSprite(75, 75, Content.bodySprite, index));
                        index++;
                    }
                    break;
                case Skins.leg:
                    var legList = from i in context.Items
                                  where i.TypeId == 3
                                  select i;
                    _legSprite.Clear();
                    foreach (Items i in legList.ToList())
                    {
                        _legSprite.Add(i, CreateSprite(50, 20, Content.legSprite, index));
                        index++;
                    }
                    break;
            }
        }

        //private Dictionary<Items,RectangleShape> ToDictionary(List<Items> items)
        //{
        //    Dictionary<Items, RectangleShape> dict = new Dictionary<Items, RectangleShape>();

        //    return dict;
        //}

        //private void MapTextures()
        //{
        //    int index = 0;
        //    switch (selectTab)
        //    {
        //        case Skins.HEAD:
        //            foreach (KeyValuePair<Items, RectangleShape> i in headSprite)
        //            {
        //                headSprite[i.Key] = CreateSprite(140, 140, Content.headSprite, index);
        //                index++;
        //            }
        //            break;
        //        case Skins.BODY:
        //            foreach (KeyValuePair<Items, RectangleShape> i in bodySprite)
        //            {

        //            }
        //            break;
        //        case Skins.LEG:
        //            foreach (KeyValuePair<Items, RectangleShape> i in legSprite)
        //            {
        //                legSprite[i.Key] = CreateSprite(50, 20, Content.legSprite, index);
        //                index++;
        //            }
        //            break;
        //    }

        //}

        private void SetInfoAboutSale(int id)
        {
            var context = new shop_in_gameContext();
            Sale p = context.Sale.Add(new Sale
            {
                BuyerId = Program.selectedPlayer.Id,
                ItemId = id,
                NumberItems = 1,
                DataPurchase = DateTime.Today,
            });
            context.SaveChanges();
        }

        private void CheckPurchases(Dictionary<Items, RectangleShape> sprites)
        {
            _accept.Clear();
            List<Sale> purchases = GetInfoAboutSale();

            for (int p = 0; p < purchases.Count; p++)
            {
                foreach (KeyValuePair<Items, RectangleShape> i in sprites)
                {
                    if (purchases[p].ItemId == i.Key.Id)
                    {
                        _accept.Add(new RectangleShape(new SFML.System.Vector2f(15, 15)));
                        _accept[_accept.Count - 1].Texture = Content.accept;
                        _accept[_accept.Count - 1].Position = i.Value.Position;
                        break;
                    }
                }
            }
        }

        private List<Sale> GetInfoAboutSale()
        {
            var context = new shop_in_gameContext();
            var sale = from i in context.Sale
                         where i.BuyerId == Program.selectedPlayer.Id
                         select i;
            List<Sale> saleList = sale.ToList();
            return saleList;
        }

        private void GetInfoAboutItem(Items items)
        {
            _nameItem.DisplayedString = items.ItemName;
            _priceItem.DisplayedString = "Price : " + items.ItemPrice;
            _rarityItem.DisplayedString = GetInfoAboutRarity(items.RarityId);
            switch(items.RarityId)
            {
                case 1:
                    _rarityItem.Color = Color.White;
                    break;
                case 2:
                    _rarityItem.Color = Color.White;
                    break;
                case 3:
                    _rarityItem.Color = Color.Blue;
                    break;
                case 4:
                    _rarityItem.Color = Color.Magenta;
                    break;
                case 5:
                    _rarityItem.Color = Color.Yellow;
                    break;
            }
            _dataItem.DisplayedString = "Release : " + items.ItemDataRelease.ToShortDateString();
            if (items.SetId == null)
            {
                _setItem.DisplayedString = "";
            }
            else
            {
                _setItem.DisplayedString = "Included in the set : " + GetInfoAboutSet(items.SetId.Value);
            }
            if (items.ItemDescription == null)
            {
                _descriptionItem.DisplayedString = "";
            }
            else
            {
                _descriptionItem.DisplayedString = items.ItemDescription;
            }        
        }

        private string GetInfoAboutRarity(int id) //С использованием LINQ
        {
            var context = new shop_in_gameContext();
            var rarity = from i in context.RarityItems
                           where i.Id == id
                           select i;
            List<RarityItems> rarityList = rarity.ToList();
            return rarityList[0].RarityType;
        }

        private string GetInfoAboutSet(int id)
        {
            var context = new shop_in_gameContext();
            var itemSets = from i in context.ItemSets
                         where i.Id == id
                         select i;
            List<ItemSets> itemSetsList = itemSets.ToList();
            return itemSetsList[0].SetName;
        }

        private void GetTopSales()
        {
            var context = new shop_in_gameContext();
            //List<Sale> sale = context.Sale.SqlQuery("SELECT TOP (3) Count([Id]) as CountItems, [ItemId] FROM[shop_in_game].[dbo].[Sale] GROUP BY ItemId ORDER BY CountItems DESC").ToList();
            List<IGrouping<int, Sale>> sales = context.Sale
                .GroupBy(t => t.ItemId)
                .OrderByDescending(t => t.Count())
                .Take(3)
                .ToList();
            for (int i = 0; i < sales.Count; i++)
            {
                _popularItems.Add(GetItems(sales[i].Key), GetRect(sales[i].Key));
            }
        }

        private Items GetItems(int id)
        {
            foreach (KeyValuePair<Items, RectangleShape> i in _headSprite)
            {
                if (i.Key.Id == id)
                    return i.Key;
            }
            foreach (KeyValuePair<Items, RectangleShape> i in _bodySprite)
            {
                if (i.Key.Id == id)
                    return i.Key;
            }
            foreach (KeyValuePair<Items, RectangleShape> i in _legSprite)
            {
                if (i.Key.Id == id)
                    return i.Key;
            }
            return null;
        } //Совместить эти оба метода
        private RectangleShape GetRect(int id)
        {
            foreach (KeyValuePair<Items, RectangleShape> i in _headSprite)
            {
                if (i.Key.Id == id)
                    return CloneRect(i.Value);
            }
            foreach (KeyValuePair<Items, RectangleShape> i in _bodySprite)
            {
                if (i.Key.Id == id)
                    return CloneRect(i.Value);
            }
            foreach (KeyValuePair<Items, RectangleShape> i in _legSprite)
            {
                if (i.Key.Id == id)
                    return CloneRect(i.Value);
            }
            return null;
        }
    }
}