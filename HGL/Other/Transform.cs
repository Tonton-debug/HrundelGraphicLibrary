using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Other
{
    public class Transform
    {
        public Vector3 Position { get; set; }
        public Vector3 Scale { get; set; } = Vector3.One;
        public Vector3 Rotate { get; set; }
        public Matrix4 TranslationMatrix
        {
            get
            {
                return Matrix4.CreateTranslation(Position);
            }
        }
        public Matrix4 ScaleMatrix
        {
            get
            {
                return Matrix4.CreateScale(Scale);
            }
        }
        public void Move(Vector3 position)
        {
            Position += position;
        }
        public Matrix4 RotateMatrix
        {
            get
            {
                return Matrix4.Identity * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(Rotate.X)) * Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(Rotate.Y)) * Matrix4.CreateRotationZ((float)MathHelper.DegreesToRadians(Rotate.Z));
            }
        }
        public Matrix4 ResultMatrix
        {
            get
            {
                return RotateMatrix * ScaleMatrix * TranslationMatrix;
            }
        }
    }
}
