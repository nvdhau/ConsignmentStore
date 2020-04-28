namespace ConsignmentStoreApp.Forms
{
    partial class LoginForm
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
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmailDisplay = new System.Windows.Forms.Label();
            this.labelPasswordDisplay = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(153, 56);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(200, 26);
            this.textBoxEmail.TabIndex = 0;
            this.textBoxEmail.Text = "admin@consign.com";
            // 
            // labelEmailDisplay
            // 
            this.labelEmailDisplay.AutoSize = true;
            this.labelEmailDisplay.Location = new System.Drawing.Point(99, 62);
            this.labelEmailDisplay.Name = "labelEmailDisplay";
            this.labelEmailDisplay.Size = new System.Drawing.Size(48, 20);
            this.labelEmailDisplay.TabIndex = 1;
            this.labelEmailDisplay.Text = "Email";
            // 
            // labelPasswordDisplay
            // 
            this.labelPasswordDisplay.AutoSize = true;
            this.labelPasswordDisplay.Location = new System.Drawing.Point(69, 100);
            this.labelPasswordDisplay.Name = "labelPasswordDisplay";
            this.labelPasswordDisplay.Size = new System.Drawing.Size(78, 20);
            this.labelPasswordDisplay.TabIndex = 2;
            this.labelPasswordDisplay.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(153, 94);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(200, 26);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.Text = "123";
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(153, 135);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(100, 40);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 246);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPasswordDisplay);
            this.Controls.Add(this.labelEmailDisplay);
            this.Controls.Add(this.textBoxEmail);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login To Consignment Store App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmailDisplay;
        private System.Windows.Forms.Label labelPasswordDisplay;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
    }
}