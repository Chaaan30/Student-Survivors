using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Game
{
    partial class Main_Game : Form
    {
        //VARIABLES
        int charSelected;
        bool goLeft, goRight, goUp, goDown, gameOver;
        string facing = "up";
        int playerHealth = 100;
        int speed = 12;
        int ammo = 10;
        int profSpeed = 4;
        Random randNum = new Random();
        int score;
        private TextBox username = new TextBox();
        private Label userplayer;
        private Label Gamefin;
        List<PictureBox> profList = new List<PictureBox>();



        public Main_Game(int choice)
        {
            Gamescreen_Menu();
            RestartGame();
            charSelected = choice; //By choosing the Character the Character gets imported into the game
            
        }

        //MainTimerEvent
        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (playerHealth > 1)
            {
                healthBar.Value = playerHealth;
            }
            else
            {
                gameOver = true;
                player.Image = Image.FromFile("dead.png"); //dead picture of the player dead.png
                GameTimer.Stop();


                //4TH WINDOW (GAME OVER)


                Form GO = new Form();
                GO.MaximizeBox = false;
                GO.MinimizeBox = false;
                GO.StartPosition = FormStartPosition.CenterScreen;
                GO.Width = 500;
                GO.Height = 300;
                GO.Text = "GAME ENDING";
                GO.BackgroundImage = Image.FromFile(@"Essentials\Bg 1.png");
                GO.FormBorderStyle = FormBorderStyle.FixedSingle;

                Gamefin = new Label();
                Gamefin.Font = new Font("Segoe UI", 32, FontStyle.Bold);
                Gamefin.BackColor = System.Drawing.Color.Transparent;
                Gamefin.ForeColor = Color.Maroon;
                Gamefin.Text = "GAMEOVER!!!";
                Gamefin.Size = new Size(500, 50);
                Gamefin.Location = new Point(75, 20);
                Gamefin.BackColor = Color.Transparent;
                Gamefin.Parent = GO;

                userplayer = new Label();
                userplayer.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                userplayer.BackColor = System.Drawing.Color.Transparent;
                userplayer.ForeColor = Color.Maroon;
                userplayer.Text = "Enter Name:";
                userplayer.Size = new Size(120, 34);
                userplayer.Location = new Point(20, 117);
                userplayer.Parent = GO;

                username.AutoSize = true;
                username.BackColor = Color.White;
                username.Font = new Font("Segoe UI", 10, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                username.Location = new Point(140, 114);
                username.Size = new Size(200, 120);
                username.TabIndex = 6;
                username.Parent = GO;

                Button getname = new Button();
                getname.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                getname.BackColor = Color.SlateGray;
                getname.Text = "Enter";
                getname.Location = new Point(350, 113);
                getname.Width = 100;
                getname.Height = 28;
                getname.Click += new EventHandler(getname_Click);
                getname.Parent = GO;
                GO.ShowDialog();  
            }
            
            //IN-GAME PROPERTIES
            txtAmmo.Text = "Knowledge: " + ammo; //ammo
            txtScore.Text = "Accomplishments: " + score; //kills

            if (goLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            if (goUp == true && player.Top > 85)
            {
                player.Top -= speed;
            }
            if (goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }

            //WHEN PLAYER TOUCHES THE AMMO, THE AMMO REPLENISHES BY 5
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;
                    }
                }

                //WHEN PLAYER GOT INTERSECTED WITH THE PROF, THE PLAYER'S HEALTH DEPLETES
                if (x is PictureBox && (string)x.Tag == "prof")
                {

                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 1;
                    }

                    if (x.Left > player.Left)
                    {
                        x.Left -= profSpeed;
                        ((PictureBox)x).Image = Image.FromFile("pleft.png"); //picture of the professor facing left
                    }

                    if (x.Left < player.Left)
                    {
                        x.Left += profSpeed;
                        ((PictureBox)x).Image = Image.FromFile("pright.png"); //picture of the professor facing right
                    }

                    if (x.Top > player.Top)
                    {
                        x.Top -= profSpeed;
                        ((PictureBox)x).Image = Image.FromFile("pup.png"); //picture of the professor facing up
                    }

                    if (x.Top < player.Top)
                    {
                        x.Top += profSpeed;
                        ((PictureBox)x).Image = Image.FromFile("pdown.png"); //picture of the professor facing down
                    }
                }

                //WHEN THE PROF GOT HIT BY THE BULLET THE PROF DISAPPEARS
                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "prof")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;

                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            profList.Remove(((PictureBox)x));
                            MakeProf();
                        }
                    }
                }
            }
        }

        //HOW THE CHARACTER GETS IMPORTED INTO THE GAME
        private void KeyIsDown1(object sender, KeyEventArgs e)
        {
            if (gameOver == true)
            {
                return;
            }
            if (charSelected == 1)
            {
                if (e.KeyCode == Keys.Left)
                {
                    goLeft = true;
                    facing = "left";
                    player.Image = Image.FromFile(@"Sprite elijah\left.gif"); ; //(name of the file of which the (character).gif is facing)
                }

                if (e.KeyCode == Keys.Right)
                {
                    goRight = true;
                    facing = "right";
                    player.Image = Image.FromFile(@"Sprite elijah\right.gif"); //(name of the file of which the (character).gif is facing)
                }

                if (e.KeyCode == Keys.Up)
                {
                    goUp = true;
                    facing = "up";
                    player.Image = Image.FromFile(@"Sprite elijah\up.gif"); //(name of the file of which the (character).gif is facing)
                }

                if (e.KeyCode == Keys.Down)
                {
                    goDown = true;
                    facing = "down";
                    player.Image = Image.FromFile(@"Sprite elijah\down.gif"); //(name of the file of which the (character).gif is facing)
                }
            }
            else if (charSelected == 2)
            {
                if (e.KeyCode == Keys.Left)
                {
                    goLeft = true;
                    facing = "left";
                    player.Image = Image.FromFile(@"Sprite Rianne\left.gif"); ; //(name of the file of which the (character).gif is facing)
                }

                if (e.KeyCode == Keys.Right)
                {
                    goRight = true;
                    facing = "right";
                    player.Image = Image.FromFile(@"Sprite Rianne\right.gif"); //(name of the file of which the (character).gif is facing)
                }

                if (e.KeyCode == Keys.Up)
                {
                    goUp = true;
                    facing = "up";
                    player.Image = Image.FromFile(@"Sprite Rianne\up.gif"); //(name of the file of which the (character).gif is facing)
                }

                if (e.KeyCode == Keys.Down)
                {
                    goDown = true;
                    facing = "down";
                    player.Image = Image.FromFile(@"Sprite Rianne\down.gif"); //(name of the file of which the (character).gif is facing)
                }
            }
            else if (charSelected == 3)
            {
                if (e.KeyCode == Keys.Left)
                {
                    goLeft = true;
                    facing = "left";
                    player.Image = Image.FromFile("left.gif"); ; //(name of the file of which the (character).gif is facing)
                }

                if (e.KeyCode == Keys.Right)
                {
                    goRight = true;
                    facing = "right";
                    player.Image = Image.FromFile("right.gif"); //(name of the file of which the (character).gif is facing)
                }

                if (e.KeyCode == Keys.Up)
                {
                    goUp = true;
                    facing = "up";
                    player.Image = Image.FromFile("up.gif"); //(name of the file of which the (character).gif is facing)
                }

                if (e.KeyCode == Keys.Down)
                {
                    goDown = true;
                    facing = "down";
                    player.Image = Image.FromFile("down.gif"); //(name of the file of which the (character).gif is facing)
                }
            }
            else if (charSelected == 4)
            {

                if (e.KeyCode == Keys.Left)
                {
                    goLeft = true;
                    facing = "left";
                    player.Image = Image.FromFile(@"Sprite Ascendant\left.gif"); ; //(name of the file of which the (character).gif is facing)
                }

                if (e.KeyCode == Keys.Right)
                {
                    goRight = true;
                    facing = "right";
                    player.Image = Image.FromFile(@"Sprite Ascendant\right.gif"); //(name of the file of which the (character).gif is facing)
                }

                if (e.KeyCode == Keys.Up)
                {
                    goUp = true;
                    facing = "up";
                    player.Image = Image.FromFile(@"Sprite Ascendant\up.gif"); //(name of the file of which the (character).gif is facing)
                }

                if (e.KeyCode == Keys.Down)
                {
                    goDown = true;
                    facing = "down";
                    player.Image = Image.FromFile(@"Sprite Ascendant\down.gif"); //(name of the file of which the (character).gif is facing)
                }
            }
        }

        private void KeyIsUp1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.Space && ammo > 0 && gameOver == false)
            {
                ammo--;
                ShootBullet(facing);

                if (ammo < 1)
                {
                    DropAmmo();
                }
            }

            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }
        }

        private void getname_Click(object sender, EventArgs e)
        {
            string user = username.Text.Trim();
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Please enter a valid username.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (StreamWriter writer = new StreamWriter("Leaderboard.txt", true))
            {
                writer.WriteLine(score + "|" + user);
            }
            for (int i = Application.OpenForms.Count - 1; i >= 1; i--)
            {
                if (Application.OpenForms[i].Name != "StartMenuWindow")
                {
                    Application.OpenForms[i].Close();
                }
            }
        }

        //THE BULLET SPAWNS WHERE THE PLAYER IS LOOKING
        private void ShootBullet(string direction)
        {
            bullet shootBullet = new bullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.MakeBullet(this);
        }

        //PROF PROPERTIES
        private void MakeProf()
        {
            PictureBox prof = new PictureBox();
            prof.Tag = "prof";
            prof.Image = Image.FromFile("pdown.png"); //picture of the prof facing down (pdown.png)
            prof.Left = randNum.Next(0, 1400); //how far the prof will spawn
            prof.Top = randNum.Next(0, 800);
            prof.Size = new Size(110, 110); //size of the prof
            prof.SizeMode = PictureBoxSizeMode.Zoom;
            profList.Add(prof);
            this.Controls.Add(prof);
            player.BringToFront(); //overlaps the player
        }
        
        //AMMO PROPERTIES
        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Image.FromFile(@"Essentials\ammo_Image.png"); //ammo image (book)
            ammo.SizeMode = PictureBoxSizeMode.Zoom;
            ammo.Size = new Size(50, 50); //size of the ammo
            ammo.Left = randNum.Next(40, this.ClientSize.Width - ammo.Width);
            ammo.Top = randNum.Next(40, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);

            ammo.BringToFront();
            player.BringToFront();
        }

        private void RestartGame()
        {
            player.Image = Image.FromFile("playeruwu.gif"); //picture of the player facing up

            foreach (PictureBox i in profList)
            {
                this.Controls.Remove(i);
            }

            profList.Clear();

            for (int i = 0; i < 2; i++) //How many profs will spawn i = prof
            {
                MakeProf();
            }

            //movement when true the character continues to move
            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;
            gameOver = false;

            playerHealth = 100; //player health value
            score = 0; //score starts at 0
            ammo = 15; //ammo starts at 10

            GameTimer.Start();
        }
    }   
}