using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace FLAPPYBIRD
{
   
    
    public partial class Form1 : Form
    {

        

      

        //hello the sound file extension must be in wav format (mp3 will not work)
        //unfortunately c# can only adjust the volume through the media class (not in soundplayer class)
        SoundPlayer jumpmusic = new SoundPlayer(@"C:\Users\realcjsphotography\OneDrive\Desktop\FLAPPYBIRD\Resources\jump.wav");
        SoundPlayer crashmusic = new SoundPlayer(@"C:\Users\realcjsphotography\OneDrive\Desktop\FLAPPYBIRD\Resources\crash.wav");


        int pipespeed = 8;
        int gravity = 10;
        int score = 0;

        

        public Form1()
        {
  
            InitializeComponent();
            restart.Hide();

        }



        

        private void gametimerevent(object sender, EventArgs e)
        {
            

            flappybird.Top += gravity;
            pipebottom.Left -= pipespeed;
            pipetop.Left -= pipespeed;
            ScoreText.Text = "Score: " + score;
            

            
            if (pipebottom.Left < -150)
            {
                pipebottom.Left = 600;
                score++;
            }
            if(pipetop.Left < -180)
            {
                pipetop.Left = 560;
                score++;
            }

            if(flappybird.Bounds.IntersectsWith(pipebottom.Bounds) ||
                flappybird.Bounds.IntersectsWith(pipetop.Bounds) ||
                flappybird.Bounds.IntersectsWith(ground.Bounds)
                )

             
            {
                endgame();
                crashmusic.Play();


            }

            if(score > 5)
            {
                pipespeed = 15;

            }
            if(flappybird.Top < -25)
            {
                endgame();

            }
        }

        private void gamekeysdown(object sender, KeyEventArgs e)
        {
            

            if(e.KeyCode == Keys.Space)
            {
                gravity = -10;
                jumpmusic.Play();

            }
        }

        private void gamekeysup(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;

            }
        }

        private void endgame()
        {
            
            gametimer.Stop();
            ScoreText.Text = "Game over!!";
            jumpmusic.Play();
            restart.Show();

          
        
        }

        private void restartclick(object sender, EventArgs e)
        {
            
            Application.Restart();
             

        }
    }
}
