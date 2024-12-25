using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Other
{
    internal class GameLogger
    {
        private static GameLogger? _instance;
        private string _path;
        private string _fileName;
        private string _finalPath;
        public static GameLogger Instance
        {
            get
            {
                if (_instance == null)
                    Create("Logs");
                return _instance;
            }
        }
        public static void Create(string path)
        {
            _instance = new GameLogger(path);
        }
        private GameLogger(string path)
        {
            _path = Directory.GetCurrentDirectory() + "/" + path;
            _fileName = "Log" + DateTime.Now.Year + " " + DateTime.Now.Month + " " + DateTime.Now.Day + " " + DateTime.Now.Hour + " " + DateTime.Now.Minute + " " + DateTime.Now.Second + ".txt";
            _finalPath = _path + "/" + _fileName;
            InitializatePath();
        }
        private void InitializatePath()
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
            using (File.Create(_finalPath));

        }
        public void Write(string text)
        {
            string finalText = "[" + DateTime.Now.ToString() + "] " + text + "\n";
            File.AppendAllText(_finalPath, finalText);
        }
    }
}
