namespace Halo_Streamer_Tools
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_gamertag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startStop = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_kills = new System.Windows.Forms.Label();
            this.lbl_wins = new System.Windows.Forms.Label();
            this.lbl_winstotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_xp = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_tutorial = new System.Windows.Forms.Button();
            this.lbl_headshots = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Halo Streamer Toolkit";
            // 
            // txt_gamertag
            // 
            this.txt_gamertag.Location = new System.Drawing.Point(93, 114);
            this.txt_gamertag.Name = "txt_gamertag";
            this.txt_gamertag.Size = new System.Drawing.Size(226, 23);
            this.txt_gamertag.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(154, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gamertag:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Last Update:";
            // 
            // startStop
            // 
            this.startStop.Location = new System.Drawing.Point(93, 154);
            this.startStop.Name = "startStop";
            this.startStop.Size = new System.Drawing.Size(226, 42);
            this.startStop.TabIndex = 4;
            this.startStop.Text = "Start";
            this.startStop.UseVisualStyleBackColor = true;
            this.startStop.Click += new System.EventHandler(this.startStop_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 33);
            this.label4.TabIndex = 5;
            this.label4.Text = "Stats:";
            // 
            // lbl_kills
            // 
            this.lbl_kills.AutoSize = true;
            this.lbl_kills.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_kills.Location = new System.Drawing.Point(113, 234);
            this.lbl_kills.Name = "lbl_kills";
            this.lbl_kills.Size = new System.Drawing.Size(54, 26);
            this.lbl_kills.TabIndex = 6;
            this.lbl_kills.Text = "Kills:";
            // 
            // lbl_wins
            // 
            this.lbl_wins.AutoSize = true;
            this.lbl_wins.Location = new System.Drawing.Point(105, 504);
            this.lbl_wins.Name = "lbl_wins";
            this.lbl_wins.Size = new System.Drawing.Size(36, 15);
            this.lbl_wins.TabIndex = 7;
            this.lbl_wins.Text = "Wins:";
            // 
            // lbl_winstotal
            // 
            this.lbl_winstotal.AutoSize = true;
            this.lbl_winstotal.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_winstotal.Location = new System.Drawing.Point(113, 272);
            this.lbl_winstotal.Name = "lbl_winstotal";
            this.lbl_winstotal.Size = new System.Drawing.Size(64, 26);
            this.lbl_winstotal.TabIndex = 8;
            this.lbl_winstotal.Text = "Wins:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(398, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // lbl_xp
            // 
            this.lbl_xp.AutoSize = true;
            this.lbl_xp.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_xp.Location = new System.Drawing.Point(113, 353);
            this.lbl_xp.Name = "lbl_xp";
            this.lbl_xp.Size = new System.Drawing.Size(42, 26);
            this.lbl_xp.TabIndex = 10;
            this.lbl_xp.Text = "XP:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Made with 💙 by @FinalNecessity";
            // 
            // btn_tutorial
            // 
            this.btn_tutorial.Location = new System.Drawing.Point(322, 423);
            this.btn_tutorial.Name = "btn_tutorial";
            this.btn_tutorial.Size = new System.Drawing.Size(75, 23);
            this.btn_tutorial.TabIndex = 12;
            this.btn_tutorial.Text = "Tutorial";
            this.btn_tutorial.UseVisualStyleBackColor = true;
            // 
            // lbl_headshots
            // 
            this.lbl_headshots.AutoSize = true;
            this.lbl_headshots.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_headshots.Location = new System.Drawing.Point(113, 311);
            this.lbl_headshots.Name = "lbl_headshots";
            this.lbl_headshots.Size = new System.Drawing.Size(117, 26);
            this.lbl_headshots.TabIndex = 13;
            this.lbl_headshots.Text = "Headshots:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 453);
            this.Controls.Add(this.btn_tutorial);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_xp);
            this.Controls.Add(this.lbl_headshots);
            this.Controls.Add(this.lbl_winstotal);
            this.Controls.Add(this.lbl_kills);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_gamertag);
            this.Controls.Add(this.startStop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_wins);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Halo Streamer Toolkit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_gamertag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startStop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_kills;
        private System.Windows.Forms.Label lbl_wins;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_winstotal;
        private System.Windows.Forms.Label lbl_xp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_tutorial;
        private System.Windows.Forms.Label lbl_headshots;
    }
}

