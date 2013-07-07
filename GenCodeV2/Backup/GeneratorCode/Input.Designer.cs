namespace GenCsharp
{
    partial class Input
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
            this.tbUserLogIn = new System.Windows.Forms.TabPage();
            this.gbUser = new System.Windows.Forms.GroupBox();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.btnConnect2 = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabIntroduction = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnamespace = new System.Windows.Forms.TextBox();
            this.tbUserLogIn.SuspendLayout();
            this.gbUser.SuspendLayout();
            this.tabIntroduction.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUserLogIn
            // 
            this.tbUserLogIn.Controls.Add(this.gbUser);
            this.tbUserLogIn.Location = new System.Drawing.Point(4, 22);
            this.tbUserLogIn.Name = "tbUserLogIn";
            this.tbUserLogIn.Padding = new System.Windows.Forms.Padding(3);
            this.tbUserLogIn.Size = new System.Drawing.Size(380, 258);
            this.tbUserLogIn.TabIndex = 1;
            this.tbUserLogIn.Text = "UserLogIn";
            this.tbUserLogIn.UseVisualStyleBackColor = true;
            // 
            // gbUser
            // 
            this.gbUser.Controls.Add(this.txtnamespace);
            this.gbUser.Controls.Add(this.label1);
            this.gbUser.Controls.Add(this.btnCancel2);
            this.gbUser.Controls.Add(this.btnConnect2);
            this.gbUser.Controls.Add(this.txtPassword);
            this.gbUser.Controls.Add(this.txtUserID);
            this.gbUser.Controls.Add(this.txtDatabase);
            this.gbUser.Controls.Add(this.txtServer);
            this.gbUser.Controls.Add(this.label5);
            this.gbUser.Controls.Add(this.label4);
            this.gbUser.Controls.Add(this.label3);
            this.gbUser.Controls.Add(this.label2);
            this.gbUser.Location = new System.Drawing.Point(8, 6);
            this.gbUser.Name = "gbUser";
            this.gbUser.Size = new System.Drawing.Size(364, 244);
            this.gbUser.TabIndex = 0;
            this.gbUser.TabStop = false;
            this.gbUser.Text = "User Authentication";
            // 
            // btnCancel2
            // 
            this.btnCancel2.Location = new System.Drawing.Point(147, 206);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(75, 23);
            this.btnCancel2.TabIndex = 6;
            this.btnCancel2.Text = "Cancel";
            this.btnCancel2.UseVisualStyleBackColor = true;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // btnConnect2
            // 
            this.btnConnect2.Location = new System.Drawing.Point(228, 206);
            this.btnConnect2.Name = "btnConnect2";
            this.btnConnect2.Size = new System.Drawing.Size(75, 23);
            this.btnConnect2.TabIndex = 5;
            this.btnConnect2.Text = "Connect";
            this.btnConnect2.UseVisualStyleBackColor = true;
            this.btnConnect2.Click += new System.EventHandler(this.btnConnect2_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(94, 118);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(205, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(94, 87);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(205, 20);
            this.txtUserID.TabIndex = 4;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(94, 55);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(205, 20);
            this.txtDatabase.TabIndex = 4;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(94, 23);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(205, 20);
            this.txtServer.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "UserID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Database:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server:";
            // 
            // tabIntroduction
            // 
            this.tabIntroduction.Controls.Add(this.tbUserLogIn);
            this.tabIntroduction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabIntroduction.Location = new System.Drawing.Point(0, 0);
            this.tabIntroduction.Name = "tabIntroduction";
            this.tabIntroduction.SelectedIndex = 0;
            this.tabIntroduction.Size = new System.Drawing.Size(388, 284);
            this.tabIntroduction.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "NameSpace:";
            // 
            // txtnamespace
            // 
            this.txtnamespace.Location = new System.Drawing.Point(94, 147);
            this.txtnamespace.Name = "txtnamespace";
            this.txtnamespace.Size = new System.Drawing.Size(205, 20);
            this.txtnamespace.TabIndex = 8;
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 284);
            this.ControlBox = false;
            this.Controls.Add(this.tabIntroduction);
            this.Name = "Input";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input";
            this.Load += new System.EventHandler(this.Input_Load);
            this.tbUserLogIn.ResumeLayout(false);
            this.gbUser.ResumeLayout(false);
            this.gbUser.PerformLayout();
            this.tabIntroduction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tbUserLogIn;
        private System.Windows.Forms.GroupBox gbUser;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Button btnConnect2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabIntroduction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnamespace;


    }
}