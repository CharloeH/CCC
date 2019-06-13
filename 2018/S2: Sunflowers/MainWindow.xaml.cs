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
        public MainWindow()
        {
            InitializeComponent();
            
           
        }

        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            getInput();
           // Rotation(360, formatList(getInput(),1));
            Rotation(90, formatList(getInput(),length));
            
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
        private string getInput()
        {
            txtOutput.Text = "";
            input = txtInput.Text;
            int.TryParse(input.Substring(0, 1), out length);
            unformatedInput = input.Substring(1).ToCharArray();
            allData = "";
            foreach (char c in unformatedInput)
            {
                if (c != '\n' && c != ' ' && c != '\r')
                {
                     allData += c.ToString();
                }
            }
            return allData;
        }
        private void Rotation(int angle, List<string> data)
        {
            int counter = 0;
                foreach (string s in data)
                {
                    int previousValue = 0;
                    foreach (char c in s)
                    {
                    if (previousValue < c)
                    {
                        previousValue = c;
                        counter++;
                    }
                    else
                        break;
                    }
                }
            if(counter == length*length)
            {
                Console.WriteLine(angle);
            }
        }
    }
}
