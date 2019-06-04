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
        int testCases;
        int currentPrime;
        int[] primeSum;
        List<int> primes;
        List<string> output;
        List<int> noDuplicates = new List<int>();
        bool primefound;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            output = new List<string>();
            txtOutput.Text = "";
            primes = new List<int>();
            string[] input = txtInput.Text.Split('\r');

            int.TryParse(input[0], out testCases);
            for(int i = 1; i < input.Length; i++)
            {
                int.TryParse(input[i], out currentPrime);
                primes.Add(currentPrime);
            }
            determineSum();
            
        }
        private void determineSum()
        {
            primeSum = new int[2];
            foreach(int prime in primes)
            {
                int temp = prime * 2;
                primefound = false;
                for (int i = 1; i < temp; i++)
                {
                    primeSum[0] = temp - i;
                    primeSum[1] = i;
                    if(primefound == false)
                    checkPrime(primeSum);
                }
            }
            displayOutput();
        }

        private void checkPrime(int[] checkingNumber)
        {
            primefound = false;
            bool[] isPrime = new bool[2];
            isPrime[0] = true;
            isPrime[1] = true;
           
            for( int number1 = 2; number1 <= checkingNumber[0]/2; number1++)
            {
                if (checkingNumber[0] % number1 == 0)
                {
                    isPrime[0] = false;
                }
            }
            for (int number2 = 2; number2 <= checkingNumber[1] / 2; number2++)
            {
                if(checkingNumber[1]%number2 == 0)
                {
                    isPrime[1] = false;
                }
            }
            if (isPrime[0] == true && isPrime[1] == true)
            {
                output.Add(checkingNumber[0] + " " + checkingNumber[1]);
                primefound = true;
            }
        }

        private void displayOutput()
        {
          
            txtOutput.Text = null;

            foreach(string s in output)
            {
                txtOutput.Text += s + "\r"; 
            }
        }
    }
}
