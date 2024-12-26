using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGL.Other;
using HGL.Render.Model;

namespace HGL.Scenes
{
    public class GameObject
    {
        public readonly string Name;
        public Transform MainTransform { get; private set; } = new Transform();
        public GameModel Model { get; private set; }
        public GameObject(GameModel gameModel, string name)
        {
            Model = gameModel;
            Name = name;
        }
        public void Destroy()
        {
            Model.Destroy();
        }

    }
}
