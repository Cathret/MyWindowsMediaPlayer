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

namespace MyWindowsMediaPlayer.View
{
    public partial class PlaylistWindow : Window
    {
        public PlaylistWindow(e_PlaylistMessage whatToDo)
        {
            InitializeComponent();
            this.DataContext = new ViewModelPlaylist(whatToDo);
        }
    }
}
