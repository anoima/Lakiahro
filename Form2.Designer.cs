namespace trainingapp
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
            this.mapimage = new System.Windows.Forms.PictureBox();
            this.rewardpanel = new System.Windows.Forms.PictureBox();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.roundtext = new System.Windows.Forms.Label();
            this.percenttext = new System.Windows.Forms.Label();
            this.floorpicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardpanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorpicture)).BeginInit();
            this.SuspendLayout();
            // 
            // mapimage
            // 
            this.mapimage.Location = new System.Drawing.Point(12, 40);
            this.mapimage.Name = "mapimage";
            this.mapimage.Size = new System.Drawing.Size(624, 624);
            this.mapimage.TabIndex = 0;
            this.mapimage.TabStop = false;
            this.mapimage.Click += new System.EventHandler(this.mapimage_Click);
            this.mapimage.Paint += new System.Windows.Forms.PaintEventHandler(this.mapimage_Paint);
            // 
            // rewardpanel
            // 
            this.rewardpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.rewardpanel.Location = new System.Drawing.Point(651, 40);
            this.rewardpanel.Name = "rewardpanel";
            this.rewardpanel.Size = new System.Drawing.Size(190, 624);
            this.rewardpanel.TabIndex = 1;
            this.rewardpanel.TabStop = false;
            this.rewardpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.rewardpanel_Paint);
            // 
            // roundtext
            // 
            this.roundtext.AutoSize = true;
            this.roundtext.Location = new System.Drawing.Point(666, 54);
            this.roundtext.Name = "roundtext";
            this.roundtext.Size = new System.Drawing.Size(35, 13);
            this.roundtext.TabIndex = 2;
            this.roundtext.Text = "label1";
            // 
            // percenttext
            // 
            this.percenttext.AutoSize = true;
            this.percenttext.Location = new System.Drawing.Point(746, 310);
            this.percenttext.Name = "percenttext";
            this.percenttext.Size = new System.Drawing.Size(35, 13);
            this.percenttext.TabIndex = 3;
            this.percenttext.Text = "label1";
            // 
            // floorpicture
            // 
            this.floorpicture.Location = new System.Drawing.Point(218, 207);
            this.floorpicture.Name = "floorpicture";
            this.floorpicture.Size = new System.Drawing.Size(200, 200);
            this.floorpicture.TabIndex = 4;
            this.floorpicture.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(850, 700);
            this.ControlBox = false;
            this.Controls.Add(this.floorpicture);
            this.Controls.Add(this.percenttext);
            this.Controls.Add(this.roundtext);
            this.Controls.Add(this.rewardpanel);
            this.Controls.Add(this.mapimage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gathering";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.mapimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardpanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorpicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mapimage;
        private System.Windows.Forms.PictureBox rewardpanel;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Label roundtext;
        private System.Windows.Forms.Label percenttext;
        private System.Windows.Forms.PictureBox floorpicture;
    }
}

