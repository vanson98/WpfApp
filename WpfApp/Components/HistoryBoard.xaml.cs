using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp.Models;

namespace WpfApp.Components
{
    /// <summary>
    /// Interaction logic for HistoryBoard.xaml
    /// </summary>
    public partial class HistoryBoard : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty ItemsProperties 
            = DependencyProperty.Register(nameof(Items),
                typeof(ObservableCollection<ExpressionModel>),
                typeof(HistoryBoard));

        public ObservableCollection<ExpressionModel> Items
        {
            get => (ObservableCollection<ExpressionModel>)GetValue(ItemsProperties);
            set => SetValue(ItemsProperties, value);
        }

        public static readonly DependencyProperty SelectedProperties
            = DependencyProperty.Register(nameof(SelectedEpx),
                typeof(ExpressionModel),
                typeof(HistoryBoard),
                new PropertyMetadata(OnChanged));

        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
         
        }


        public ExpressionModel SelectedEpx
        {
            get => (ExpressionModel)GetValue(SelectedProperties);
            set => SetValue(SelectedProperties, value);
        }

        public HistoryBoard()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ContentControl BoardInstance => board;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
