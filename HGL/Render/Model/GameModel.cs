using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGL.Render.Common;
using HGL.Scenes;

namespace HGL.Render.Model
{
    public class GameModel:GameResource
    {
        public GameModelData Data { get; private set; }
        public ShaderProgram Shader { get; private set; }

        public Texture MainTexture { get; private set; }
        public GameModel(GameModelData data, ShaderProgram shaderProgram, Texture texture,string path,string name):base(path,name)
        {
            Data = data;
            Shader = shaderProgram;
            MainTexture = texture;
        }
        public void Destroy()
        {
            Data.Destroy();
        }
    }
}
