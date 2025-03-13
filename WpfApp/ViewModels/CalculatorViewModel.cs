using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfApp.ViewModels
{
    public partial class CalculatorViewModel : ObservableObject
    {
        [ObservableProperty]
        private string resultText = "";
        [ObservableProperty]
        private string expressionText = "";

        private double _firstOperand;
        private double _secondOperand;
        private string _operator;

        private bool resetIncomingNumber = false;



        public CalculatorViewModel()
        {

        }

        [RelayCommand]
        private void InputOperand(object param)
        {
            double inputNumber = 0;
            // convert param to input number
            if (param == null || !double.TryParse(param.ToString(), out inputNumber))
            {
                return;
            }

            if (string.IsNullOrEmpty(_operator))
            {
                var newNumber = _firstOperand == 0 ? $"{inputNumber}" : $"{_firstOperand}{inputNumber}";
                _firstOperand = double.Parse(newNumber);
                ResultText = $"{newNumber}";
            }
            else
            {
                if (resetIncomingNumber)
                {
                    resetIncomingNumber = false;
                    _secondOperand = 0;
                }
                var newNumber = _secondOperand == 0 ? $"{inputNumber}" : $"{_secondOperand}{inputNumber}";
                _secondOperand = double.Parse(newNumber);
                ResultText = $"{newNumber}";
            }
        }

        [RelayCommand]
        private void DeleteNumber()
        {
            var newNumber = ResultText.Length > 1 ? ResultText.Remove(ResultText.Length - 1) : "0";
            _firstOperand = double.Parse(newNumber);
            ResultText = newNumber;
        }

        [RelayCommand]
        private void Clear()
        {
            _firstOperand = 0;
            _secondOperand = 0;
            ResultText = "0";
            ExpressionText = string.Empty;
            _operator = string.Empty;
        }

        [RelayCommand]
        private void InputOperator(object opt)
        {
            _operator = opt.ToString();
            ExpressionText = $"{_firstOperand} {opt}";
            if (ResultText != null)
            {
                _secondOperand = double.Parse(ResultText);
            }
            resetIncomingNumber = true;
        }

        [RelayCommand]
        private void Calculate()
        {
            switch (_operator)
            {
                case "*":
                    var result = _firstOperand * _secondOperand;
                    ResultText = result.ToString();
                    ExpressionText = $"{_firstOperand} x {_secondOperand} = ";
                    _firstOperand = result;
                    break;
                case "/":
                    if (_secondOperand == 0)
                    {
                        ResultText = "Cannot divide by zero";
                        break;
                    }
                    result = _firstOperand / _secondOperand;
                    ResultText = result.ToString();
                    ExpressionText = $"{_firstOperand} ÷ {_secondOperand} = ";
                    _firstOperand = result;
                    break;
                case "-":
                    result = _firstOperand - _secondOperand;
                    ResultText = result.ToString();
                    ExpressionText = $"{_firstOperand} - {_secondOperand} = ";
                    _firstOperand = result;
                    break;
                case "+":
                    result = _firstOperand + _secondOperand;
                    ResultText = result.ToString();
                    ExpressionText = $"{_firstOperand} + {_secondOperand} = ";
                    _firstOperand = result;
                    break;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
