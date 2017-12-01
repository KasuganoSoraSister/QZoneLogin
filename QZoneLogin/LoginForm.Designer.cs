namespace QZoneLogin
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
            this.components = new System.ComponentModel.Container();
            this.QQacount = new System.Windows.Forms.Label();
            this.QQPass = new System.Windows.Forms.Label();
            this.QQ_acount_box = new System.Windows.Forms.TextBox();
            this.QQ_pass_box = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Vericode_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Return_box = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // QQacount
            // 
            this.QQacount.AutoSize = true;
            this.QQacount.Location = new System.Drawing.Point(26, 29);
            this.QQacount.Name = "QQacount";
            this.QQacount.Size = new System.Drawing.Size(29, 12);
            this.QQacount.TabIndex = 0;
            this.QQacount.Text = "QQ号";
            // 
            // QQPass
            // 
            this.QQPass.AutoSize = true;
            this.QQPass.Location = new System.Drawing.Point(26, 63);
            this.QQPass.Name = "QQPass";
            this.QQPass.Size = new System.Drawing.Size(29, 12);
            this.QQPass.TabIndex = 0;
            this.QQPass.Text = "密码";
            // 
            // QQ_acount_box
            // 
            this.QQ_acount_box.Location = new System.Drawing.Point(74, 26);
            this.QQ_acount_box.Name = "QQ_acount_box";
            this.QQ_acount_box.Size = new System.Drawing.Size(124, 21);
            this.QQ_acount_box.TabIndex = 1;
            this.QQ_acount_box.TextChanged += new System.EventHandler(this.QQ_acount_box_TextChanged);
            this.QQ_acount_box.Leave += new System.EventHandler(this.QQ_acount_box_Leave_1);
            // 
            // QQ_pass_box
            // 
            this.QQ_pass_box.Location = new System.Drawing.Point(74, 61);
            this.QQ_pass_box.Name = "QQ_pass_box";
            this.QQ_pass_box.PasswordChar = '*';
            this.QQ_pass_box.Size = new System.Drawing.Size(124, 21);
            this.QQ_pass_box.TabIndex = 1;
            this.QQ_pass_box.TextChanged += new System.EventHandler(this.QQ_pass_box_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Vericode_box);
            this.panel1.Controls.Add(this.QQ_pass_box);
            this.panel1.Controls.Add(this.QQ_acount_box);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.QQPass);
            this.panel1.Controls.Add(this.QQacount);
            this.panel1.Location = new System.Drawing.Point(17, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 124);
            this.panel1.TabIndex = 2;
            // 
            // Vericode_box
            // 
            this.Vericode_box.Location = new System.Drawing.Point(75, 92);
            this.Vericode_box.Name = "Vericode_box";
            this.Vericode_box.Size = new System.Drawing.Size(122, 21);
            this.Vericode_box.TabIndex = 2;
            this.Vericode_box.TextChanged += new System.EventHandler(this.Vericode_box_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "验证码";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Return_box
            // 
            this.Return_box.Location = new System.Drawing.Point(12, 191);
            this.Return_box.Name = "Return_box";
            this.Return_box.Size = new System.Drawing.Size(268, 67);
            this.Return_box.TabIndex = 4;
            this.Return_box.Text = "";
            this.Return_box.TextChanged += new System.EventHandler(this.Return_box_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(17, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 49);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(290, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 82);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 308);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(324, 21);
            this.textBox1.TabIndex = 7;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 341);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Return_box);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "LoginForm";
            this.Text = "MyQzone";
            this.Activated += new System.EventHandler(this.LoginForm_Activated);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QQacount;
        private System.Windows.Forms.Label QQPass;
        private System.Windows.Forms.TextBox QQ_acount_box;
        private System.Windows.Forms.TextBox QQ_pass_box;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Vericode_box;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox Return_box;
        private System.Windows.Forms.TextBox textBox1;
    }
}