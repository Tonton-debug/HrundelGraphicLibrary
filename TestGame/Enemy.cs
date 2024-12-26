using HGL.Render.Model;
using HGL.Scenes;
using HGL.Scipting;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using TestGame.Scripts;

namespace TestGame
{
    internal class Enemy
    {
        private GameObject _enemy;
        public Enemy(Vector3 position)
        {
            _enemy = new GameObject(GameResourceManager.Instance.LoadResoruce<GameModel>("enemy"), "enemy" + new Random().Next(0, 1000));
            _enemy.MainTransform.Position = position;
            SceneManager.Instance.LoadedScene.Render3DModel.AddToRender(_enemy);
            HGLScriptManager.Instance.AddScript(new EnemyScript(_enemy));
        }

    }
}
