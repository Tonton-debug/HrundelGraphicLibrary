using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Render.Buffers
{
    public class GameBuffer
    {
        public int Id { get; set; }
        public BufferTarget Target { get; set; }
        public BufferUsageHint TypeDraw { get; set; }
        public void Bind()
        {
            GL.BindBuffer(Target, Id);
        }
        public void Delete()
        {
            GL.DeleteBuffer(Id);
        }
        public void FillArrayBuffer(float[] data)
        {
            Bind();
            GL.BufferData(Target, data.Length * sizeof(float), data, TypeDraw);
        }
    }
}
