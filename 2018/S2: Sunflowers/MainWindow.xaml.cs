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
        char[] unformatedInput;
        string input;
        int[,] data;
        int length;
        List<string> sunflowers;
        public MainWindow()
        {
            InitializeComponent();
            
           
        }

        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            sunflowers = new List<string>();
            txtOutput.Text = "";
            input = txtInput.Text;
            int.TryParse(input.Substring(0, 1), out length);
            unformatedInput = input.Substring(1).ToCharArray();
            string temp = "";
            input = "";
            int counter = 0;
            foreach (char c in unformatedInput)
            {
                if (c != '\n' && c != ' ' && c != '\r')
                {
                    temp += c.ToString();
                    counter++;
                }
                if (counter == length)
                {
                    sunflowers.Add(temp);
                    temp = "";
                    counter = 0;
                }
            }
            int compareValue = 0;
            bool? lessThan180 = null;
            foreach (string s in sunflowers)
            {
                
                for (int i = 0; i < length - 1; i++)
                {
                    int.TryParse(s.Substring(i, 1), out int firstInSet);
                    int.TryParse(s.Substring(i + 1, 1), out int secondInSet);
                 
                        if(compareValue < firstInSet)
                        {
                        if (lessThan180 == true)
                            txtOutput.Text =("90");
                        else if (lessThan180 == false)
                            txtOutput.Text =("360");
                        }
                        else
                        {
                        if (lessThan180 == true)
                            txtOutput.Text = ("180");
                        else if (lessThan180 == false)
                            txtOutput.Text = ("270");
                    }
                    if(firstInSet > secondInSet)
                    {
                        lessThan180 = true;
                    }
                    else if(firstInSet < secondInSet)
                    {
                        lessThan180 = false;
                      
                    }
                    compareValue = firstInSet;
                }
            }
        }
    }
}
