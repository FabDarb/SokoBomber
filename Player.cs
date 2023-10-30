using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SokoBomber
{
    public class Player :Block
    {
        public SolidColorBrush brush { get; set; }

        public override void BuildRec(Canvas display)
        {
            Rectangle r = new Rectangle();
            r.Width = width;
            r.Height = height;
            r.Fill = brush;
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);
            display.Children.Add(r);
        }
    }
}
