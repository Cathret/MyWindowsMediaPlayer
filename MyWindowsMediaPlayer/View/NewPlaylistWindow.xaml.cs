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
using Microsoft.Win32;
using MyWindowsMediaPlayer.Model;
using MyWindowsMediaPlayer.ViewModel;

namespace MyWindowsMediaPlayer.View
{
    public partial class NewPlaylistWindow : Window
    {
        public NewPlaylistWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModelNewPlaylist();
        }

        private void CreatePlaylist(object sender, RoutedEventArgs e)
        {
            ViewModelNewPlaylist context = this.DataContext as ViewModelNewPlaylist;
#warning namePlaylist = valueFromTextBox;
            string namePlaylist = TextNamePlaylist.Text;
            if (namePlaylist == null || namePlaylist == "")
            {
                MessageBox.Show("Donnez un nom à votre playlist", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (context.CreatePlaylist(namePlaylist + ".pls", ListFilesPlaylist.Items.Cast<string>().ToList()))
                this.Close();
        }

        private void ButtonCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LookForFiles(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Filter = "Some supported files (*.mp3,*.wav,*.mpeg,*.wmv,*.avi,*.mp4,*.png,*.jpg)|*.mp3;*.wav;*.mpeg;*.wmv;*.avi;*.mp4;*.png;*.jpg|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            if (dlg.ShowDialog() == true)
            {
                foreach (string filepath in dlg.FileNames)
                    ListFilesPlaylist.Items.Add(filepath);
            }
        }
    }
}
