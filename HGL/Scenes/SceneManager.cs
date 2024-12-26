using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Scenes
{
    public class SceneManager
    {
        private static SceneManager _instance;
        private Dictionary<string, Scene> _scenes = new Dictionary<string, Scene>();
        public Scene LoadedScene { get; private set; }
        public static SceneManager Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new SceneManager();
                return _instance;
            }
        }
        private SceneManager()
        {

        }
       
       public void LoadScene(string name)
        {
            if (!_scenes.ContainsKey(name))
                return;
            LoadedScene = _scenes[name];
        }
        public void AddScene(Scene scene)
        {
            _scenes.Add(scene.Name, scene);
            if (LoadedScene == null)
                LoadedScene = _scenes[scene.Name];
        }
    }
}
