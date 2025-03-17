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
using System.Windows.Media.Animation;
using System.Collections.ObjectModel;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public partial class CalculatorViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _resultText = string.Empty;

        [ObservableProperty]
        private string _expressionText = string.Empty;

        [ObservableProperty]
        private Visibility _historyBoardVisibility = Visibility.Collapsed;

        [ObservableProperty]
        private ObservableCollection<ExpressionModel> _expressionHistories = [];

        [ObservableProperty]
        private ExpressionModel _selectedExpression;

        private double _firstOperand;
        private double _secondOperand;
        private string? _operator;
        private bool resetIncomingNumber;

        public CalculatorViewModel()
        {

        }
  
        partial void OnSelectedExpressionChanged(ExpressionModel epx)
        {
            _firstOperand = epx.FirstOperand;
            _secondOperand = epx.SecondOperand;
            _operator = epx.Operator;
            ResultText = epx.Result.ToString();
            ExpressionText = $"{_firstOperand} {_operator} {_secondOperand} = ";
            HistoryBoardVisibility = Visibility.Hidden;
        }

        [RelayCommand]
        private void InputOperand(object param)
        {
            double inputNumber;
            // convert param to input number
            if (!double.TryParse(param.ToString(), out inputNumber))
            {
                return;
            }
            var newNumber = _firstOperand == 0 ? $"{inputNumber}" : $"{_firstOperand}{inputNumber}";
            if (string.IsNullOrEmpty(_operator))
            {
                _firstOperand = double.Parse(newNumber);
                ResultText = $"{newNumber}";
                return;
            }
            if (resetIncomingNumber)
            {
                resetIncomingNumber = false;
                _secondOperand = 0;
            }
            newNumber = _secondOperand == 0 ? $"{inputNumber}" : $"{_secondOperand}{inputNumber}";
            _secondOperand = double.Parse(newNumber);
            ResultText = $"{newNumber}";
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
            if (string.IsNullOrEmpty(_operator))
            {
                return;
            }
            switch (_operator)
            {
                case "*":
                    var result = _firstOperand * _secondOperand;
                    ResultText = result.ToString();
                    AddExpressionHistory(_firstOperand, _secondOperand, _operator, result);
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
                    AddExpressionHistory(_firstOperand, _secondOperand, _operator, result);
                    ResultText = result.ToString();
                    ExpressionText = $"{_firstOperand} ÷ {_secondOperand} = ";
                    _firstOperand = result;
                    break;
                case "-":
                    result = _firstOperand - _secondOperand;
                    AddExpressionHistory(_firstOperand, _secondOperand, _operator, result);
                    ResultText = result.ToString();
                    ExpressionText = $"{_firstOperand} - {_secondOperand} = ";
                    _firstOperand = result;
                    break;
                case "+":
                    result = _firstOperand + _secondOperand;
                    AddExpressionHistory(_firstOperand, _secondOperand, _operator, result);
                    ResultText = result.ToString();
                    ExpressionText = $"{_firstOperand} + {_secondOperand} = ";
                    _firstOperand = result;
                    break;
            }
            resetIncomingNumber = true;
        }

        private void AddExpressionHistory(double firstOperand, double secondOperand, string expOperator, double result)
        {
            ExpressionHistories.Add(new ExpressionModel()
            {
                FirstOperand = firstOperand,
                SecondOperand = secondOperand,
                Operator = expOperator,
                Result = result
            });
        }
    }
}
