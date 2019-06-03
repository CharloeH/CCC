using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace Flipper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter;
        int[,] grid = new int[,] { {1,2},
                                   {3,4} };
        public MainWindow()
        {
            InitializeComponent();
            txtOutput.Text = grid[0, 0] + " " + grid[0, 1] + "\r" + grid[1, 0] + " " + grid[1, 1];
        }

        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            counter = 0;
            timer.Start();
            char[] input = txtInput.Text.ToCharArray();
            int hCounter = 0, vCounter = 0;

            grid = new int[,] { {1,2},
                                {3,4} };
            foreach (char c in input)
            {
                if (c == 'H')
                {
                    hCounter++;
                }
                else
                    vCounter++;
            }
            if(hCounter%2 != 0)
            {
                RotateGrid('H', grid);
            }
            else if(vCounter%2 != 0)
                RotateGrid('V', grid);

            txtOutput.Text = grid[0, 0] + " " + grid[0, 1] + "\r" + grid[1, 0] + " " + grid[1, 1];
        }

        private void RotateGrid(char c, int[,] grid)
        {
            int temp1, temp2;
            
                if (c == 'H')
                {
                    temp1 = grid[0, 0];
                    grid[0, 0] = grid[0, 1];
                    grid[0, 1] = temp1;
                    temp2 = grid[1, 0];
                    grid[1, 0] = grid[1, 1];
                    grid[1, 1] = temp2;

                }
                else if (c == 'V')
                {
                    temp1 = grid[0, 0];
                    grid[0, 0] = grid[1, 0];
                    grid[1, 0] = temp1;

                    temp2 = grid[0, 1];
                    grid[0, 1] = grid[1, 1];
                    grid[1, 1] = temp2;
                }

        }
    }
}
