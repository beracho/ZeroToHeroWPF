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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float _lastNumber;
        private SelectedOperator _operation;
        public MainWindow()
        {
            InitializeComponent();
            _lastNumber = 0;
            _operation = SelectedOperator.None;
        }

        private void addNumberToResult(string numero)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                if(numero != ",")
                    resultLabel.Content = numero;
                else
                    resultLabel.Content = $"0{numero}";
            }
            else
            {
                if (numero != ",")
                    resultLabel.Content = $"{resultLabel.Content}{numero}";
                else
                {
                    double aux;
                    if (!resultLabel.Content.ToString().Contains(","))
                    //if (double.TryParse($"{resultLabel.Content}{numero}", out aux))
                        resultLabel.Content = $"{resultLabel.Content}{numero}";
                }
            }
        }

        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            _lastNumber = 0;
            _operation = SelectedOperator.None;
        }

        private void signButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = $"{(float.Parse(resultLabel.Content.ToString()) * -1)}";
        }

        private void operationButton_Click(object sender, RoutedEventArgs e)
        {
            _lastNumber = float.Parse(resultLabel.Content.ToString());
            if(sender == percentageButton)
                _operation = SelectedOperator.Percentage;
            if(sender == plusButton)
                _operation = SelectedOperator.Adition;
            if(sender == minusButton)
                _operation = SelectedOperator.Substraction;
            if(sender == multiplicationButton)
                _operation = SelectedOperator.Multiplication;
            if(sender == divisionButton)
                _operation = SelectedOperator.Division;
            resultLabel.Content = "0";
        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedValue = "0";

            if(sender == oneButton)
            {
                selectedValue = "1";
            }
            if(sender == twoButton)
            {
                selectedValue = "2";
            }
            if(sender == threeButton)
            {
                selectedValue = "3";
            }
            if(sender == fourButton)
            {
                selectedValue = "4";
            }
            if(sender == fiveButton)
            {
                selectedValue = "5";
            }
            if(sender == sixButton)
            {
                selectedValue = "6";
            }
            if(sender == sevenButton)
            {
                selectedValue = "7";
            }
            if(sender == eigthButton)
            {
                selectedValue = "8";
            }
            if(sender == nineButton)
            {
                selectedValue = "9";
            }
            if(sender == zeroButton)
            {
                selectedValue = "0";
            }
            if(sender == periodButton)
            {
                selectedValue = ",";
            }

            addNumberToResult(selectedValue);
        }

        private void equalsButton_Click(object sender, RoutedEventArgs e)
        {
            float newNumber;
            if(float.TryParse(resultLabel.Content.ToString(), out newNumber))
                switch(_operation)
                {
                    case SelectedOperator.Division:
                        resultLabel.Content = _lastNumber / newNumber;
                        break;
                    case SelectedOperator.Multiplication:
                        resultLabel.Content = _lastNumber * newNumber;
                        break;
                    case SelectedOperator.Substraction:
                        resultLabel.Content = _lastNumber - newNumber;
                        break;
                    case SelectedOperator.Adition:
                        resultLabel.Content = _lastNumber + newNumber;
                        break;
                    case SelectedOperator.Percentage:
                        resultLabel.Content = _lastNumber / 100 * newNumber;
                        break;
                }
            _lastNumber = 0;
            _operation = SelectedOperator.None;
        }
    }
    public enum SelectedOperator
    {
        Adition,
        Substraction,
        Multiplication,
        Division,
        Percentage,
        None
    }
}
