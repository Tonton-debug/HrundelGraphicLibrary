using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Scenes
{
    public abstract class GameResource
    {
        public readonly string Path;
        public readonly string Name;
        public GameResource(string path, string name)
        {
            Path = path;
            Name = name;
        }
        public void Save()
        {
            GameResourceManager.Instance.AddResoruce(this);
        }
    }
}
