using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string _resultText = "01223";
        private string _expressionText = "";

        private string _currentInput = "";
        private double _firstOperand;
        private string _operator;

        public string ResultText
        {
            get => _resultText;
            set
            {
                _resultText = value;
                OnPropertyChanged(nameof(ResultText));
            }
        }

        public string ExpressionText
        {
            get => _expressionText;
            set
            {
                _expressionText = value;
                OnPropertyChanged(nameof(ExpressionText));
            }
        }

        public ICommand NumberCommand { get; }
        public ICommand OperatorCommand { get; }
        public ICommand EqualsCommand { get; }
        public ICommand ClearCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NumberButtons_OnClick(object sender, RoutedEventArgs e)
        {
            resetIncomingNumber = true;
            if (sender is Button)
            {
                var buttonContent = (sender as Button).Content.ToString();
                if (string.IsNullOrEmpty(lastOperator))
                {
                    var newNumber = firstOperand == 0 ? $"{buttonContent}" : $"{firstOperand}{buttonContent}";
                    firstOperand = double.Parse(newNumber);
                    ResultLabel.Content = $"{newNumber}";
                }
                else
                {
                    if (resetIncomingNumber)
                    {
                        resetIncomingNumber = false;
                        secondOperand = 0;
                    }
                    var newNumber = secondOperand == 0 ? $"{buttonContent}" : $"{secondOperand}{buttonContent}";
                    secondOperand = double.Parse(newNumber);
                    ResultLabel.Content = $"{newNumber}";
                }

            }
        }


        public CalculatorViewModel()
        {
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
