namespace BUD
{
    partial class AuthenticationForm
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
            this.baseLayout = new System.Windows.Forms.TableLayoutPanel();
            this.sctLogin = new System.Windows.Forms.GroupBox();
            this.btnLostPassword = new System.Windows.Forms.LinkLabel();
            this.chckSavelogin = new System.Windows.Forms.CheckBox();
            this.btnAuthenticate = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.baseLayout.SuspendLayout();
            this.sctLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseLayout
            // 
            this.baseLayout.ColumnCount = 3;
            this.baseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.baseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseLayout.Controls.Add(this.sctLogin, 1, 1);
            this.baseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseLayout.Location = new System.Drawing.Point(0, 0);
            this.baseLayout.Name = "baseLayout";
            this.baseLayout.RowCount = 3;
            this.baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseLayout.Size = new System.Drawing.Size(784, 411);
            this.baseLayout.TabIndex = 0;
            // 
            // sctLogin
            // 
            this.sctLogin.Controls.Add(this.btnLostPassword);
            this.sctLogin.Controls.Add(this.chckSavelogin);
            this.sctLogin.Controls.Add(this.btnAuthenticate);
            this.sctLogin.Controls.Add(this.txtPassword);
            this.sctLogin.Controls.Add(this.txtUsername);
            this.sctLogin.Controls.Add(this.lblPassword);
            this.sctLogin.Controls.Add(this.lblUsername);
            this.sctLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sctLogin.Location = new System.Drawing.Point(195, 68);
            this.sctLogin.Name = "sctLogin";
            this.sctLogin.Size = new System.Drawing.Size(394, 274);
            this.sctLogin.TabIndex = 0;
            this.sctLogin.TabStop = false;
            // 
            // btnLostPassword
            // 
            this.btnLostPassword.AutoSize = true;
            this.btnLostPassword.Location = new System.Drawing.Point(28, 142);
            this.btnLostPassword.Name = "btnLostPassword";
            this.btnLostPassword.Size = new System.Drawing.Size(104, 13);
            this.btnLostPassword.TabIndex = 5;
            this.btnLostPassword.TabStop = true;
            this.btnLostPassword.Text = "I forgot my password";
            // 
            // chckSavelogin
            // 
            this.chckSavelogin.AutoSize = true;
            this.chckSavelogin.Location = new System.Drawing.Point(32, 168);
            this.chckSavelogin.Name = "chckSavelogin";
            this.chckSavelogin.Size = new System.Drawing.Size(94, 17);
            this.chckSavelogin.TabIndex = 3;
            this.chckSavelogin.Text = "Remember me";
            this.chckSavelogin.UseVisualStyleBackColor = true;
            // 
            // btnAuthenticate
            // 
            this.btnAuthenticate.Location = new System.Drawing.Point(30, 193);
            this.btnAuthenticate.Name = "btnAuthenticate";
            this.btnAuthenticate.Size = new System.Drawing.Size(342, 33);
            this.btnAuthenticate.TabIndex = 4;
            this.btnAuthenticate.Text = "Authenticate";
            this.btnAuthenticate.UseVisualStyleBackColor = true;
            this.btnAuthenticate.Click += new System.EventHandler(this.btnAuthenticate_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(30, 116);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(342, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "cgp123";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(30, 66);
            this.txtUsername.MaxLength = 128;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(342, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "cgp@ua.pt";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(28, 98);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(28, 48);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // AuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.baseLayout);
            this.Name = "AuthenticationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balcão Único Digital da Universidade de Aveiro - Authentication";
            this.baseLayout.ResumeLayout(false);
            this.sctLogin.ResumeLayout(false);
            this.sctLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel baseLayout;
        private System.Windows.Forms.GroupBox sctLogin;
        private System.Windows.Forms.Button btnAuthenticate;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.LinkLabel btnLostPassword;
        private System.Windows.Forms.CheckBox chckSavelogin;
    }
}

