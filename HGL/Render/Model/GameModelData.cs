using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGL.Render.Buffers;
using OpenTK.Graphics.OpenGL;
namespace HGL.Render.Model
{
    public class GameModelData
    {
        private List<float> _mainData;
        private GameBuffer _mainBuffer  = new GameBuffer();
        private VertexArray _vertexArray = new VertexArray();
        public int TotalSize
        {
            get
            {
                int a = _vertexArray.MaxSize / 4;
                return _mainData.Count / (a == 0 ? 1 : a);
            }
        }
        public GameModelData(List<float> mainData)
        {
            _mainData = mainData;
            Initializate();
        }
        public void Destroy()
        {
            _mainBuffer.Delete();
            _vertexArray.Delete();
        }
        private void Initializate()
        {
            _mainBuffer = BufferCreator.Init.CreateVertexBuffer(BufferUsageHint.StaticDraw);
            _mainBuffer.FillArrayBuffer(_mainData.ToArray());
            _vertexArray = BufferCreator.Init.CreateVertexArray(new VertexData[] { new VertexData() { Index = 0, Size = 3, Offset = 0 }, new VertexData() { Index = 1, Size = 2, Offset = 3 * sizeof(float) } }, 5 * sizeof(float), VertexAttribPointerType.Float);

            _vertexArray.EnableVertexArray();

        }
        public void Bind()
        {
            _vertexArray.Bind();
        }
        public void UpdateData(List<float> data)
        {
            _mainData = data;
            _mainBuffer.FillArrayBuffer(_mainData.ToArray());
        }
        public List<float> GetMainData()
        {
            return _mainData;
        }
    }
}
