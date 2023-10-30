using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SokoBomber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        char[,] map = new char[16, 16];
        Player p1 = new Player();
        Player p2 = new Player();
        public MainWindow()
        {
            InitializeComponent();
            BuildStart();
            check();

        }
        public void BuildStart()
        {
            ReadFile();
            int nbRow = 0;
            int nbColum = 0;
            foreach (char c  in map)
            {
                switch (c)
                {
                    case '$':
                        Crate crate = new Crate();
                        crate.x = calcPosition(nbRow);
                        crate.y = calcPosition(nbColum);
                        crate.BuildRec(Display);
                        break;
                    case '1':
                        p1.brush = new SolidColorBrush(Colors.Blue);
                        p1.x = calcPosition(nbRow);
                        p1.y = calcPosition(nbColum);
                        p1.BuildRec(Display);
                        break;
                    case '2':
                        p2.brush = new SolidColorBrush(Colors.Red);
                        p2.x = calcPosition(nbRow);
                        p2.y = calcPosition(nbColum);
                        p2.BuildRec(Display);
                        break;
                    case '#':
                        Wall w = new Wall();
                        w.x = calcPosition(nbRow);
                        w.y = calcPosition(nbColum);
                        w.BuildRec(Display);
                        break;
                    default:
                        Floor f = new Floor();
                        f.x = calcPosition(nbRow);
                        f.y = calcPosition(nbColum);
                        f.BuildRec(Display);
                        break;
                }
                if (nbRow == 15)
                {
                    nbColum++;
                    nbRow = -1;
                }
                nbRow++;
            }
        }

        public void ReadFile()
        {
            string[] lines = File.ReadAllLines("./Map.txt");
            int nbLine = 0;
            foreach (string line in lines)
            {
                char[] chars = line.ToCharArray();
                int nbChar = 0;
                foreach (char c in chars)
                {
                    map[nbLine, nbChar] = c;
                    nbChar++;
                }
                nbLine++;
            }
        }

        public int calcPosition(int input)
        {
            return input * 50;
        }

        public void check()
        {
            int nb = 0;
            foreach (char c in map)
            {
                
                Debug.Write(c);

                if (nb == 15)
                {
                    Debug.WriteLine("");
                    nb = 0;
                }
                else { nb++; }
            }
        }
    }
}
