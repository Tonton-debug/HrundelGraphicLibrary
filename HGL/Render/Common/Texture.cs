using StbImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Reflection.Metadata;
using HGL.Scenes;
namespace HGL.Render.Common
{
    public class Texture:GameResource
    {
        public readonly string Path;
        private int _handle;
        public Texture(string path,string name):base(path,name)
        {
            Path = path;
            Initializate();
        }
        private void Initializate()
        {
            _handle = GL.GenTexture();

            // Bind the handle
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, _handle);
            StbImage.stbi_set_flip_vertically_on_load(1);
            // Load the image.
            ImageResult image = ImageResult.FromStream(File.OpenRead(Path), ColorComponents.RedGreenBlueAlpha);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }
        public void Use()
        {
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, _handle);
        }

    }
}
