using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HGL.Scenes;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
namespace HGL.Render.Common
{
    public class ShaderProgram:GameResource
    {
        private int _hangle;
        private int _vertexShader;
        private int _fragmentShader;
        public ShaderProgram(string vertexPath, string fragmentPath, string name) : base(vertexPath, name)
        {
            string VertexShaderSource = File.ReadAllText(vertexPath);

            string FragmentShaderSource = File.ReadAllText(fragmentPath);
            CreateShader(ref _vertexShader, ShaderType.VertexShader, VertexShaderSource);
            CreateShader(ref _fragmentShader, ShaderType.FragmentShader, FragmentShaderSource);
            CreateAndLinkProgram(new int[] { _vertexShader, _fragmentShader });
        }
        public void Use()
        {
            GL.UseProgram(_hangle);
        }
        public void SetUniform4(string name, Matrix4 matrix)
        {

            int location = GL.GetUniformLocation(_hangle, name);

            GL.UniformMatrix4(location, true, ref matrix);
        }
        private void CreateAndLinkProgram(int[] shaders)
        {
            _hangle = GL.CreateProgram();
            foreach (var item in shaders)
            {
                GL.AttachShader(_hangle, item);
            }

            GL.LinkProgram(_hangle);

            GL.GetProgram(_hangle, GetProgramParameterName.LinkStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetProgramInfoLog(_hangle);
                Console.WriteLine(infoLog);
            }
        }
        private void CreateShader(ref int shader, ShaderType shaderType, string source)
        {
            shader = GL.CreateShader(shaderType);
            GL.ShaderSource(shader, source);
            GL.CompileShader(shader);
            GL.GetShader(shader, ShaderParameter.CompileStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(shader);
                Console.WriteLine(infoLog);
            }
        }
    }
}
