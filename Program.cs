using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace Game
{

    //1ST WINDOW (GAME MENU)

    public class Program : System.Windows.Forms.Form
    {
        private static PictureBox Charone;
        private static PictureBox Chartwo;
        private static PictureBox Charthree;
        private static PictureBox Charfour;
        private static Label Choosechar1;
        private static Label Choosechar2;
        private static Label Choosechar3;
        private static Label Choosechar4;
        private static Label ChooseTitle;
        private static Label GameTitle;
        private static Label GroupLab;
        private static Label LeaderTitle;
        private static ListBox List1;



        static void Main(string[] args)
        {
            Form StartMenuWindow = new Form();
            StartMenuWindow.MaximizeBox = false;
            StartMenuWindow.MinimizeBox = false;
            StartMenuWindow.Text = "Start Menu";
            StartMenuWindow.StartPosition = FormStartPosition.CenterScreen;
            StartMenuWindow.Width = 900;
            StartMenuWindow.Height = 500;
            StartMenuWindow.Text = "Start Menu";
            StartMenuWindow.BackgroundImage = Image.FromFile(@"Essentials\Bg 1.png");
            StartMenuWindow.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Group Two Title Properties (under the game title)
            GroupLab = new Label();
            GroupLab.Font = new Font("Static Age", 20, FontStyle.Bold);
            GroupLab.BackColor = System.Drawing.Color.Transparent;
            GroupLab.ForeColor = Color.Maroon;
            GroupLab.Text = "Made by Group Two";
            GroupLab.Size = new Size(230, 34);
            GroupLab.Location = new Point(330, 418);
            GroupLab.Parent = StartMenuWindow;

            //Game Title Properties
            GameTitle = new Label();
            GameTitle.Font = new Font("Static Age", 71, FontStyle.Bold);
            GameTitle.BackColor = System.Drawing.Color.Transparent;
            GameTitle.ForeColor = Color.Maroon;
            GameTitle.Text = "Student Survivors";
            GameTitle.Size = new Size(774, 150);
            GameTitle.Location = new Point(105, 80);
            GameTitle.Parent = StartMenuWindow;

            //Start Button Properties
            Button BtnStart = new Button();
            BtnStart.Font = new Font("Static Age", 36, FontStyle.Bold);
            BtnStart.BackColor = Color.SlateGray;
            BtnStart.Text = "Start";
            BtnStart.Location = new System.Drawing.Point(10, 250);
            BtnStart.Width = 250;
            BtnStart.Height = 100;
            BtnStart.Parent = StartMenuWindow;
            BtnStart.Click += new System.EventHandler(BtnStart_Click);

            //Exit Button Properties
            Button BtnExit = new Button();
            BtnExit.Font = new Font("Static Age", 36, FontStyle.Bold);
            BtnExit.BackColor = Color.SlateGray;
            BtnExit.Text = "Exit";
            BtnExit.Location = new System.Drawing.Point(624, 250);
            BtnExit.Width = 250;
            BtnExit.Height = 100;
            BtnExit.Parent = StartMenuWindow;
            BtnExit.Click += new System.EventHandler(BtnExit_Click);

            //LeaderBoard Button Properties
            Button Leaderboard = new Button();
            Leaderboard.Font = new Font("Static Age", 36, FontStyle.Bold);
            Leaderboard.BackColor = Color.SlateGray;
            Leaderboard.Text = "Leaderboard";
            Leaderboard.Location = new System.Drawing.Point(291, 250);
            Leaderboard.Width = 300;
            Leaderboard.Height = 100;
            Leaderboard.Parent = StartMenuWindow;
            Leaderboard.Click += new System.EventHandler(leaderboard_Click);
            StartMenuWindow.ShowDialog();

        }
        static void LeaderBoard()
        {
            //Form Properties (LeaderBoard Window/Form)
            Form Leader = new Form();
            Leader.MaximizeBox = false;
            Leader.MinimizeBox = false;
            Leader.Text = "Leaderboard";
            Leader.StartPosition = FormStartPosition.CenterScreen;
            Leader.Width = 550;
            Leader.Height = 350;
            Leader.Text = "Leaderboard";
            Leader.BackgroundImage = Image.FromFile(@"Essentials\Bg 2.png");
            Leader.FormBorderStyle = FormBorderStyle.FixedSingle;

            //LeaderBoard Title (Top Players)
            LeaderTitle = new Label();
            LeaderTitle.Font = new Font("Static Age", 48, FontStyle.Bold);
            LeaderTitle.BackColor = System.Drawing.Color.Transparent;
            LeaderTitle.ForeColor = Color.Maroon;
            LeaderTitle.Text = "Top Players";
            LeaderTitle.Width = 589;
            LeaderTitle.Height = 65;
            LeaderTitle.Location = new Point(120, 10);
            LeaderTitle.Parent = Leader;

            //Button for showing the leaderboards
            Button sort_b = new Button();
            sort_b.Font = new Font("Static Age", 36, FontStyle.Bold);
            sort_b.BackColor = Color.LightGray;
            sort_b.Text = "SHOW";
            sort_b.Location = new Point(190, 210);
            sort_b.Width = 170;
            sort_b.Height = 77;
            sort_b.Parent = Leader;
            sort_b.Click += new EventHandler(show_Click);

            List1 = new ListBox();
            List1.Location = new Point(150, 70);
            List1.Size = new Size(250, 140);
            List1.Parent = Leader;

            //code for saving the leaderboard to a txt file
            void show_Click(object sender, EventArgs e)
            {
                sort_b.Enabled = false;

                List<ScoreListing> list = new List<ScoreListing>();
                StreamReader txt = new StreamReader("Leaderboard.txt");

                int counter = 0;

                string line;

                var sortedLeaderboard = list.OrderByDescending(l => l.Score);
                while ((line = txt.ReadLine()) != null)
                {
                    var elements = line.Split('|');
                    var listing = new ScoreListing
                    {
                        Score = int.Parse(elements[0]),
                        Text = elements[1]

                    };

                    list.Add(listing);

                    counter++;
                }
                foreach (var item in sortedLeaderboard)
                {
                    List1.Items.Add($"{item.Score} | {item.Text}");
                }

            }
            Leader.ShowDialog();
        }

        //2ND WINDOW (CHARACTER SELECTION)

        static void selectform()
        {
            Form select = new Form();
            select.MaximizeBox = false;
            select.MinimizeBox = false;
            select.Text = "Start Menu";
            select.StartPosition = FormStartPosition.CenterScreen;
            select.Width = 900;
            select.Height = 500;
            select.Text = "Start Menu";
            select.BackgroundImage = Image.FromFile(@"Essentials\Bg 2.png");
            select.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Character Select Title (Choose your Student)
            ChooseTitle = new Label();
            ChooseTitle.Font = new Font("Static Age", 48, FontStyle.Bold);
            ChooseTitle.BackColor = System.Drawing.Color.Transparent;
            ChooseTitle.ForeColor = Color.Maroon;
            ChooseTitle.Text = "Choose your Student";
            ChooseTitle.Width = 589;
            ChooseTitle.Height = 60;
            ChooseTitle.Location = new Point(170, 15);
            ChooseTitle.Parent = select;

            //Character One Properties
            Choosechar1 = new Label();
            Choosechar1.Font = new Font("Static Age", 20, FontStyle.Bold);
            Choosechar1.BackColor = System.Drawing.Color.Transparent;
            Choosechar1.ForeColor = Color.Maroon;
            Choosechar1.Text = "The Normal";
            Choosechar1.Width = 17;
            Choosechar1.Height = 104;
            Choosechar1.Size = new Size(153, 43);
            Choosechar1.Location = new Point(77, 104);
            Choosechar1.Parent = select;

            //Character Two Properties
            Choosechar2 = new Label();
            Choosechar2.Font = new Font("Static Age", 20, FontStyle.Bold);
            Choosechar2.BackColor = System.Drawing.Color.Transparent;
            Choosechar2.ForeColor = Color.Maroon;
            Choosechar2.Text = "The Buff";
            Choosechar2.Size = new Size(115, 43);
            Choosechar2.Location = new Point(289, 104);
            Choosechar2.Parent = select;

            //Character Three Properties
            Choosechar3 = new Label();
            Choosechar3.Font = new Font("Static Age", 20, FontStyle.Bold);
            Choosechar3.BackColor = System.Drawing.Color.Transparent;
            Choosechar3.ForeColor = Color.Maroon;
            Choosechar3.Text = "The Eternal";
            Choosechar3.Size = new Size(154, 43);
            Choosechar3.Location = new Point(475, 104);
            Choosechar3.Parent = select;

            //Character Four Properties
            Choosechar4 = new Label();
            Choosechar4.Font = new Font("Static Age", 20, FontStyle.Bold);
            Choosechar4.BackColor = System.Drawing.Color.Transparent;
            Choosechar4.ForeColor = Color.Maroon;
            Choosechar4.Text = "The Ascendant";
            Choosechar4.Size = new Size(189, 43);
            Choosechar4.Location = new Point(655, 104);
            Choosechar4.Parent = select;


            //CHARACTER PROPERTIES


            //Character One
            Charone = new PictureBox();
            Charone.BackColor = System.Drawing.Color.DimGray;
            Charone.Image = Image.FromFile("CHOOSE UR AGENT.png");
            Charone.Location = new System.Drawing.Point(65, 150);
            Charone.Size = new System.Drawing.Size(150, 180);
            Charone.SizeMode = PictureBoxSizeMode.Zoom;
            Charone.TabIndex = 0;
            Charone.TabStop = false;
            Charone.MouseClick += new MouseEventHandler(Charone_Click);
            Charone.Parent = select;

            //Character Two
            Chartwo = new PictureBox();
            Chartwo.BackColor = System.Drawing.Color.DimGray;
            Chartwo.Image = Image.FromFile("CHOOSE UR AGENT 2.png");
            Chartwo.Location = new System.Drawing.Point(265, 150);
            Chartwo.Size = new System.Drawing.Size(150, 180);
            Chartwo.SizeMode = PictureBoxSizeMode.Zoom;
            Chartwo.TabIndex = 1;
            Chartwo.TabStop = false;
            Chartwo.MouseClick += new MouseEventHandler(Chartwo_Click);
            Chartwo.Parent = select;

            //Chracter Three
            Charthree = new PictureBox();
            Charthree.BackColor = System.Drawing.Color.DimGray;
            Charthree.Image = Image.FromFile("CHOOSE UR AGENT 3.png");
            Charthree.Location = new System.Drawing.Point(465, 150);
            Charthree.Size = new System.Drawing.Size(150, 180);
            Charthree.SizeMode = PictureBoxSizeMode.Zoom;
            Charthree.TabIndex = 2;
            Charthree.TabStop = false;
            Charthree.MouseClick += new MouseEventHandler(Charthree_Click);
            Charthree.Parent = select;

            //Character Four
            Charfour = new PictureBox();
            Charfour.BackColor = System.Drawing.Color.DimGray;
            Charfour.Image = Image.FromFile("CHOOSE UR AGENT 4.png");
            Charfour.Location = new System.Drawing.Point(660, 150);
            Charfour.Name = "Charfour";
            Charfour.Size = new System.Drawing.Size(150, 180);
            Charfour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Charfour.TabIndex = 3;
            Charfour.TabStop = false;
            Charfour.Click += new System.EventHandler(Charfour_Click);
            Charfour.Parent = select;


            //START BUTTON PROPERTIES
            int charSelected = 0;
            Button BtnStartSelect = new Button();
            BtnStartSelect.Font = new Font("Static Age", 36, FontStyle.Bold);
            BtnStartSelect.BackColor = Color.SlateGray;
            BtnStartSelect.Text = "Start";
            BtnStartSelect.Location = new System.Drawing.Point(325, 351);
            BtnStartSelect.Width = 220;
            BtnStartSelect.Height = 77;
            BtnStartSelect.Parent = select;
            BtnStartSelect.Click += new System.EventHandler(strtbttn_Click);
            select.ShowDialog();

            //CLICKING CHARACTER HIGHLIGHTS THE BORDER
            void Charone_Click(object sender, EventArgs e)
            {
                charSelected = 1;
                CharChanged();
            }

            void Chartwo_Click(object sender, EventArgs e)
            {
                charSelected = 2;
                CharChanged();
            }

            void Charthree_Click(object sender, EventArgs e)
            {
                charSelected = 3;
                CharChanged();
            }

            void Charfour_Click(object sender, EventArgs e)
            {
                charSelected = 4;
                CharChanged();
            }

            void CharChanged()
            {
                // The normal
                if (charSelected == 1)
                {
                    Charone.BackColor = Color.LightCyan;
                    Chartwo.BackColor = Color.DimGray;
                    Charthree.BackColor = Color.DimGray;
                    Charfour.BackColor = Color.DimGray;
                    Charone.BorderStyle = BorderStyle.Fixed3D;
                    Chartwo.BorderStyle = BorderStyle.FixedSingle;
                    Charthree.BorderStyle = BorderStyle.FixedSingle;
                    Charfour.BorderStyle = BorderStyle.FixedSingle;
                }
                // The Buff
                else if (charSelected == 2)
                {
                    Chartwo.BackColor = Color.LightCyan;
                    Charone.BackColor = Color.DimGray;
                    Charthree.BackColor = Color.DimGray;
                    Charfour.BackColor = Color.DimGray;
                    Chartwo.BorderStyle = BorderStyle.Fixed3D;
                    Charone.BorderStyle = BorderStyle.FixedSingle;
                    Charthree.BorderStyle = BorderStyle.FixedSingle;
                    Charfour.BorderStyle = BorderStyle.FixedSingle;
                }
                // The Eternal
                else if (charSelected == 3)
                {
                    Charthree.BackColor = Color.LightCyan;
                    Chartwo.BackColor = Color.DimGray;
                    Charone.BackColor = Color.DimGray;
                    Charfour.BackColor = Color.DimGray;
                    Charthree.BorderStyle = BorderStyle.Fixed3D;
                    Chartwo.BorderStyle = BorderStyle.FixedSingle;
                    Charone.BorderStyle = BorderStyle.FixedSingle;
                    Charfour.BorderStyle = BorderStyle.FixedSingle;
                }
                // The Ascendant
                else if (charSelected == 4)
                {
                    Charfour.BackColor = Color.LightCyan;
                    Chartwo.BackColor = Color.DimGray;
                    Charthree.BackColor = Color.DimGray;
                    Charone.BackColor = Color.DimGray;
                    Charfour.BorderStyle = BorderStyle.Fixed3D;
                    Chartwo.BorderStyle = BorderStyle.FixedSingle;
                    Charthree.BorderStyle = BorderStyle.FixedSingle;
                    Charone.BorderStyle = BorderStyle.FixedSingle;

                   
                }
            }
            void strtbttn_Click(object sender, EventArgs e)
            {
                Main_Game mg = new Main_Game(charSelected);
                mg.Show();
             
            }
        }
     
        static void BtnStart_Click(object sender, EventArgs e)
        {
            Program.selectform();
        }
        private static void BtnExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        static void leaderboard_Click(object sender, EventArgs e)
        {
            Program.LeaderBoard();
        }

        public class ScoreListing
        {
            public int Score { get; set; }
            public string Text { get; set; }

        }
        

    }

}