using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWindowsMediaPlayer.View;
using MyWindowsMediaPlayer.Model;
using System.Windows;

namespace MyWindowsMediaPlayer.ViewModel
{
    public enum e_PlaylistMessage
    {
        OPEN    = 1,
        ADD_TO  = 2,
        MODIFY  = 4,
        DELETE  = 8
    }

    public class ViewModelPlaylist : ViewModelBase
    {
        public  Playlist    playlist { get; private set; }

        public  ViewModelPlaylist(e_PlaylistMessage whatToDo)
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
