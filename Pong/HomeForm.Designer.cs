namespace Pong
{
    partial class HomeForm
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
            this.btnOnePlayer = new System.Windows.Forms.Button();
            this.btnTwoPlayers = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOnePlayer
            // 
            this.btnOnePlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOnePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnePlayer.Location = new System.Drawing.Point(160, 373);
            this.btnOnePlayer.Name = "btnOnePlayer";
            this.btnOnePlayer.Size = new System.Drawing.Size(273, 82);
            this.btnOnePlayer.TabIndex = 0;
            this.btnOnePlayer.Text = "(1) ONE PLAYER";
            this.btnOnePlayer.UseVisualStyleBackColor = true;
            this.btnOnePlayer.Click += new System.EventHandler(this.btnOnePlayer_Click);
            // 
            // btnTwoPlayers
            // 
            this.btnTwoPlayers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTwoPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTwoPlayers.Location = new System.Drawing.Point(160, 484);
            this.btnTwoPlayers.Name = "btnTwoPlayers";
            this.btnTwoPlayers.Size = new System.Drawing.Size(273, 77);
            this.btnTwoPlayers.TabIndex = 1;
            this.btnTwoPlayers.Text = "(2) TWO PLAYERS";
            this.btnTwoPlayers.UseVisualStyleBackColor = true;
            this.btnTwoPlayers.Click += new System.EventHandler(this.btnTwoPlayers_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pong.Properties.Resources.pong_logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(583, 355);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(607, 606);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnTwoPlayers);
            this.Controls.Add(this.btnOnePlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pong 2021";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOnePlayer;
        private System.Windows.Forms.Button btnTwoPlayers;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}