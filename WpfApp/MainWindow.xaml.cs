using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.ViewModels;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private double firstOperand;
    private double secondOperand;
    private bool resetIncomingNumber;
    private double? result = null;
    private string lastOperator;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new CalculatorViewModel();
    }

   

   

    private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
    {
        var currentNumber = ResultLabel.Content.ToString();
        var newNumber = currentNumber.Length > 1 ? currentNumber.Remove(currentNumber.Length - 1) : "0";
        firstOperand = double.Parse(newNumber);
        ResultLabel.Content = newNumber;
    }

    private void CEButton_OnClick(object sender, RoutedEventArgs e)
    {
        firstOperand = 0;
        secondOperand = 0;
        result = null;
        ExpressionLabel.Content = string.Empty;
        ResultLabel.Content = "0";
        lastOperator = string.Empty;
    }

    private void OperatorButton_OnClick(object sender, RoutedEventArgs e)
    {
        var opt = (sender as Button)?.Content.ToString();
        ExpressionLabel.Content = $"{firstOperand} {opt}";
        lastOperator = opt;
        if (ResultLabel.Content != null)
        {
            secondOperand = double.Parse(ResultLabel.Content.ToString());
        }
        resetIncomingNumber = true;
    }
 

    private void EqualButton_OnClick(object sender, RoutedEventArgs e)
    {
        switch (lastOperator)
        {
            case "*":
                result = firstOperand * secondOperand;
                ResultLabel.Content = result;
                ExpressionLabel.Content = $"{firstOperand} x {secondOperand} = ";
                firstOperand = result.Value;
                break;
            case "/":
                if(secondOperand == 0)
                {
                    ResultLabel.Content = "Cannot divide by zero";
                    break;
                }
                result = firstOperand / secondOperand;
                ResultLabel.Content = result;
                ExpressionLabel.Content = $"{firstOperand} ÷ {secondOperand} = ";
                firstOperand = result.Value;
                break;
            case "-":
                result = firstOperand - secondOperand;
                ResultLabel.Content = result;
                ExpressionLabel.Content = $"{firstOperand} - {secondOperand} = ";
                firstOperand = result.Value;
                break;
            case "+":
                result = firstOperand + secondOperand;
                ResultLabel.Content = result;
                ExpressionLabel.Content = $"{firstOperand} + {secondOperand} = ";
                firstOperand = result.Value;
                break;
        }
    }


  
}