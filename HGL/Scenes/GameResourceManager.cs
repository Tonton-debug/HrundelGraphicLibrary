using HGL.Other;
using HGL.Other.Properties;
using HGL.Render.Common;
using HGL.Render.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Scenes
{
    public class GameResourceManager
    {
        private static GameResourceManager? instance;
        private ResourceProperties _properties=ResourceProperties.Default;
        public static GameResourceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameResourceManager();
                    instance.CreateResourcesFromDirectory();
                }
                return instance;
            }
        }
        private GameResourceManager()
        {
            
        }
        public void SetProperties(ResourceProperties resource)
        {
            _properties = resource;
        }
        public void CreateResourcesFromDirectory()
        {
            string[] _paths = [

                _properties.Path+"\\Shaders\\",
                _properties.Path+"\\Textures\\",
                _properties.Path+"\\Models\\"
            ];
            int index = 0;
            foreach (var item in _paths)
            {

                if (!Directory.Exists(item))
                    throw new Exception("Directory " + item + " not exit!");
                foreach (var file in Directory.GetFiles(item))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    string nameResource = fileInfo.Name.Split(".")[0]; 
                    switch (index)
                    {
                        case 0:
                            if (fileInfo.Extension.Equals(".frag"))
                            AddResoruce(new ShaderProgram(file.Replace(".frag", ".vert"), file, nameResource));
                            break;
                        case 1:
                            AddResoruce(new Texture(file, nameResource));
                            break;
                        case 2:
                            if (fileInfo.Extension.Equals(".obj"))
                                AddResoruce(ModelLoader.LoadFromObj(file, _properties.BaseNameShaderModel));
                            break;

                    }
                }
                    index += 1;
            }
        }
        private List<GameResource> _gameResources = new List<GameResource>();
        public T LoadResoruce<T>(string name) where T:GameResource
        {
            T findObject = _gameResources.Find((resource) => resource.Name.Equals(name) && resource is T) as T;
            if (findObject==null)
            {
                GameLogger.Instance.Write("GameResource " + name + " not exit");
                throw new ArgumentNullException("GameResource " + name + " not exit");
            }
            return findObject;
        }
        public void AddResoruce<T>(T gameResource) where T:GameResource
        {
            if (_gameResources.Find((resource)=> resource.Name.Equals(gameResource.Name)&& resource is T) != null)
            {
                GameLogger.Instance.Write("GameResource " + gameResource.Name + " already exit");
                throw new Exception("Game resource " + gameResource.Name + " already exit");
            }
            _gameResources.Add(gameResource);

        }
    }
}
