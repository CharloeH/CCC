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

namespace Sunflowers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        char[] temp;
        string input;
        int[,] data;
        int length;
        public MainWindow()
        {
            InitializeComponent();
            
           
        }

        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = "";
            input = txtInput.Text;
            int.TryParse(input.Substring(0, 1), out length);
            temp = input.Substring(1).ToCharArray();
            input = "";
            foreach(char c in temp)
            {
                if(!(c == ' ' || c == '\r' || c == '\n'))
                {
                    input += c;
                }
            }
            int tempInt= 0;
            int i = 0;
            int counter = 0;
            data = new int[length, length];
            for (int y = 0; y < data.GetLength(0); y++)
            {
                tempInt = 0;
                for(int x = 0; x < data.GetLength(1); x++)
                {
                    int.TryParse(input.Substring(i, 1), out data[y,x]);
                    if(data[y,x] >= tempInt || tempInt == 0)
                    {
                        counter++;
                        if(counter == length*length)
                        {
                            txtOutput.Text = "YAY";
                        }
                    }
                    else
                    {
                       
                    }
                    i++;
                    tempInt = data[y, x];
                }
            }
            
            
        }
      private void rotateGrid(int[,] data)
        {
            int previousValue = 0;
           foreach(int i in data)
            {
                previousValue = i;
                i 
            }
        }
    }
}
