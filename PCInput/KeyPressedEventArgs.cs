using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace XGT.PCInput
{
    class KeyPressedEventArgs : EventArgs
    {
        public Keys KeyPressed;

        public KeyPressedEventArgs(Keys lKeyPressed)
        {
            KeyPressed = lKeyPressed;
        }
    }
}
