
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HGL.Render.Common;
using HGL.Scenes;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
namespace HGL.Render.Model
{
    public class ModelLoader
    {
        public static GameModel LoadFromObj(string path, string nameShader)
        {
            List<Vector3> vertexs = new List<Vector3>();
            List<Vector2> vertexsTex = new List<Vector2>();
            List<float> finalVertexs = new List<float>();
            string pathObj = path;
            string pathMtl = path.Replace(".obj", ".mtl");
            if (!File.Exists(pathObj) || !File.Exists(pathMtl))
            {

                //  Logs.WriteLog("OBJ or MTL file" + name + " not found");
                throw new FileNotFoundException("OBJ or MTL file " + path + " not found");
            }
            string[] infoObj = File.ReadAllLines(pathObj);
            string[] infoMtl = File.ReadAllLines(pathMtl);

            foreach (string line in infoObj)
            {
                string[] infoLine = line.Replace(".", ",").Split(" ");

                switch (infoLine[0])
                {
                    case "v":
                        vertexs.Add(new Vector3(float.Parse(infoLine[1]), float.Parse(infoLine[2]), float.Parse(infoLine[3])));

                        break;
                    case "vn":

                        break;
                    case "vt":
                        vertexsTex.Add(new Vector2(float.Parse(infoLine[1]), float.Parse(infoLine[2])));
                        break;
                    case "f":
                        for (int i = 1; i < infoLine.Length; i += 1)
                        {
                            string[] faces = infoLine[i].Split("/");
                            finalVertexs.Add(vertexs[int.Parse(faces[0]) - 1].X);
                            finalVertexs.Add(vertexs[int.Parse(faces[0]) - 1].Y);
                            finalVertexs.Add(vertexs[int.Parse(faces[0]) - 1].Z);
                            finalVertexs.Add(vertexsTex[int.Parse(faces[1]) - 1].X);
                            finalVertexs.Add(vertexsTex[int.Parse(faces[1]) - 1].Y);
                        }

                        break;
                }
            }
            GameModelData gameModelData = new GameModelData(finalVertexs);
            string nameTexture = "";
            foreach (string line in infoMtl)
            {
                if (line.Split(" ")[0].Equals("map_Kd"))
                    nameTexture = line.Split(" ")[1].Split("/").Last().Split(".")[0];

            }
            Texture texture = GameResourceManager.Instance.LoadResoruce(nameTexture+"T") as Texture;
            ShaderProgram shaderProgram= GameResourceManager.Instance.LoadResoruce(nameShader) as ShaderProgram;
            GameModel model3D = new GameModel(gameModelData, shaderProgram, texture, pathObj,new FileInfo(pathObj).Name.Split(".")[0]+"M");
            return model3D;

        }
    }
}

