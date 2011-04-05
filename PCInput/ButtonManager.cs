using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;

namespace XGT.PCInput
{
    public class ButtonManager
    {
        private List<PCButtonGroup> mButtons;
        private PCButton mUnderMouseButton;
        private Rectangle mExclusionRectangle;

        /// <summary>
        /// To specify a rectangle not to check for button collsisions (ie, if your UI is not in the middle)
        /// </summary>
        public Rectangle ExclusionRectangle
        {
            get
            {
                return mExclusionRectangle;
            }
            set
            {
                mExclusionRectangle = value;
            }
        }

        /// <summary>
        /// The button currently under the mouse (null if the mouse isn't over a button)
        /// </summary>
        public PCButton CurrentActiveButton
        {
            get
            {
                return mUnderMouseButton;
            }
        }

        /// <summary>
        /// Initalise the button manager
        /// </summary>
        public ButtonManager()
        {
            mUnderMouseButton = null;

            MouseManager.MouseMove += new EventHandler(MouseManager_MouseMove);
            MouseManager.LeftMousePress += new EventHandler(MouseManager_LeftMousePress);
            MouseManager.LeftMouseRelease += new EventHandler(MouseManager_LeftMouseRelease);
            MouseManager.LeftMouseDoubleClick += new EventHandler(MouseManager_LeftMouseDoubleClick);
            MouseManager.RightMousePress += new EventHandler(MouseManager_RightMousePress);
            MouseManager.RightMouseRelease += new EventHandler(MouseManager_RightMouseRelease);

            mButtons = new List<PCButtonGroup>();
            mButtons.Add(new PCButtonGroup()); //this is the default button group to check, always mButtons[0]
            mExclusionRectangle = new Rectangle(); //don't exclude anywhere unless told
        }

        /// <summary>
        /// Add the PCButton to the standard group
        /// </summary>
        /// <param name="button">The new PCButton, make sure you have already registered to any desired events</param>
        public void AddButton(PCButton button)
        {
            mButtons[0].AddButton(button); //add the button to the standard group
        }
        
        /// <summary>
        /// Add a set of buttons to the manager
        /// </summary>
        /// <param name="buttonGroup">A group of buttons (in close proximity)</param>
        /// <returns>The index of the group in this manager</returns>
        public int AddButtonGroup(PCButtonGroup buttonGroup)
        {
            mButtons.Add(buttonGroup);
            return mButtons.Count - 1;
        }

        /// <summary>
        /// Add a set of buttons to the manager in a new button group
        /// </summary>
        /// <param name="buttons">The buttons to add (in close proximity)</param>
        /// <returns></returns>The index of the group in this manager</returns>
        public int AddButtonGroup(params PCButton[] buttons)
        {
            PCButtonGroup buttonGroup = new PCButtonGroup(buttons);
            mButtons.Add(buttonGroup);
            return mButtons.Count - 1;
        }

        /// <summary>
        /// Draw all the buttons currently registerd with this button manager
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw the buttons with</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(PCButtonGroup buttonGroup in mButtons)
            {
                buttonGroup.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Draw buttons from a selected button group
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw the buttons with</param>
        /// <param name="drawGroup">The group to draw, eg the menu bar</param>
        public void Draw(SpriteBatch spriteBatch, PCButtonGroup drawGroup)
        {
            drawGroup.Draw(spriteBatch);
        }

        /// <summary>
        /// Draw buttons for a selected button group
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw the buttons with</param>
        /// <param name="drawGroupId">The index of the group to draw, eg the menu bar</param>
        /// <exception cref="IndexInvalidException">If the number is not a valid index</exception>
        public void Draw(SpriteBatch spriteBatch, int drawGroupId)
        {
            if (drawGroupId < mButtons.Count)
            {
                mButtons[drawGroupId].Draw(spriteBatch);
            }
            else
            {
                throw new Exception("Draw group out of bounds");
            }
        }

        private void MouseManager_MouseMove(object sender, EventArgs e)
        {
            Point mousePosition = MouseManager.MousePosition;
            if (mExclusionRectangle.Contains(mousePosition))
            {
                return;
            }
            if (mUnderMouseButton != null && mUnderMouseButton.CheckForCollision(mousePosition))
            {
                return;
            }
            else
            {
                if (mUnderMouseButton != null)
                {
                    mUnderMouseButton.MouseUnHovered();
                }
                mUnderMouseButton = null;
                foreach (PCButtonGroup buttonGroup in mButtons)
                {
                    mUnderMouseButton = buttonGroup.CheckForCollision(mousePosition);
                    if (mUnderMouseButton != null)
                    {
                        mUnderMouseButton.MouseHovered();
                    }

                }
            }
        }

        private void MouseManager_LeftMouseRelease(object sender, EventArgs e)
        {
            if (mUnderMouseButton != null && mUnderMouseButton.ButtonState == PCButtonState.pressed)
            {
                mUnderMouseButton.LeftMouseReleased();
            }
        }

        private void MouseManager_LeftMousePress(object sender, EventArgs e)
        {
            if (mUnderMouseButton != null)
            {
                mUnderMouseButton.LeftMousePressed();
            }
        }

        private void MouseManager_LeftMouseDoubleClick(object sender, EventArgs e)
        {
            mUnderMouseButton.LeftMouseDoubeClicked();
        }

        private void MouseManager_RightMouseRelease(object sender, EventArgs e)
        {
            mUnderMouseButton.RightMouseReleased();
        }

        private void MouseManager_RightMousePress(object sender, EventArgs e)
        {
            mUnderMouseButton.RightMousePressed();
        }    
    }
}