using HGL.Render;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Scenes
{
    public abstract class Scene
    {

        public abstract string Name { get; }
        public GameObject3DRender Render3DModel { get; protected set; }
        public Camera MainCamera { get; protected set; } = new Camera();
        protected abstract float DegreesProjection {get;}
        protected abstract float DepthNearProjection { get; }
        protected abstract float DepthFarProjection {get; }
        private float _aspect=1;
        public virtual Matrix4 ProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), _aspect, DepthNearProjection, DepthFarProjection);
        }
        protected abstract void InitializateRenders();
        public virtual void OnLoad()
        {
            InitializateRenders(); 
        }
        public virtual void OnResize(FramebufferResizeEventArgs e)
        {
            _aspect = (float)e.Width / (float)e.Height;
           
        }
        public virtual void Update(FrameEventArgs args)
        {

        }
        public virtual void Render()
        {
            Render3DModel.RunRender();
        }
        private bool _initializateRenders = false;
        public Scene()
        {
        }
    }
}
