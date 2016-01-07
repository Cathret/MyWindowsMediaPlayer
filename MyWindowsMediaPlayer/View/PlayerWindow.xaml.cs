using System;
using System.Windows;
using MyWindowsMediaPlayer.ViewModel;

namespace MyWindowsMediaPlayer.View
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        public  PlayerWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModelPlayer();
        }
    }
}
