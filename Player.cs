using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace u4Tapper
{
    class Player
    {
        public int i = 0;
        Canvas canvas;
        Window Window;
        public Rectangle playerRectangle;
        Point point;
        public Player(Canvas c, Window w)
        {
            canvas = c;
            Window = w;
            point = new Point(0, 0);
            playerRectangle = new Rectangle();
            playerRectangle.Fill = Brushes.White;
            playerRectangle.Height = 100;
            playerRectangle.Width = 100;
            canvas.Children.Add(playerRectangle);
            Canvas.SetTop(playerRectangle, point.Y);
            Canvas.SetLeft(playerRectangle, point.X);
            

        }
    }
}
