using HGL.Render;
using HGL.Render.Model;
using HGL.Scenes;
using HGL.Scipting;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGame.Scripts;

namespace TestGame
{
    internal class MainScene : Scene
    {
        public override string Name => "MainScene";

        protected override float DegreesProjection => 45;

        protected override float DepthNearProjection => 0.1f;

        protected override float DepthFarProjection => 1000;
        private GameObject _player;
        private EnemyCreator _enemyCreator = new EnemyCreator();
        public override void OnLoad()
        {
            base.OnLoad();
            InitializateScripts();
            MainCamera.Target = new Vector3(0, 10, 0);
            MainCamera.Position = new Vector3(0, 20, 30);
        }
        private void InitializateScripts()
        {
            HGLScriptManager.Instance.AddScript(new PlayerScript(_player));
        }
        public override void Update(FrameEventArgs a)
        {
            _enemyCreator.Update((float)a.Time);
        }
        protected override void InitializateRenders()
        {
            Render3DModel = new GameObject3DRender(this);
            GameObject gameObject = new GameObject(GameResourceManager.Instance.LoadResoruce<GameModel>("platform"),"platform");
            gameObject.MainTransform.Rotate = new Vector3(0, 90, 0);
            gameObject.MainTransform.Position = new Vector3(0, 0, 100);
            gameObject.MainTransform.Scale = new Vector3(20, 1, 1500);
            _player = new GameObject(GameResourceManager.Instance.LoadResoruce<GameModel>("player"), "player");
            _player.MainTransform.Position = new Vector3(0, 10, 10);
            Render3DModel.AddToRender(gameObject);
            Render3DModel.AddToRender(_player);
        }
    }
}
