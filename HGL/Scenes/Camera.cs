using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Scenes
{
    public class Camera
    {
        public Vector3 Position { get; set; } = Vector3.Zero;
        public Vector3 Target { get; set; } = Vector3.Zero;
        public Vector3 Up { get; set; } = new Vector3(0, 1, 0);
        public Matrix4 LookAt
        {
            get
            {
                return Matrix4.LookAt(Position, Target, Up);
            }
        }
        public Camera() { }
    }
}
