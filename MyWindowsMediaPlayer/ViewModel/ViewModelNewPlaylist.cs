using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MyWindowsMediaPlayer.View;
using MyWindowsMediaPlayer.Model;
using System.IO;

namespace MyWindowsMediaPlayer.ViewModel
{
    public class ViewModelNewPlaylist : ViewModelBase
    {
        readonly string PathPlaylist = Playlist.PathPlaylist;

        public bool CreatePlaylist(string namePlaylist, List<string> files = null)
        {
            string path = PathPlaylist + namePlaylist;
            Playlist playlist = new Playlist(path);
            if (playlist.CreatePlaylistFile() == false)
            {
                MessageBox.Show("La playlist \"" + namePlaylist + "\" existe déjà", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return (false);
            }
            if (files != null)
            {
                foreach (string filepath in files)
                    playlist.AddToPlaylist(filepath, false);
            }
            return (true);
        }

        public  ViewModelNewPlaylist()
        {
        }

        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
        #endregion
    }
}
