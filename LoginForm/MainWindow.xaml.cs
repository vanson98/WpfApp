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

namespace LoginForm;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    

    private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
    {
        txtEmail.Focus();
    }

    private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
        {
            textEmail.Visibility = Visibility.Collapsed;
        }
        else
        {
            textEmail.Visibility = Visibility.Visible;
        }
    }

    private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
    {
        txtPassword.Focus();
    }

    private void txtPassword_TextChanged(object sender, RoutedEventArgs e)
    {
        if(!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
        {
            textPassword.Visibility = Visibility.Collapsed;
        }
        else
        {
            textPassword.Visibility = Visibility.Visible;
        }
    }

  

    

    private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        if(e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }

    private void Image_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void Button_Click(object sender, MouseButtonEventArgs e)
    {
        if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Password))
        {
            MessageBox.Show("Successfully Signed In");
        }
    }
}