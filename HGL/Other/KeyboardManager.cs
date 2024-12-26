using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGL.Other
{
    public class KeyboardManager
    {
        private static KeyboardManager _instance;
        public delegate void UpKey(Keys key);
        public delegate void DownKey(Keys key);
        public event UpKey UpKeyEvent;
        public event DownKey DownKeyEvent;
        public static KeyboardManager Instance
        {
            get
            {
                if (_instance == null)
                    throw new ArgumentNullException("KeyboardManager not created");
                return _instance;
            }
        }
        public bool KeyIsPress(Keys key)
        {
            return _isPress[key];
        }
        private GameWindow _gameWindow;
        private KeyboardState _state;
        public static void Create(GameWindow gameWindow)
        {
            _instance = new KeyboardManager(gameWindow);
        }
        private KeyboardManager(GameWindow gameWindow)
        {
            _gameWindow = gameWindow;
            _state = _gameWindow.KeyboardState;
            _gameWindow.UpdateFrame += UpdateFrame;
            InitializateDictionary();
        }
        private void InitializateDictionary()
        {
            foreach (var item in Enum.GetValues(typeof(Keys)).Cast<Keys>())
            {
                if (_isPress.ContainsKey(item))
                    continue;
                _isPress.Add(item, false);
            }
        }
        private Dictionary<Keys, bool> _isPress = new Dictionary<Keys, bool>();
        private void UpdateFrame(FrameEventArgs obj)
        {
            List<Keys> keys = Enum.GetValues(typeof(Keys)).Cast<Keys>().ToList();
            keys.RemoveAt(keys.Count - 1);
            foreach (var item in keys)
            {
                if (_state.IsKeyReleased(item))
                {
                    _isPress[item] = false;
                    UpKeyEvent?.Invoke(item);
                }
                if (_state.IsKeyPressed(item))
                {
                    _isPress[item] = true;
                    DownKeyEvent?.Invoke(item);
                }
            }
        }
    }
}
