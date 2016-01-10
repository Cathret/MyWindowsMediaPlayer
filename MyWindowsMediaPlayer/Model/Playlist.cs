using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWindowsMediaPlayer.ViewModel;
using System.IO;

namespace MyWindowsMediaPlayer.Model
{
    public class OneFile
    {
        #region Fields
        public string Path { get; private set; }
        public string Name { get; private set; }
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
        public string Name { get; private set; }
        public string Path { get; private set; }
        public int NumberOfEntries { get; private set; }
        public List<OneFile>    Files { get; private set; }
        #endregion // Fields

        public Playlist(string path)
        {
            try
            {
                Path = path;
                Name = path.Substring(0, path.IndexOf(".pls")).Split('\\').Last();
                NumberOfEntries = 0;
                Files = new List<OneFile>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void AddToPlaylist(string path)
        {
            Files.Add(new OneFile(path));
            NumberOfEntries++;
        }

        public bool RemoveFromPlaylist(string path)
        {
            if (NumberOfEntries <= 0 || !Files.Exists(x => x.Path.Equals(path)))
                return (false);
            Files.Remove(Files.Find(x => x.Path.Equals(path)));
            NumberOfEntries--;
            return (true);
        }

        public void ParsePlaylist()
        {
            var files = from lines in File.ReadLines(Path)
                        where lines.StartsWith("File")
                        select lines.Substring(lines.IndexOf('=') + 1);

            foreach (var f in files)
                AddToPlaylist(f);

            string[] fullLines = File.ReadAllLines(Path);
            if (!fullLines[0].Equals("[playlist]"))
                throw new Exception("Not a playlist file");
            if (!fullLines[1].Contains("NumberOfEntries="))
                throw new Exception("Not a playlist file");
            if (!(NumberOfEntries == Int32.Parse(fullLines[1].Substring(16))))
                throw new Exception("Bad playlist format");
        }

        public virtual string ToString()
        {
            return (Name);
        }
    }
}
