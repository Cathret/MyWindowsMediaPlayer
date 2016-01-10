using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using MyWindowsMediaPlayer.View;
using MyWindowsMediaPlayer.ViewModel;

namespace MyWindowsMediaPlayer.Model
{
    public class PlayerCommands
    {
        #region MenuFile

        #region OpenFile
        static public bool OpenFile_CanExecute(object parameter)
        {
            return (true);
        }

        static public void OpenFile_Execute(object parameter)
        {
#warning "More to create"
            MediaElement media = parameter as MediaElement;
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Some supported files (*.mp3,*.wav,*.mpeg,*.wmv,*.avi,*.mp4,*.png,*.jpg)|*.mp3;*.wav;*.mpeg;*.wmv;*.avi;*.mp4;*.png;*.jpg|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document
                string  fileName = dlg.FileName;
                media.Source = new Uri(fileName, UriKind.Relative);
                media.Play();
            }
        }
        #endregion

        #region OpenRecent
        static public bool OpenRecent_CanExecute(object parameter)
        {
#warning "if it exists recent files"
            return (false);
        }

        static public void OpenRecent_Execute(object parameter)
        {
#warning "Modify himself to add direct link to files"
        }
        #endregion

        #endregion

        #region MenuPlaylist

        #region CreatePlaylist
        static public bool Create_CanExecute(object parameter)
        {
            return (true);
        }

        static public void Create_Execute(object parameter)
        {
            #warning "Comment"
            //var newWin = new NewPlaylistWindow();
            //newWin.Show();
        }
        #endregion

        #region OpenPlaylist
        static public bool Open_CanExecute(object parameter)
        {
            return (true);
        }

        static public void Open_Execute(object parameter)
        {
#warning "Doit retourner la valeur de ce qu'on est cense ouvrir"
            Playlist    playlist = parameter as Playlist;
            var newWin = new PlaylistWindow(e_PlaylistMessage.OPEN);
            newWin.Show();
            ViewModelPlaylist context = newWin.DataContext as ViewModelPlaylist;
            playlist = context.playlist;
        }
        #endregion

        #region AddToPlaylist
        static public bool Add_CanExecute(object parameter)
        {
#warning "Si on est actuellement en train de lire quelque chose"
            if (parameter == null) return false;
            return (bool)parameter;
        }

        static public void Add_Execute(object parameter)
        {
#warning "Doit retourner la valeur de ce qu'on est cense utiliser pour l'ajout"
            //var newWin = new PlaylistWindow();
            //newWin.Show();
        }
        #endregion

        #region DeleteFromPlaylist
        static public bool DeleteFrom_CanExecute(object parameter)
        {
#warning "Si en train de lire filchier d'une playlist"
            if (parameter == null) return false;
            return (bool)parameter;
        }

        static public void DeleteFrom_Execute(object parameter)
        {
#warning "Supprimer actuel si actuel"
        }
        #endregion

        #region ModifyPlaylist
        static public bool Modify_CanExecute(object parameter)
        {
            return (true);
        }

        static public void Modify_Execute(object parameter)
        {
#warning "Doit retourner la valeur de ce qu'on est cense modifier"
            //var newWin = new PlaylistWindow();
            //newWin.Show();
        }

        #endregion

        #region DeletePlaylist
        static public bool Delete_CanExecute(object parameter)
        {
            return (true);
        }

        static public void Delete_Execute(object parameter)
        {
#warning "Doit retourner la valeur de ce qu'on est cense supprimer"
            //var newWin = new PlaylistWindow();
            //newWin.Show();
        }
        #endregion

        #endregion

        #region MenuLecture

        #region ClickPlay
        static public bool Play_CanExecute(object parameter)
        {
            return (true);
        }

        static public void Play_Execute(object parameter)
        {
            MediaElement media = parameter as MediaElement;
            media.Play();
        }
        #endregion

        #region ClickPause
        static public bool Pause_CanExecute(object parameter)
        {
            return (true);
        }

        static public void Pause_Execute(object parameter)
        {
            MediaElement media = parameter as MediaElement;
            media.Pause();
        }
        #endregion

        #region ClickStop
        static public bool Stop_CanExecute(object parameter)
        {
            return (true);
        }

        static public void Stop_Execute(object parameter)
        {
            MediaElement media = parameter as MediaElement;
            media.Stop();
        }
        #endregion

        #endregion

        #region OpenBilbliotheque

        static public bool OpenBiblio_CanExecute(object parameter)
        {
            return (true);
        }

        static public void OpenBiblio_Execute(object parameter)
        {
#warning "More to create"
            //var newWin = new BibliothequeWindow();
            //newWin.Show();
        }

        #endregion
    }
}
