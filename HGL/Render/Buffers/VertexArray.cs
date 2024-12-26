using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
namespace HGL.Render.Buffers
{
    public class VertexArray
    {
        public VertexData[] Data { get; set; } = new VertexData[0];
        public int MaxSize { get; set; }
        public int Id { get; set; }
        public VertexAttribPointerType PointerType;
        public void EnableVertexArray()
        {
            foreach (var item in Data)
            {
                GL.VertexAttribPointer(item.Index, item.Size, PointerType, false, MaxSize, item.Offset);
                GL.EnableVertexAttribArray(item.Index);

            }
        }
        public void Bind()
        {
            GL.BindVertexArray(Id);
        }
        public void Delete()
        {
            GL.DeleteVertexArray(Id);
        }
        public void DisableVertexArray()
        {
            foreach (var item in Data)
            {
                GL.DisableVertexAttribArray(item.Index);
            }
        }
    }
}
