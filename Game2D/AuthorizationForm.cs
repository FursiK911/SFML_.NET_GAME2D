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
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            textBox_password.PasswordChar = '*';
            textBox_password.UseSystemPasswordChar = true;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            var players = GetPlayersEf();
            foreach (var player in players)
            {
                if (player.Nickname == textBox_login.Text && player.PasswordPlayer == textBox_password.Text)
                {
                    this.DialogResult = DialogResult.OK;
                    Program.selectedPlayer = player;
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("Пользователя с таким логином и паролем на найдено!");
        }

        private void button_registration_Click(object sender, EventArgs e)
        {
            RegistrationForm registration = new RegistrationForm();
            registration.ShowDialog();
        }

        private List<Players> GetPlayersEf()
        {
            var context = new shop_in_gameContext();

            var playersList = context.Players.ToList();

            return playersList;

        }
    }
}
