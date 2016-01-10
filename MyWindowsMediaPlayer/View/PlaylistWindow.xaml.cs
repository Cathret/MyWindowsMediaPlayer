using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using MyWindowsMediaPlayer.ViewModel;
using MyWindowsMediaPlayer.Model;

namespace MyWindowsMediaPlayer.View
{
    public partial class PlaylistWindow : Window
    {
        public PlaylistWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModelPlaylist(ListPlaylist);
        }

        private void SelectPlaylist(object sender, RoutedEventArgs e)
        {
            ViewModelPlaylist context = this.DataContext as ViewModelPlaylist;
            context.playlist = this.ListPlaylist.SelectedValue as Playlist;
            this.Close();
        }

        private void ButtonCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonSelect.IsEnabled = true;
        }
    }
}
