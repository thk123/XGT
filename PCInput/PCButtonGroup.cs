﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XGT.PCInput
{
    public class PCButtonGroup
    {
        private List<PCButton> mButtons;
        private Rectangle buttonArea;

        /// <summary>
        /// Create a new button group with the specified buttons
        /// </summary>
        /// <param name="lButtons">The buttons to put in the group, should be in close proximity for greatest efficency</param>
        public PCButtonGroup(List<PCButton> lButtons)
        {
            mButtons = new List<PCButton>();
            buttonArea = new Rectangle();
            foreach (PCButton button in lButtons)
            {
                AddButton(button);
            }
        }

        /// <summary>
        /// Create a new button group with the specified buttons
        /// </summary>
        /// <param name="lButtons">The buttons to put in the group, should be in close proximity for greatest efficency</param>
        public PCButtonGroup(params PCButton[] lButtons)
        {
            mButtons = new List<PCButton>();
            for (int buttonId = 0; buttonId < lButtons.Length; buttonId++)
            {
                AddButton(lButtons[buttonId]);
            }
        }

        /// <summary>
        /// Add a button to an existing button group
        /// </summary>
        /// <param name="lButton">New button - should be in close proximity of other buttons for greatest efficency</param>
        public void AddButton(PCButton lButton)
        {
            lButton.AddToButtonGroup(ref buttonArea);
            mButtons.Add(lButton);
        }

        /// <summary>
        /// Checks for a collision between the mouse and all the buttons in this group
        /// </summary>
        /// <param name="lMousePoint">The position of the mouse</param>
        /// <returns></returns>
        public PCButton CheckForCollision(Point lMousePoint)
        {
            PCButton hitButton = null;

            if (buttonArea.Contains(lMousePoint))
            {
                foreach (PCButton button in mButtons)
                {
                    if (button.CheckForCollision(lMousePoint))
                    {
                        hitButton = button;
                        break;
                    }
                }
            }

            return hitButton;
        }

        /// <summary>
        /// Draw all the buttons in this group
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw the buttons with</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (PCButton button in mButtons)
            {
                button.Draw(spriteBatch);
            }
        }
    }
}
