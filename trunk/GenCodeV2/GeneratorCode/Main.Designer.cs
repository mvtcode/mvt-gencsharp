namespace GenCsharp
{
    partial class Main
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveClass = new System.Windows.Forms.Button();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveALL = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rtprocedure = new System.Windows.Forms.RichTextBox();
            this.Entity = new System.Windows.Forms.TabPage();
            this.rtxtClass = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnChonThuMuc = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.rtData = new System.Windows.Forms.RichTextBox();
            this.tabPage3.SuspendLayout();
            this.Entity.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tables";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Class View:";
            // 
            // btnSaveClass
            // 
            this.btnSaveClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClass.Location = new System.Drawing.Point(465, 45);
            this.btnSaveClass.Name = "btnSaveClass";
            this.btnSaveClass.Size = new System.Drawing.Size(120, 23);
            this.btnSaveClass.TabIndex = 3;
            this.btnSaveClass.Text = "Save Class File";
            this.btnSaveClass.UseVisualStyleBackColor = true;
            this.btnSaveClass.Click += new System.EventHandler(this.btnSaveClass_Click);
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "*.cs | C Sharp Source File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(328, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Generate Code Utility";
            // 
            // btnSaveALL
            // 
            this.btnSaveALL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveALL.Location = new System.Drawing.Point(725, 45);
            this.btnSaveALL.Name = "btnSaveALL";
            this.btnSaveALL.Size = new System.Drawing.Size(120, 23);
            this.btnSaveALL.TabIndex = 6;
            this.btnSaveALL.Text = "Save ALL";
            this.btnSaveALL.UseVisualStyleBackColor = true;
            this.btnSaveALL.Click += new System.EventHandler(this.btnSaveALL_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rtprocedure);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(703, 401);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "StoreProcedure";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rtprocedure
            // 
            this.rtprocedure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtprocedure.Location = new System.Drawing.Point(3, 3);
            this.rtprocedure.Name = "rtprocedure";
            this.rtprocedure.Size = new System.Drawing.Size(697, 395);
            this.rtprocedure.TabIndex = 5;
            this.rtprocedure.Text = "";
            // 
            // Entity
            // 
            this.Entity.Controls.Add(this.rtxtClass);
            this.Entity.Location = new System.Drawing.Point(4, 22);
            this.Entity.Name = "Entity";
            this.Entity.Padding = new System.Windows.Forms.Padding(3);
            this.Entity.Size = new System.Drawing.Size(703, 401);
            this.Entity.TabIndex = 0;
            this.Entity.Text = "Entity";
            this.Entity.UseVisualStyleBackColor = true;
            // 
            // rtxtClass
            // 
            this.rtxtClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtClass.Location = new System.Drawing.Point(3, 3);
            this.rtxtClass.Name = "rtxtClass";
            this.rtxtClass.Size = new System.Drawing.Size(697, 395);
            this.rtxtClass.TabIndex = 3;
            this.rtxtClass.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Entity);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(138, 74);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(711, 427);
            this.tabControl1.TabIndex = 4;
            // 
            // btnChonThuMuc
            // 
            this.btnChonThuMuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChonThuMuc.Location = new System.Drawing.Point(607, 45);
            this.btnChonThuMuc.Name = "btnChonThuMuc";
            this.btnChonThuMuc.Size = new System.Drawing.Size(109, 23);
            this.btnChonThuMuc.TabIndex = 7;
            this.btnChonThuMuc.Text = "Chọn thư mục";
            this.btnChonThuMuc.UseVisualStyleBackColor = true;
            this.btnChonThuMuc.Click += new System.EventHandler(this.btnChonThuMuc_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 77);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 424);
            this.checkedListBox1.TabIndex = 8;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rtData);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(703, 401);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Data";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // rtData
            // 
            this.rtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtData.Location = new System.Drawing.Point(0, 0);
            this.rtData.Name = "rtData";
            this.rtData.Size = new System.Drawing.Size(703, 401);
            this.rtData.TabIndex = 6;
            this.rtData.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 513);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnChonThuMuc);
            this.Controls.Add(this.btnSaveALL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSaveClass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Code";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabPage3.ResumeLayout(false);
            this.Entity.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveClass;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveALL;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox rtprocedure;
        private System.Windows.Forms.TabPage Entity;
        private System.Windows.Forms.RichTextBox rtxtClass;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnChonThuMuc;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox rtData;
    }
}