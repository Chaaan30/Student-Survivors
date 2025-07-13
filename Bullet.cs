using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    class bullet
    {

        //variable

        public string direction; 
        public int speed = 30; 
        PictureBox Bullet = new PictureBox(); 
        Timer time = new Timer(); 

        public int bulletLeft; 
        public int bulletTop; 

        
        //Code how the bullet spawns in front of the player and Bullet properties
        public void MakeBullet(Form form)
        {

            Bullet.BackColor = System.Drawing.Color.White; 
            Bullet.Size = new Size(10, 10); 
            Bullet.Tag = "bullet"; 
            Bullet.Left = bulletLeft; 
            Bullet.Top = bulletTop; 
            Bullet.BringToFront(); 
            form.Controls.Add(Bullet); 

            time.Interval = speed; 
            time.Tick += new EventHandler(time_Tick); 
            time.Start(); 

        }

        public void time_Tick(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                Bullet.Left -= speed; 
            }

            if (direction == "right")
            {
                Bullet.Left += speed; 
            }
          
            if (direction == "up")
            {
                Bullet.Top -= speed; 
            }
          
            if (direction == "down")
            {
                Bullet.Top += speed; 
            }

            //limit how far the bullet can go
            if (Bullet.Left < 16 || Bullet.Left > 1400 || Bullet.Top < 45 || Bullet.Top > 800)
            {
                time.Stop(); 
                time.Dispose(); 
                Bullet.Dispose(); 
                time = null; 
                Bullet = null; 
            }
        }
    }
}
