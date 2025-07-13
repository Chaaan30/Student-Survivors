using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Game
{
    partial class Main_Game : System.Windows.Forms.Form
    {
        //Variables/Functions
        private Label label1 = new Label();
        private Label txtScore = new Label();
        private Label txtAmmo = new Label();
        private ProgressBar healthBar = new ProgressBar();
        private Timer GameTimer = new Timer();
        private PictureBox player = new PictureBox();


        private void Gamescreen_Menu()
        {
            //health label Properties
            this.label1.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.label1.BackColor = Color.Transparent;
            this.label1.ForeColor = Color.White;
            this.label1.Text = "Mental Health: ";
            this.label1.Size = new Size(189, 43);
            this.label1.Location = new Point(0, 10);

            //healthbar (Progress Bar)
            this.healthBar.Location = new Point(185, 11);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new Size(213, 23);
            this.healthBar.TabIndex = 3;
            this.healthBar.Value = 100;

            //Score of the player (Kills)
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.txtScore.ForeColor = Color.White;
            this.txtScore.Location = new Point(1100, 10);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new Size(175, 30);
            this.txtScore.TabIndex = 1;
            this.txtScore.Text = "Accomplishments: ";

            //Ammo of the player (Knowledge)
            this.txtAmmo.AutoSize = true;
            this.txtAmmo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.txtAmmo.ForeColor = Color.White;
            this.txtAmmo.Location = new Point(1100, 45);
            this.txtAmmo.Name = "txtAmmo";
            this.txtAmmo.Size = new Size(111, 30);
            this.txtAmmo.TabIndex = 0;
            this.txtAmmo.Text = "Knowledge: ";

            //GameTimer Properties (Bullet)
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new EventHandler(MainTimerEvent);

            //Player Properties
            this.player.Location = new Point(630, 330);
            this.player.Name = "player";
            this.player.Size = new Size(110, 110);
            this.player.SizeMode = PictureBoxSizeMode.Zoom;
            this.player.TabIndex = 4;
            this.player.TabStop = false;

            this.Controls.Add(player);
            this.Controls.Add(healthBar);
            this.Controls.Add(label1);
            this.Controls.Add(txtScore);
            this.Controls.Add(txtAmmo);

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown1);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp1);

            ((System.ComponentModel.ISupportInitialize)(player)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();


            //3RD WINDOW (MAIN GAME)


            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.DimGray;
            this.ClientSize = new Size(1400, 800);
            this.Name = "Main_Game";
            this.Text = "Student Survivors";
        }

    }
}
