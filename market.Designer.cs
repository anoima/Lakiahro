namespace markettest
{
    partial class Form1
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
            this.startbtn = new System.Windows.Forms.Button();
            this.buylist = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.stopbtn = new System.Windows.Forms.Button();
            this.priceboxmin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.priceboxmax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startbtn
            // 
            this.startbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(68)))), ((int)(((byte)(107)))));
            this.startbtn.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(184)))), ((int)(((byte)(44)))));
            this.startbtn.Location = new System.Drawing.Point(48, 317);
            this.startbtn.Margin = new System.Windows.Forms.Padding(0);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(80, 25);
            this.startbtn.TabIndex = 2;
            this.startbtn.Text = "Start";
            this.startbtn.UseVisualStyleBackColor = false;
            this.startbtn.Click += new System.EventHandler(this.startbtn_Click);
            // 
            // buylist
            // 
            this.buylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(68)))), ((int)(((byte)(107)))));
            this.buylist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buylist.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buylist.ForeColor = System.Drawing.Color.White;
            this.buylist.Location = new System.Drawing.Point(12, 64);
            this.buylist.Multiline = true;
            this.buylist.Name = "buylist";
            this.buylist.ReadOnly = true;
            this.buylist.Size = new System.Drawing.Size(150, 241);
            this.buylist.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(22, 354);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 109);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // stopbtn
            // 
            this.stopbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(68)))), ((int)(((byte)(103)))));
            this.stopbtn.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(184)))), ((int)(((byte)(44)))));
            this.stopbtn.Location = new System.Drawing.Point(48, 317);
            this.stopbtn.Margin = new System.Windows.Forms.Padding(0);
            this.stopbtn.Name = "stopbtn";
            this.stopbtn.Size = new System.Drawing.Size(80, 25);
            this.stopbtn.TabIndex = 8;
            this.stopbtn.Text = "Stop";
            this.stopbtn.UseVisualStyleBackColor = false;
            this.stopbtn.Visible = false;
            this.stopbtn.Click += new System.EventHandler(this.stopbtn_Click);
            // 
            // priceboxmin
            // 
            this.priceboxmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.priceboxmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.priceboxmin.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceboxmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(184)))), ((int)(((byte)(44)))));
            this.priceboxmin.Location = new System.Drawing.Point(34, 13);
            this.priceboxmin.MaxLength = 4;
            this.priceboxmin.Name = "priceboxmin";
            this.priceboxmin.Size = new System.Drawing.Size(94, 23);
            this.priceboxmin.TabIndex = 9;
            this.priceboxmin.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(184)))), ((int)(((byte)(44)))));
            this.label2.Location = new System.Drawing.Point(88, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Millió";
            // 
            // priceboxmax
            // 
            this.priceboxmax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.priceboxmax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.priceboxmax.Font = new System.Drawing.Font("Modern No. 20", 15.75F);
            this.priceboxmax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(184)))), ((int)(((byte)(44)))));
            this.priceboxmax.Location = new System.Drawing.Point(34, 37);
            this.priceboxmax.MaxLength = 4;
            this.priceboxmax.Name = "priceboxmax";
            this.priceboxmax.Size = new System.Drawing.Size(80, 23);
            this.priceboxmax.TabIndex = 11;
            this.priceboxmax.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(184)))), ((int)(((byte)(44)))));
            this.label1.Location = new System.Drawing.Point(88, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "Millió";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(175, 502);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.priceboxmax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.priceboxmin);
            this.Controls.Add(this.stopbtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buylist);
            this.Controls.Add(this.startbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startbtn;
        private System.Windows.Forms.TextBox buylist;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button stopbtn;
        private System.Windows.Forms.TextBox priceboxmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox priceboxmax;
        private System.Windows.Forms.Label label1;
    }
}

