using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SokoBomber
{
    public abstract class Block
    {
        public int x { get; set; }
        public int y { get; set; }

        public int width { get; set; } = 50;
        public int height { get; set; } = 50;

        public abstract void BuildRec(Canvas display);
    }
}
