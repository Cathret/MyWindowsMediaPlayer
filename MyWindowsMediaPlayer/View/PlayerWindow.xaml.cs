using System;
using System.Windows;
using Microsoft.Win32;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TOTO");
            MediaElementPlayer.Source = new Uri("C:\\Users\\Guillaume\\Music\\Lolilol.mp3");
            MediaElementPlayer.Volume = 1;
            MediaElementPlayer.Play();
        }

        private void MediaElementPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {

        }
    }
}
