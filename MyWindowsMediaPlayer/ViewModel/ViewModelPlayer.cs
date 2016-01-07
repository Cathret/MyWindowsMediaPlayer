using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWindowsMediaPlayer.Model;
using MyWindowsMediaPlayer.View;

namespace MyWindowsMediaPlayer.ViewModel
{
    public class ViewModelPlayer : ViewModelBase
    {
        public RelayCommand CreatePlaylist { get; set; }
        public RelayCommand OpenPlaylist { get; set; }
        public RelayCommand AddToPlaylist { get; set; }
        public RelayCommand DeleteFromPlaylist { get; set; }
        public RelayCommand ModifyPlaylist { get; set; }
        public RelayCommand DeletePlaylist { get; set; }
        public RelayCommand OpenBibliotheque { get; set; }

        public ViewModelPlayer()
        {
            CreatePlaylist = new RelayCommand(PlayerCommands.Create_Execute, PlayerCommands.Create_CanExecute);
            OpenPlaylist = new RelayCommand(PlayerCommands.Open_Execute, PlayerCommands.Open_CanExecute);
            AddToPlaylist = new RelayCommand(PlayerCommands.Add_Execute, PlayerCommands.Add_CanExecute);
            DeleteFromPlaylist = new RelayCommand(PlayerCommands.DeleteFrom_Execute, PlayerCommands.DeleteFrom_CanExecute);
            ModifyPlaylist = new RelayCommand(PlayerCommands.Modify_Execute, PlayerCommands.Modify_CanExecute);
            DeletePlaylist = new RelayCommand(PlayerCommands.Delete_Execute, PlayerCommands.Delete_CanExecute);
            OpenBibliotheque = new RelayCommand(PlayerCommands.OpenBiblio_Execute, PlayerCommands.OpenBiblio_CanExecute);
        }
    }
}
