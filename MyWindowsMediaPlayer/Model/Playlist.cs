using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Model
{
    public class OneFile
    {
        #region Fields
        public string Name { get; private set; }
        public string Path { get; private set; }
        #endregion // Fields

        private string getNameFromPath(string path)
        {
            string[] tab = path.Split('\\');
            return (tab.Last());
        }

        public OneFile(string path)
        {
            Path = path;
            Name = getNameFromPath(path);
        }
    }

    public class Playlist
    {
        #region Fields
        readonly string         Name;
        public List<OneFile>    Files { get; private set; }
        #endregion // Fields

        public Playlist(string name)
        {
            Name = name;
        }

        public void AddToPlaylist(string path)
        {
            Files.Add(new OneFile(path));
        }

        public bool RemoveFromPlaylist(string path)
        {
            if (!Files.Exists(x => x.Path.Equals(path)))
                return (false);
            Files.Remove(Files.Find(x => x.Path.Equals(path)));
            return (true);
        }
    }
}
