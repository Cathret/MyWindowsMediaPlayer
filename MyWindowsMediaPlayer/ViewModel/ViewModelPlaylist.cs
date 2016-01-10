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
    public class ViewModelPlaylist : ViewModelBase
    {
        static public string PathPlaylist = ".\\playlists\\";
        public  Playlist    playlist { get; set; }

        private void fillList(ListBox listPlaylist)
        {
            if (!Directory.Exists(PathPlaylist))
                Directory.CreateDirectory(PathPlaylist);
            try
            {
                string[] listFiles = Directory.GetFiles(PathPlaylist, "*.pls");
                foreach (string fileName in listFiles)
                {
                    Playlist onePlaylist = new Playlist(fileName);
                    try
                    {
                        onePlaylist.ParsePlaylist();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    listPlaylist.Items.Add(onePlaylist);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
        }

        public  ViewModelPlaylist(ListBox listPlaylist)
        {
            fillList(listPlaylist);
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
