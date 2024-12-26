using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics.GL;
using OpenTK.Mathematics;
using HGL.Scenes;
using System.Collections.Concurrent;
namespace HGL.Render
{
    public class GameObject3DRender : GameRender<GameObject>
    {
        private List<GameObject> _gameObjects = new List<GameObject>();
        public GameObject3DRender(Scene scene):base(scene)
        {

        }
        public override void RemoveFromRender(GameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
        }
        public GameObject FindGameObject(string name)
        {
            return _gameObjects.Find((obj) => obj.Name.Equals(name));
        }
        public override void AddToRender(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }
        public override void RunRender()
        {
            foreach (var item in _gameObjects)
            {
                item.Model.Shader.SetUniform4("view", MainScene.MainCamera.LookAt);
                item.Model.Shader.SetUniform4("transform", item.MainTransform.ResultMatrix);
                item.Model.Shader.SetUniform4("projection", MainScene.ProjectionMatrix());
                item.Model.Shader.Use();
                item.Model.Data.Bind();
                item.Model.MainTexture.Use();
                GL.DrawArrays(PrimitiveType.Triangles, 0, item.Model.Data.TotalSize);
            }
        }
    }
}
