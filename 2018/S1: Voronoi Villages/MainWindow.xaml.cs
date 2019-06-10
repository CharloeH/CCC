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

namespace VoronoiVillages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] input;
        int testCases;
        int counter;
        int smallest;
        List<double> villages;
        double[] neighbourhoods;
        public MainWindow()
        {
            InitializeComponent();
            
           
        }

        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            villages = new List<double>();
            input = txtInput.Text.Split('\r');
            int.TryParse(input[0], out testCases);
            neighbourhoods = new double[testCases];
            for (int i = 1; i <= testCases; i++)
            {
                int.TryParse(input[i], out int temp);
                villages.Add(temp);
            }
            villages.Sort();
            counter = 0;
            smallest = 1000000000;
            foreach(int village in villages)
            {

                if (counter < testCases - 1 && counter > 0)
                {
                    neighbourhoods[counter] = (village - villages[counter - 1]) / 2 + (villages[counter + 1] - village) / 2;
                }
                else
                    neighbourhoods[counter] = 999999999;
                if (neighbourhoods[counter] < smallest)
                    smallest = (int)neighbourhoods[counter];
                counter++;
            }
            string output = smallest.ToString();
            if(output.Length == 1)
            {
                output += ".0";
            }
            txtOutput.Text = output;
        }
      
    }
}
