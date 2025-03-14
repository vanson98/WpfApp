using LoginForm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for PhotosWindow.xaml
    /// </summary>
    public partial class PhotosWindow : Window, INotifyPropertyChanged
    {
        public List<Photo> _myPhotos;

        public List<Photo> MyPhotos
        {
            get => _myPhotos;
            set
            {
                _myPhotos = value;
                OnPropertyChanged();
            }
        }

        public PhotosWindow()
        {
            InitializeComponent();
            MyPhotos = [
                new Photo("/Images/close.png"),
                new Photo("/Images/Email.png"),
                new Photo("/Images/facebook.png"),
                new Photo("/Images/google.png"),
                new Photo("/Images/linkedin.png"),
                new Photo("/Images/Lock.png")
            ];
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
