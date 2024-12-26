using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Other.Properties
{
    public class ResourceProperties
    {
        public static ResourceProperties Default => new ResourceProperties();
        public string Path { get; set; } = Directory.GetCurrentDirectory()+"\\Resources\\";
        public string BaseNameShaderModel { get; set; } = "base3D";
    }
}
