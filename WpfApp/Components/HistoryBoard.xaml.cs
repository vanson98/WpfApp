using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp.Components
{
    /// <summary>
    /// Interaction logic for HistoryBoard.xaml
    /// </summary>
    public partial class HistoryBoard : UserControl, INotifyPropertyChanged
    {
        private int _boarHeight = 450;
        public int BoardHeight {
            get
            {
                return _boarHeight;
            }
            set {
                if (_boarHeight == value) return;
                _boarHeight = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BoardHeight)));
            } 
        }
        public HistoryBoard()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ContentControl BoardInstance => historyBoard;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
