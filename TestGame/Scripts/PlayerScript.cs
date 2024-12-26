using HGL.Other;
using HGL.Scenes;
using HGL.Scipting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
namespace TestGame.Scripts
{
    internal class PlayerScript : HGLScript
    {
        public override string Name => "PlayerScript";
        public PlayerScript(GameObject gameObject) : base(gameObject)
        {

        }
        public override void OnUpdate()
        {
            if (KeyboardManager.Instance.KeyIsPress(Keys.A))
            {
                if (PinnedObject.MainTransform.Position.X >= -10)
                    PinnedObject.MainTransform.Move(new Vector3(-0.01f, 0, 0));
            }
            if (KeyboardManager.Instance.KeyIsPress(Keys.D))
            {
                if(PinnedObject.MainTransform.Position.X<=10)
                PinnedObject.MainTransform.Move(new Vector3(0.01f, 0, 0));
            }
        }
    }
}
