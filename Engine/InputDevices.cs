using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectInput;

namespace Engine
{
    public class InputDevices
    {
        public delegate void KeyDown(ArrayList keys);
        public delegate void KeyUp(ArrayList keys);
        private event KeyDown EKeyDown;
        private event KeyUp EKeyUp;
        private ArrayList keys = new ArrayList();
        public ArrayList keysres = new ArrayList();
        private ArrayList pressedkey = new ArrayList();

        private Device keyboard = null;
        private Device mouse = null;
        private Control parentWindow = null;

        public InputDevices(Control parent)
        {
            parentWindow = parent;
            keyboard = new Device(SystemGuid.Keyboard);
            keyboard.SetCooperativeLevel(parent, CooperativeLevelFlags.Foreground | CooperativeLevelFlags.NonExclusive);
            mouse = new Device(SystemGuid.Mouse);
            mouse.SetCooperativeLevel(parent, CooperativeLevelFlags.Foreground | CooperativeLevelFlags.NonExclusive);
        }

        public void onKeyUp(KeyUp ku)
        {
            EKeyUp = ku;
        }

        public void onKeyDown(KeyDown kd)
        {
            EKeyDown = kd;
        }

        public void Processing()
        {
            keyboard.Acquire();
            mouse.Acquire();
            while (true)
            {
                pressedkey.Clear();
                keysres.Clear();
                foreach(Key k in keyboard.GetPressedKeys())
                    pressedkey.Add(k);
                foreach (Key k in pressedkey)
                    if (keys.IndexOf(k) == -1)
                    {
                        keys.Add(k);
                        keysres.Add(k);
                    }
                EKeyDown(keysres);
                keysres.Clear();
                foreach (Key k in keys)
                    if (pressedkey.IndexOf(k) == -1)
                    {
                        keys.Remove(k);
                        keysres.Add(k);
                    }
                EKeyUp(keysres);
            }
        }
    }
}
