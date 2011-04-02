using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XGT.PCInput
{
    public static class ButtonManager
    {
        private static List<PCButton> mButtons;

        public static void AddButton(PCButton button)
        {
            mButtons.Add(button);
        }

        public static void Update()
        {
            Point mousePosition = MouseManager.MousePosition;
            foreach (PCButton button in mButtons)
            {

            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
