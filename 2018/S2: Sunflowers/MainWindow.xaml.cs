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
        int length;
        string allData = "";
        List<string> sunflowers;
        string output;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            int row = 1;
            if (Rotation(360, formatList(getInput(1), 1)))
            {
                MessageBox.Show("360");
            }
            else if (Rotation(90, formatList(getInput(1), length)))
            {
                MessageBox.Show("90");
            }
            else if(Rotation(180, formatList((getInput(-1)), 1)))
            {
                MessageBox.Show("180");
            }
            if (Rotation(270, formatList((getInput(-1)), length)))
            {
                MessageBox.Show("270");
            }
        }
        private List<string> formatList(string data, int stepPattern)
        {
            sunflowers = new List<string>();
            string temp = "";
            for (int counter = 0; counter < length; counter++)
            {
                for (int i = 0; i < length; i++)
                {
                    if (data.Length == length)
                    {
                        temp = data;
                        break;
                    }
                    else
                    {
                        temp += data[i * stepPattern];
                    }
                }
                foreach (char c in temp)
                {
                    data = data.Remove(data.IndexOf(c), 1);
                }
                sunflowers.Add(temp);
                temp = "";
            }
            return sunflowers;
        }
        private string getInput(int direction)
        {
            txtOutput.Text = "";
            input = txtInput.Text;
            int.TryParse(input.Substring(0, 1), out length);
            unformatedInput = input.Substring(1).ToCharArray();


            allData = "";
            if (direction == -1)
            {
                Array.Reverse(unformatedInput);
            }
            foreach (char c in unformatedInput)
                {
                    if(c != '\n' && c != ' ' && c != '\r')
                    {
                        allData += c.ToString();
                        output = allData;
                    }
                }
               
            return allData;
        }
        private bool Rotation(int angle, List<string> data)
        {
            int counter = 0;
                foreach (string s in data)
                {
                    int verticalTest = 0;
                    int horizontalTest = 0;
                    foreach (char c in s)
                    {
                    if (horizontalTest < c)
                    {
                        horizontalTest = c;
                        counter++;
                    }
                    if(verticalTest < s[0])
                    {
                        verticalTest = s[0];
                    }
                    else
                        break;
                    }
                }
            if (counter == length * length)
            {
                return true;
            }
            else
                return false;
        }
    }
}
