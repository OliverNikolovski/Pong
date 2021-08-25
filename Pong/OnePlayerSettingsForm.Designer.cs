namespace Pong
{
    partial class OnePlayerSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbDifficulty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTargetScore = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pbSkey = new System.Windows.Forms.PictureBox();
            this.pbWkey = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pbPkey = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSkey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWkey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPkey)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(114, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Difficulty:";
            // 
            // cbDifficulty
            // 
            this.cbDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDifficulty.ForeColor = System.Drawing.Color.Black;
            this.cbDifficulty.FormattingEnabled = true;
            this.cbDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard",
            "Impossible"});
            this.cbDifficulty.Location = new System.Drawing.Point(276, 31);
            this.cbDifficulty.Name = "cbDifficulty";
            this.cbDifficulty.Size = new System.Drawing.Size(160, 33);
            this.cbDifficulty.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(72, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Target score:";
            // 
            // nudTargetScore
            // 
            this.nudTargetScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTargetScore.Location = new System.Drawing.Point(276, 104);
            this.nudTargetScore.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTargetScore.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTargetScore.Name = "nudTargetScore";
            this.nudTargetScore.Size = new System.Drawing.Size(160, 31);
            this.nudTargetScore.TabIndex = 3;
            this.nudTargetScore.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(454, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "(score to win)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(224, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 37);
            this.label4.TabIndex = 5;
            this.label4.Text = "Controls:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(67, 391);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(264, 25);
            this.label8.TabIndex = 9;
            this.label8.Text = "You control the left paddle";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(67, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(381, 25);
            this.label9.TabIndex = 10;
            this.label9.Text = "The computer controls the right paddle";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(67, 464);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 25);
            this.label10.TabIndex = 11;
            this.label10.Text = "Good Luck!";
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(183, 510);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(196, 60);
            this.btnPlay.TabIndex = 12;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pbSkey
            // 
            this.pbSkey.Image = global::Pong.Properties.Resources.S_key;
            this.pbSkey.Location = new System.Drawing.Point(78, 291);
            this.pbSkey.Name = "pbSkey";
            this.pbSkey.Size = new System.Drawing.Size(68, 56);
            this.pbSkey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSkey.TabIndex = 24;
            this.pbSkey.TabStop = false;
            // 
            // pbWkey
            // 
            this.pbWkey.Image = global::Pong.Properties.Resources.W_key;
            this.pbWkey.Location = new System.Drawing.Point(78, 213);
            this.pbWkey.Name = "pbWkey";
            this.pbWkey.Size = new System.Drawing.Size(68, 56);
            this.pbWkey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWkey.TabIndex = 23;
            this.pbWkey.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(152, 305);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 25);
            this.label11.TabIndex = 22;
            this.label11.Text = "Move DOWN";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(152, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 25);
            this.label12.TabIndex = 21;
            this.label12.Text = "Move UP";
            // 
            // pbPkey
            // 
            this.pbPkey.Image = global::Pong.Properties.Resources.P_key;
            this.pbPkey.Location = new System.Drawing.Point(337, 249);
            this.pbPkey.Name = "pbPkey";
            this.pbPkey.Size = new System.Drawing.Size(68, 56);
            this.pbPkey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPkey.TabIndex = 26;
            this.pbPkey.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(411, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 31);
            this.label5.TabIndex = 25;
            this.label5.Text = "Pause";
            // 
            // OnePlayerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(607, 606);
            this.Controls.Add(this.pbPkey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbSkey);
            this.Controls.Add(this.pbWkey);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudTargetScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDifficulty);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OnePlayerSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pong 2021";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnePlayerSettingsForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSkey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWkey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPkey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDifficulty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTargetScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.PictureBox pbSkey;
        private System.Windows.Forms.PictureBox pbWkey;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pbPkey;
        private System.Windows.Forms.Label label5;
    }
}