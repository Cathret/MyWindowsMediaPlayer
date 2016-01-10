using System;
using System.IO;
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
                try
                {
                    media.Source = new Uri(fileName, UriKind.Relative);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                media.Play();
            }
        }
        #endregion

        #region OpenRecent
        static public bool OpenRecent_CanExecute(object parameter)
        {
            return (false);
        }

        static public void OpenRecent_Execute(object parameter)
        {
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
            ViewModelPlayer    context = parameter as ViewModelPlayer;
            var newWin = new PlaylistWindow();
            newWin.ShowDialog();
            if (newWin.bHasReturned == true)
            {
                context._playlist = newWin.playlist;
                context._media.Source = new Uri(context._playlist.Files[0].Path);
                context._media.Play();
            }
        }
        #endregion

        #region AddToPlaylist
        static public bool Add_CanExecute(object parameter)
        {
            ViewModelPlayer context = parameter as ViewModelPlayer;
            if (context != null && context._media != null && context._media.Source != null)
                return (true);
            return (false);
        }

        static public void Add_Execute(object parameter)
        {
            ViewModelPlayer context = parameter as ViewModelPlayer;
            var newWin = new PlaylistWindow();
            newWin.ShowDialog();
            if (newWin.bHasReturned == true)
            {
                string path = context._media.Source.ToString();
                newWin.playlist.AddToPlaylist(path, false);
            }
        }
        #endregion

        #region DeleteFromPlaylist
        static public bool DeleteFrom_CanExecute(object parameter)
        {
            ViewModelPlayer context = parameter as ViewModelPlayer;
            if (context._playlist != null)
                return (true);
            return (false);
        }

        static public void DeleteFrom_Execute(object parameter)
        {
            ViewModelPlayer context = parameter as ViewModelPlayer;
            var msgBoxRslt = MessageBox.Show("Etes vous sûr de vouloir supprimer cette musique de la playlist ?",
                                         "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (msgBoxRslt == MessageBoxResult.Yes)
            {
                string path = context._media.Source.ToString();
                context._playlist.RemoveFromPlaylist(path);
            }
        }
        #endregion

        #region ModifyPlaylist
        static public bool Modify_CanExecute(object parameter)
        {
            return (true);
        }

        static public void Modify_Execute(object parameter)
        {
            var newWin = new PlaylistWindow();
            newWin.ShowDialog();
            if (newWin.bHasReturned == true)
            {
#warning Doit ouvrir la fenetre "modifierPlaylist"
            }
        }
        #endregion

        #region DeletePlaylist
        static public bool Delete_CanExecute(object parameter)
        {
            return (true);
        }

        static public void Delete_Execute(object parameter)
        {
            var newWin = new PlaylistWindow();
            newWin.ShowDialog();
            if (newWin.bHasReturned == true)
                File.Delete(newWin.playlist.Path);
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
