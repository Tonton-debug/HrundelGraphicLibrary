using HGL.Scenes;
using HGL.Scipting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using HGL.Render.Window;
namespace TestGame.Scripts
{
    internal class EnemyScript : HGLScript
    {
        private float _speed;
        private GameObject _player;
        public EnemyScript(GameObject gameObject) : base(gameObject)
        {
            Random random = new Random();
            _speed = random.Next(1,7)*0.01f;
            _player = SceneManager.Instance.LoadedScene.Render3DModel.FindGameObject("player");
        }

        public override string Name => "EnemyScript";

        public override void OnUpdate()
        {
            PinnedObject.MainTransform.Move(new Vector3(0, 0, _speed));
            if (PinnedObject.MainTransform.Position.Z >= 20)
            {
                
                RemoveScript();
            }
            if ((_player.MainTransform.Position - PinnedObject.MainTransform.Position).Length <= 2.5f)
            {
                HGLWindow.Instance.Close();
            }
        }
    }
}
