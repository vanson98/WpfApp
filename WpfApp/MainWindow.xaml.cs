using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Components;
using WpfApp.ViewModels;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new CalculatorViewModel();
        HistoryBoard.BoardInstance.Height = 0;
    }

    private void OpenHistoryButton_Click(object sender, RoutedEventArgs e)
    {
        BoardContainer.Visibility = Visibility.Visible;
        DoubleAnimation heighAnimation = new DoubleAnimation(350, new Duration(TimeSpan.FromMilliseconds(300)));
        HistoryBoard.BoardInstance.BeginAnimation(HeightProperty, heighAnimation);
    }

    private void BoardMask_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DoubleAnimation heighAnimation = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(300)));
        HistoryBoard.BoardInstance.BeginAnimation(HeightProperty, heighAnimation);
        BoardContainer.Visibility = Visibility.Collapsed;
    }

}