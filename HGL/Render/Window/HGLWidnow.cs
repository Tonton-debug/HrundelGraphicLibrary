using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Render.Window
{
    internal abstract class HGLWidnow : GameWindow
    {
        protected HGLWidnow():this(GameWindowSettings.Default,NativeWindowSettings.Default)
        {

        }
        protected HGLWidnow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

    }
}
