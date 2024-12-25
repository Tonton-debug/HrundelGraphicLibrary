using HGL.Render;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Scenes
{
    public abstract class Scene
    {
        protected GameObject3DRender Render3DModel { get; set; }
        public Camera MainCamera { get; protected set; } = new Camera();
        public abstract Matrix4 ProjectionMatrix();
        protected abstract void InitializateRenders();
        protected abstract void OnLoad();
        protected virtual void Update()
        {

        }
        private bool _initializateRenders = false;
        public Scene()
        {
            InitializateRenders();
            OnLoad();
            
        }
        public void UpdateRenders()
        {
            Update();
            Render3DModel.RunRender();
        }
    }
}
