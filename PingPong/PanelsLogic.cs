using System;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    class PanelsLogic
    {
        /// <summary>
        /// Player
        /// </summary>
        public PictureBox PlayerPanel;
        /// <summary>
        /// Label for score of Player
        /// </summary>
        Label PlayerLabel;

        int _score;
        /// <summary>
        /// PlayerScore
        /// </summary>
        public int score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                PlayerLabel.Text = "" + value;
            }
        }

        public PanelsLogic(PictureBox panel, Label scoreLB)
        {
            PlayerPanel = panel;
            PlayerLabel = scoreLB;
            score = 0;
        }

        public bool isUpPressed;

        public bool isDownPressed;

        /// <summary>
        /// определение стороны движения и движение ракетки
        /// </summary>
        public void Move()
        {
            bool? isGoingUp = null;

            if (isUpPressed)
            {
                isGoingUp = true;
            }

            if (isDownPressed)
            {
                if (isGoingUp.HasValue)
                {
                    isGoingUp = null;
                }
                else
                {
                    isGoingUp = false;
                }
            }

            if (isGoingUp.HasValue)
            {
                int moveSpeed = 3;
                if (isGoingUp.Value)
                {
                    moveSpeed *= -1;
                }
                PlayerPanel.Location = new System.Drawing.Point(
                    PlayerPanel.Location.X,
                    Math.Max(settings.limitOfTop, Math.Min(settings.limitOfBottom - settings.sizePlayer, PlayerPanel.Location.Y + moveSpeed))
                );
            }
        }

    }
}
