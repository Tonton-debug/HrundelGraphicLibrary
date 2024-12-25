using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGL.Scenes;

namespace HGL.Render
{
    public abstract class GameRender<T>
    {
        public readonly Scene MainScene;
        public GameRender(Scene scene)
        {
            MainScene = scene;
        }
        public abstract void AddToRender(T obj);
        public abstract void RemoveFromRender(T obj);
        public abstract void RunRender();
    }
}
