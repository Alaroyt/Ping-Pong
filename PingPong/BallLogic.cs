using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp14
{
    class BallLogic
    {
        PictureBox Ball;

        int dirX;
        int dirY;

        PanelsLogic p1, p2;

        public BallLogic(PictureBox ball, PanelsLogic left, PanelsLogic right)
        {
            p1 = left;
            p2 = right;

            Ball = ball;

            Ball.Location = new Point((settings.limitOfLeft + settings.limitOfRight) / 2,
                (settings.limitOfTop + settings.limitOfBottom) / 2);
            getDirrection();
        }
        Random rnd = new Random();
        private void getDirrection()
        {
            do
            {
                dirX = rnd.Next(-6, 7);
                dirY = rnd.Next(-6, 7);
            } while (Math.Abs(dirX) + Math.Abs(dirY) <= 4 || Math.Abs(dirX) <= 2);
        }

        public void Move()
        {
            var locY = Math.Max(settings.limitOfTop, Math.Min(settings.limitOfBottom, Ball.Location.Y + dirY));
            Ball.Location = new Point(Ball.Location.X + dirX, locY);

            if (Ball.Location.Y <= settings.limitOfTop)
            {
                dirY *=-1;
            }
            if (Ball.Location.Y >= (settings.limitOfBottom - settings.sizeBall))
            {
                dirY *= -1;
            }

            if (Ball.Location.X <= settings.limitOfLeft)
            {
                Goal(p2);
            }
            else if (Ball.Location.X >= settings.limitOfRight- settings.sizeBall)
            {
                Goal(p1);
            }

            //Reflection
            if (p1.PlayerPanel.Bounds.IntersectsWith(Ball.Bounds)
                || p2.PlayerPanel.Bounds.IntersectsWith(Ball.Bounds))
                dirX *= -1;
        }

        private void Goal(PanelsLogic player)
        {
            player.score++;
            Ball.Location = new Point((settings.limitOfLeft + settings.limitOfRight) / 2,
                (settings.limitOfTop + settings.limitOfBottom) / 2);
            getDirrection();
        }
    }
}
