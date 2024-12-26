using HGL.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Scipting
{
    public abstract class HGLScript
    {
        public GameObject PinnedObject { get; protected set; }
        public abstract string Name { get; }
        public bool MustRemove { get; private set; }
        public HGLScript(GameObject gameObject)
        {
            PinnedObject = gameObject;
        }
        protected void RemoveScript()
        {
            SceneManager.Instance.LoadedScene.Render3DModel.RemoveFromRender(PinnedObject);
            MustRemove = true;
        }
        public abstract void OnUpdate();

    }
}
