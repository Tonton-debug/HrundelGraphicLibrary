using HGL.Scenes;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Scipting
{
    public class HGLScriptManager
    {
        private static HGLScriptManager _instance;
        public static HGLScriptManager Instance
        {
            get
            {
                if(_instance==null)
                    _instance=new HGLScriptManager();
                return _instance;
            }
        }
        private List<HGLScript> _scripts = new List< HGLScript>();
        private HGLScriptManager()
        {

        }
        public void RemoveScript(GameObject gameObject)
        {
        }
        public void AddScript(HGLScript hGLScript)
        {
            _scripts.Add(hGLScript);
        }
        private void RemoveScripts()
        {
            _scripts.RemoveAll((script) => script.MustRemove);
        }
        public void OnUpdateFrame(FrameEventArgs args)
        {
            RemoveScripts();
            foreach (var item in _scripts)
            {
                item.OnUpdate();
            }
        }
    }
}
