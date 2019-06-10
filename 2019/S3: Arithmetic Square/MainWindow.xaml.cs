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

namespace ArithmeticSquare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] rowStepPattern;
        int[] collumStepPattern;
        int[,] aritmeticSquare;
        string input;
        public MainWindow()
        {
            InitializeComponent();
            aritmeticSquare = new int[,] { {8,0,0},
                                           {16,0,20},
                                           {24,0,30} };
        }

        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
           for(int y = 0; y < aritmeticSquare.GetLength(0); y++)
            {
                determineStepPatten(aritmeticSquare[y, 0], aritmeticSquare[y, 1], aritmeticSquare[y, 2]);
            }
        }
        private void determineStepPatten(int primary, int secondary, int tertiary)
        {
            
            if(primary == 0)
            {
                Console.WriteLine(tertiary - secondary);    
            }
            else if (secondary == 0)
            {
                 Console.WriteLine((tertiary - primary) / 2);
            }
            else
            {
                Console.WriteLine(secondary - primary);
            }

        }
    }
}
