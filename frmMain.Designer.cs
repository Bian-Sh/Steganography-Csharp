namespace Steganography
{
    partial class frmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSaveCodedPic = new System.Windows.Forms.Button();
            this.tbInputText_filepath = new System.Windows.Forms.TextBox();
            this.btnOpenOriginalPic = new System.Windows.Forms.Button();
            this.pbOriginalPic = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenCodedPic = new System.Windows.Forms.Button();
            this.btnReadTextFromPic = new System.Windows.Forms.Button();
            this.password_text_dec = new System.Windows.Forms.TextBox();
            this.pbOpenedCodedPic = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.password_text_enc = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalPic)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenedCodedPic)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.password_text_enc);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnSaveCodedPic);
            this.groupBox1.Controls.Add(this.tbInputText_filepath);
            this.groupBox1.Controls.Add(this.btnOpenOriginalPic);
            this.groupBox1.Controls.Add(this.pbOriginalPic);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 518);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encoder";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 358);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "请选择一个文件：";
            // 
            // btnSaveCodedPic
            // 
            this.btnSaveCodedPic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSaveCodedPic.Location = new System.Drawing.Point(139, 467);
            this.btnSaveCodedPic.Name = "btnSaveCodedPic";
            this.btnSaveCodedPic.Size = new System.Drawing.Size(135, 42);
            this.btnSaveCodedPic.TabIndex = 27;
            this.btnSaveCodedPic.Text = "Process and save";
            this.btnSaveCodedPic.UseVisualStyleBackColor = true;
            this.btnSaveCodedPic.Click += new System.EventHandler(this.btnSaveCodedPic_Click);
            // 
            // tbInputText_filepath
            // 
            this.tbInputText_filepath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tbInputText_filepath.Location = new System.Drawing.Point(9, 373);
            this.tbInputText_filepath.Name = "tbInputText_filepath";
            this.tbInputText_filepath.Size = new System.Drawing.Size(301, 29);
            this.tbInputText_filepath.TabIndex = 2;
            this.tbInputText_filepath.Text = "path of a file";
            // 
            // btnOpenOriginalPic
            // 
            this.btnOpenOriginalPic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOpenOriginalPic.Location = new System.Drawing.Point(109, 15);
            this.btnOpenOriginalPic.Name = "btnOpenOriginalPic";
            this.btnOpenOriginalPic.Size = new System.Drawing.Size(75, 21);
            this.btnOpenOriginalPic.TabIndex = 1;
            this.btnOpenOriginalPic.Text = "Open Image";
            this.btnOpenOriginalPic.UseVisualStyleBackColor = true;
            this.btnOpenOriginalPic.Click += new System.EventHandler(this.btnOpenOriginalPic_Click);
            // 
            // pbOriginalPic
            // 
            this.pbOriginalPic.Location = new System.Drawing.Point(9, 42);
            this.pbOriginalPic.Name = "pbOriginalPic";
            this.pbOriginalPic.Size = new System.Drawing.Size(398, 290);
            this.pbOriginalPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOriginalPic.TabIndex = 0;
            this.pbOriginalPic.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnOpenCodedPic);
            this.groupBox2.Controls.Add(this.btnReadTextFromPic);
            this.groupBox2.Controls.Add(this.password_text_dec);
            this.groupBox2.Controls.Add(this.pbOpenedCodedPic);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(439, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 518);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Decoder";
            // 
            // btnOpenCodedPic
            // 
            this.btnOpenCodedPic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOpenCodedPic.Location = new System.Drawing.Point(211, 15);
            this.btnOpenCodedPic.Name = "btnOpenCodedPic";
            this.btnOpenCodedPic.Size = new System.Drawing.Size(75, 21);
            this.btnOpenCodedPic.TabIndex = 29;
            this.btnOpenCodedPic.Text = "Open Image";
            this.btnOpenCodedPic.UseVisualStyleBackColor = true;
            this.btnOpenCodedPic.Click += new System.EventHandler(this.btnOpenCodedPic_Click);
            // 
            // btnReadTextFromPic
            // 
            this.btnReadTextFromPic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReadTextFromPic.Location = new System.Drawing.Point(181, 467);
            this.btnReadTextFromPic.Name = "btnReadTextFromPic";
            this.btnReadTextFromPic.Size = new System.Drawing.Size(135, 42);
            this.btnReadTextFromPic.TabIndex = 30;
            this.btnReadTextFromPic.Text = "Read file From Image";
            this.btnReadTextFromPic.UseVisualStyleBackColor = true;
            this.btnReadTextFromPic.Click += new System.EventHandler(this.btnReadDataFromPic_Click);
            // 
            // password_text_dec
            // 
            this.password_text_dec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.password_text_dec.Location = new System.Drawing.Point(168, 421);
            this.password_text_dec.Name = "password_text_dec";
            this.password_text_dec.PasswordChar = '*';
            this.password_text_dec.Size = new System.Drawing.Size(148, 29);
            this.password_text_dec.TabIndex = 29;
            this.password_text_dec.UseSystemPasswordChar = true;
            // 
            // pbOpenedCodedPic
            // 
            this.pbOpenedCodedPic.Location = new System.Drawing.Point(23, 44);
            this.pbOpenedCodedPic.Name = "pbOpenedCodedPic";
            this.pbOpenedCodedPic.Size = new System.Drawing.Size(452, 290);
            this.pbOpenedCodedPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOpenedCodedPic.TabIndex = 0;
            this.pbOpenedCodedPic.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.78801F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.21199F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(933, 524);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(933, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(54, 21);
            this.aboutToolStripMenuItem.Text = "about";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Select File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "密码：";
            // 
            // password_text_enc
            // 
            this.password_text_enc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.password_text_enc.Location = new System.Drawing.Point(139, 421);
            this.password_text_enc.Name = "password_text_enc";
            this.password_text_enc.PasswordChar = '*';
            this.password_text_enc.Size = new System.Drawing.Size(148, 29);
            this.password_text_enc.TabIndex = 32;
            this.password_text_enc.UseSystemPasswordChar = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 549);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steganography";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalPic)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenedCodedPic)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbOriginalPic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbOpenedCodedPic;
        private System.Windows.Forms.Button btnOpenOriginalPic;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbInputText_filepath;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnSaveCodedPic;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnOpenCodedPic;
        private System.Windows.Forms.Button btnReadTextFromPic;
        private System.Windows.Forms.TextBox password_text_dec;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password_text_enc;
    }
}

