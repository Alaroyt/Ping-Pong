using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class GameForm : Form
    {
        PanelsLogic player1, player2;
        BallLogic ball;
        public GameForm()
        {
            InitializeComponent();


            player1 = new PanelsLogic(pad1, score1);
            player2 = new PanelsLogic(pad2, score2);

            ball = new BallLogic(Ball,player1,player2);
            //pictureOfBall
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 37, 37);
            Region rgn = new Region(path);
            Ball.Region = rgn;
            Ball.BackColor = Color.Red;

        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeys(e.KeyCode, true);
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            CheckKeys(e.KeyCode, false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player1.Move();
            player2.Move();

            ball.Move();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void CheckKeys(Keys e, bool isDown)
        {
            if (e == Keys.W)
            {
                player1.isUpPressed = isDown;
            }
            if (e == Keys.S)
            {
                player1.isDownPressed = isDown;
            }
            if (e == Keys.Up)
            {
                player2.isUpPressed = isDown;
            }
            if (e == Keys.Down)
            {
                player2.isDownPressed = isDown;
            }
        }
    }
}
