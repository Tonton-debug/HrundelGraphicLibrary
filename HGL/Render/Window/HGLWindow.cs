using HGL.Other;
using HGL.Scenes;
using HGL.Scipting;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Render.Window
{
    public class HGLWindow : GameWindow
    {
        private Scene _mainScene=>SceneManager.Instance.LoadedScene;
        public static HGLWindow Instance { get; private set; }
        public HGLWindow():this(GameWindowSettings.Default,NativeWindowSettings.Default)
        {
            Instance = this;
        }
        public HGLWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
           
        }
        protected override void OnLoad()
        {
            base.OnLoad();
            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(0, 0.7f, 1, 1.0f);
            _mainScene.OnLoad();
            UpdateFrame += HGLScriptManager.Instance.OnUpdateFrame;
            KeyboardManager.Create(this);
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            _mainScene.Update(args);
        }
        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            base.OnFramebufferResize(e);
            _mainScene.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
            
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (_mainScene == null)
                return;
            _mainScene.Render();
            SwapBuffers();
        }

    }
}
