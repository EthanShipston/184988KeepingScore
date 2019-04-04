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

namespace _184988KeepingScore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            string[] inputs = new string[4];
            string[] outputs = new string[4];
            int[] numOutputs = new int[5];
            inputs[0] = txtInput.Text.Substring(0, txtInput.Text.IndexOf("D"));
            inputs[1] = txtInput.Text.Substring(txtInput.Text.IndexOf("D"), txtInput.Text.IndexOf("H") - txtInput.Text.IndexOf("D"));
            inputs[2] = txtInput.Text.Substring(txtInput.Text.IndexOf("H"), txtInput.Text.IndexOf("S") - txtInput.Text.IndexOf("H"));
            inputs[3] = txtInput.Text.Substring(txtInput.Text.IndexOf("S"), txtInput.Text.Length - txtInput.Text.IndexOf("S"));
            for (int i = 0; i < 4; i++)
            {
                inputs[i] = inputs[i].Remove(0, 1);

                if (inputs[i].Contains("J"))
                {
                    numOutputs[i] += 1;
                }
                if (inputs[i].Contains("Q"))
                {
                    numOutputs[i] += 2;
                }
                if (inputs[i].Contains("K"))
                {
                    numOutputs[i] += 3;
                }
                if (inputs[i].Contains("A"))
                {
                    numOutputs[i] += 4;
                }
                if (inputs[i].Length == 0)
                {
                    numOutputs[i] += 3;
                }
                if (inputs[i].Length == 1)
                {
                    numOutputs[i] += 2;
                }
                if (inputs[i].Length == 2)
                {
                    numOutputs[i] += 1;
                }

                for (int ii = 0; ii <= inputs[i].Length; ii++)
                {
                    if (ii != inputs[i].Length)
                    {
                        outputs[i] += inputs[i].Substring(ii, 1) + " ";
                    }
                    else
                    {
                        outputs[i] += inputs[i].Substring(ii, 0);
                    }
                }
            }

            numOutputs[4] = numOutputs[0] + numOutputs[1] + numOutputs[2] + numOutputs[3];

            txtOutput.Text = "Cards Dealt\t\tPoints\n" +
                "Clubs: " + outputs[0] + "\t\t" + numOutputs[0].ToString() + "\n" +
                "Diamonds: " + outputs[1] + "\t" + numOutputs[1].ToString() + "\n" +
                "Hearts: " + outputs[2] + "\t\t\t" + numOutputs[2].ToString() + "\n" +
                "Spades: " + outputs[3] + "\t\t" + numOutputs[3].ToString() + "\n" +
                "Total " + numOutputs[4].ToString();
        }
    }
}
