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
        static public readonly string PathPlaylist = ".\\playlists\\";
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

        public bool CreatePlaylistFile()
        {
            if (!Directory.Exists(PathPlaylist))
                Directory.CreateDirectory(PathPlaylist);
            else if (File.Exists(this.Path))
                return (false);
            try
            {
                File.Create(this.Path).Close();

                using (StreamWriter writer = new StreamWriter(this.Path))
                {
                    writer.WriteLine("[playlist]");
                    writer.WriteLine("NumberOfEntries=0");
                    writer.WriteLine("");
                    writer.WriteLine("Version=2");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return (true);
        }

        public void AddToPlaylist(string path, bool isReading)
        {
            NumberOfEntries++;
            OneFile newFile = new OneFile(path);
            if (!isReading)
            {
                string[] lines = File.ReadAllLines(this.Path);
                int place = 0;
                foreach (string line in lines)
                {
                    place++;
                    if (line.Contains("Version"))
                        break;
                }
                if (lines[1].Contains("NumberOfEntries="))
                    lines[1] = "NumberOfEntries=" + NumberOfEntries;
                using (StreamWriter writer = new StreamWriter(".tempFile"))
                {
                    int i = 0;
                    foreach (string line in lines)
                    {
                        i++;
                        if (place == i)
                        {
                            int seconds = -1;
                            writer.WriteLine("File" + NumberOfEntries + "=" + newFile.Path);
                            writer.WriteLine("Title" + NumberOfEntries + "=" + newFile.Name);
                            writer.WriteLine("Length" + NumberOfEntries + "=" + seconds);
                            writer.WriteLine("");
                        }
                        writer.WriteLine(line);
                    }
                }
                File.Replace(".tempFile", this.Path, this.Path + ".bak");
                File.Delete(this.Path + ".bak");
            }
            Files.Add(newFile);
        }

        public bool RemoveFromPlaylist(string path)
        {
            if (NumberOfEntries <= 0 || !Files.Exists(x => x.Path.Equals(path)))
                return (false);
            NumberOfEntries--;
            string[] lines = File.ReadAllLines(this.Path);
            int place = 0;
            foreach (string line in lines)
            {
                place++;
                if (line.Contains(path))
                    break;
            }
            if (lines[1].Contains("NumberOfEntries="))
                lines[1] = "NumberOfEntries=" + NumberOfEntries;
            using (StreamWriter writer = new StreamWriter(".tempFile"))
            {
                int i = 0;
                foreach (string line in lines)
                {
                    i++;
                    if (place < i || place > i + 3)
                        writer.WriteLine(line);
                }
            }
            File.Replace(".tempFile", path, path + ".bak");
            File.Delete(path + ".bak");
            Files.Remove(Files.Find(x => x.Path.Equals(path)));
            return (true);
        }

        public void ParsePlaylist()
        {
            var files = from lines in File.ReadLines(Path)
                        where lines.StartsWith("File")
                        select lines.Substring(lines.IndexOf('=') + 1);

            foreach (var f in files)
                AddToPlaylist(f, true);

            string[] fullLines = File.ReadAllLines(Path);
            if (!fullLines[0].Equals("[playlist]"))
                throw new Exception("Not a playlist file (doesn't have [playlist])");
            if (!fullLines[1].Contains("NumberOfEntries="))
                throw new Exception("Not a playlist file (dosen't have NumberOfEntries)");
            if (!(NumberOfEntries == Int32.Parse(fullLines[1].Substring(16))))
                throw new Exception("Bad playlist format (bad NumberOfEntries)");
        }

        public bool Empty()
        {
            if (NumberOfEntries <= 0)
                return (true);
            return (false);
        }
        public virtual string ToString()
        {
            return (Name);
        }
    }
}
