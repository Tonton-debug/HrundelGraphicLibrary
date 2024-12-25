using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using OpenTK.Graphics.OpenGL;

namespace HGL.Render.Buffers
{
    public class BufferCreator
    {
        private static BufferCreator? _bufferCreator;
        public static BufferCreator Init
        {
            get
            {
                if (_bufferCreator == null)
                    _bufferCreator = new BufferCreator();
                return _bufferCreator;
            }
        }
        private BufferCreator()
        {

        }
        public VertexArray CreateVertexArray(VertexData[] data, int size, VertexAttribPointerType pointer)
        {
            int id = GL.GenVertexArray();
            GL.BindVertexArray(id);
            VertexArray vertexArray = new VertexArray();
            vertexArray.Id = id;
            vertexArray.Data = data;
            vertexArray.MaxSize = size;
            vertexArray.PointerType = pointer;
            return vertexArray;

        }
        public GameBuffer CreateVertexBuffer(BufferUsageHint get)
        {
            int id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
            GameBuffer buffer = new GameBuffer();
            buffer.Id = id;
            buffer.Target = BufferTarget.ArrayBuffer;
            buffer.TypeDraw = get;
            return buffer;
        }
    }
}
