namespace Magazin_for_game
{
    partial class RegistrationForm
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
            this.label_login = new System.Windows.Forms.Label();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label_email = new System.Windows.Forms.Label();
            this.button_registration = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Location = new System.Drawing.Point(9, 22);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(38, 13);
            this.label_login.TabIndex = 0;
            this.label_login.Text = "Логин";
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(12, 38);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(387, 20);
            this.textBox_login.TabIndex = 1;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(12, 92);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(387, 20);
            this.textBox_password.TabIndex = 3;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(9, 76);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(45, 13);
            this.label_password.TabIndex = 2;
            this.label_password.Text = "Пароль";
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(12, 143);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(387, 20);
            this.textBox_email.TabIndex = 5;
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(9, 127);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(32, 13);
            this.label_email.TabIndex = 4;
            this.label_email.Text = "Email";
            // 
            // button_registration
            // 
            this.button_registration.Location = new System.Drawing.Point(12, 179);
            this.button_registration.Name = "button_registration";
            this.button_registration.Size = new System.Drawing.Size(109, 41);
            this.button_registration.TabIndex = 6;
            this.button_registration.Text = "Зарегистрировать";
            this.button_registration.UseVisualStyleBackColor = true;
            this.button_registration.Click += new System.EventHandler(this.button_registration_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(289, 179);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(110, 41);
            this.button_cancel.TabIndex = 7;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 232);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_registration);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.textBox_login);
            this.Controls.Add(this.label_login);
            this.MaximumSize = new System.Drawing.Size(427, 270);
            this.MinimumSize = new System.Drawing.Size(427, 270);
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Button button_registration;
        private System.Windows.Forms.Button button_cancel;
    }
}