using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectInput;

namespace Engine
{
    public class InputDevices
    {
        private Device keyboard = null;
        private Device mouse = null;
        public InputDevices(Control parent)
        {

            keyboard = new Device(SystemGuid.Keyboard);
            keyboard.SetCooperativeLevel(parent, CooperativeLevelFlags.Foreground | CooperativeLevelFlags.NonExclusive);
            keyboard.Acquire();
            mouse = new Device(SystemGuid.Mouse);
            mouse.SetCooperativeLevel(parent, CooperativeLevelFlags.Foreground | CooperativeLevelFlags.NonExclusive);

        }

        public String GetPressedKey()
        {
            String result = "";
            foreach (Key k in keyboard.GetPressedKeys())
                result += k.ToString() + " ";
            return result;
        }
    }
}
