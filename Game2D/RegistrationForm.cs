using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin_for_game
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_registration_Click(object sender, EventArgs e)
        {
            if(CheckDateInTextBox())
            {
                var players = GetPlayersEf();
                foreach (var player in players)
                {
                    if (player.Nickname == textBox_login.Text)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует!");
                        return;
                    }
                    else if (player.Email == textBox_email.Text)
                    {
                        MessageBox.Show("Пользователь с такой электронной почтой уже существует!");
                        return;
                    }
                }
                var context = new shop_in_gameContext();
                Players p = context.Players.Add(new Players
                {
                    Nickname = textBox_login.Text,
                    PasswordPlayer = textBox_password.Text,
                    Email = textBox_email.Text,
                    MathesPlayed = 0,
                    MathesWin = 0,
                    Commendation = 0,
                    Reports = 0,
                    RegistrationDate = DateTime.Now.Date
                });
                context.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно!");
                this.Close();
            }
            
        }

        private bool CheckDateInTextBox()
        {
            if(textBox_login.TextLength == 0 || textBox_login.TextLength > 20)
            {
                MessageBox.Show("Недопустимый логин. Длина не должна превышать выше 20-и символов");
                return false;
            }
            else if (textBox_password.TextLength == 0 || textBox_password.TextLength > 20)
            {
                MessageBox.Show("Недопустимый пароль. Длина не должна превышать выше 20-и символов");
                return false;
            }
            else if (textBox_email.TextLength == 0 || textBox_email.TextLength > 40)
            {
                MessageBox.Show("Недопустимая электронная почта. Длина не должна превышать выше 20-и символов");
                return false;
            }
            return true;
        }

        private List<Players> GetPlayersEf()
        {
            var context = new shop_in_gameContext();

            var playersList = context.Players.ToList();

            return playersList;

        }
    }
}
