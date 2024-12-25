using HGL.Other;
using HGL.Render.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Scenes
{
    public class GameResourceManager
    {
        private static GameResourceManager? instance;
        public static GameResourceManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameResourceManager();
                return instance;
            }
        }


        private Dictionary<string, GameResource> _gameResources = new Dictionary<string, GameResource>();
        private GameResourceManager()
        {

        }
        public GameResource LoadResoruce(string name)
        {
            if (!_gameResources.ContainsKey(name))
            {
                GameLogger.Instance.Write("GameResource " + name + " not exit");
                throw new ArgumentNullException("GameResource " + name + " not exit");
            }
            return _gameResources[name];
        }
        public void AddResoruce(GameResource gameResource)
        {
            if (_gameResources.ContainsKey(gameResource.Name))
            {
                GameLogger.Instance.Write("GameResource " + gameResource.Name + " already exit");
                return;
            }
            _gameResources.Add(gameResource.Name, gameResource);

        }
    }
}
