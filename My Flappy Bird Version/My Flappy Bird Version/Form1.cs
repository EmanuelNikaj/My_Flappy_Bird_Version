using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Flappy_Bird_Version
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;

        bool gameOver = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void gorund_Click(object sender, EventArgs e)
        {

        }

        private void pipeBottom_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -150)
            {

                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {

                pipeTop.Left = 950;
                score++;
            }

            if (FlappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(gorund.Bounds) || FlappyBird.Top < -25
                )
            {

                endGame();
            }

            if (score > 5)
            {
                pipeSpeed = 15;
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

                gravity = -15;
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

                gravity = 15;
            }
            if (e.KeyCode == Keys.R && gameOver)
            {
                RestartGame();
            }

        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game over!!! Press R to retry";   
            gameOver = true;
        }

    private void RestartGame()
        {

            gameOver = false;

            FlappyBird.Location = new Point(88, 217);
            pipeTop.Left = 540;
            pipeBottom.Left = 400;

            score = 0;
            pipeSpeed = 8;
            scoreText.Text = "Score:0";
            gameTimer.Start();
        }


    }
}
