namespace Magazin_for_game
{
    partial class AuthorizationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.label_login = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.linkLabel_registration = new System.Windows.Forms.LinkLabel();
            this.button_registration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(12, 30);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(348, 20);
            this.textBox_login.TabIndex = 0;
            this.textBox_login.Text = "FursiK";
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Location = new System.Drawing.Point(12, 9);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(38, 13);
            this.label_login.TabIndex = 1;
            this.label_login.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(12, 94);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(348, 20);
            this.textBox_password.TabIndex = 2;
            this.textBox_password.Text = "123";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(12, 142);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(104, 39);
            this.button_ok.TabIndex = 4;
            this.button_ok.Text = "Войти";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(135, 142);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(104, 39);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // linkLabel_registration
            // 
            this.linkLabel_registration.AutoSize = true;
            this.linkLabel_registration.Location = new System.Drawing.Point(269, 71);
            this.linkLabel_registration.Name = "linkLabel_registration";
            this.linkLabel_registration.Size = new System.Drawing.Size(91, 13);
            this.linkLabel_registration.TabIndex = 6;
            this.linkLabel_registration.TabStop = true;
            this.linkLabel_registration.Text = "Забыли пароль?";
            // 
            // button_registration
            // 
            this.button_registration.Location = new System.Drawing.Point(256, 142);
            this.button_registration.Name = "button_registration";
            this.button_registration.Size = new System.Drawing.Size(104, 39);
            this.button_registration.TabIndex = 7;
            this.button_registration.Text = "Регистрация";
            this.button_registration.UseVisualStyleBackColor = true;
            this.button_registration.Click += new System.EventHandler(this.button_registration_Click);
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 193);
            this.Controls.Add(this.button_registration);
            this.Controls.Add(this.linkLabel_registration);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.textBox_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(388, 231);
            this.MinimumSize = new System.Drawing.Size(388, 231);
            this.Name = "AuthorizationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.LinkLabel linkLabel_registration;
        private System.Windows.Forms.Button button_registration;
    }
}