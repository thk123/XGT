using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace XGT.PCInput
{
    public class PCButton
    {
        private Texture2D mButtonSprite;
        private Rectangle mDrawRectange;
        private Rectangle mLocation;
        private Point[] mStartPoints;
        private PCButtonState mButtonState;
        private EventInfo hotkeyEvent;
        private EventHandler hotkeyEventHandler;

        /// <summary>
        /// The current state of the button
        /// </summary>
        public PCButtonState ButtonState
        {
            get
            {
                return mButtonState;
            }
        }

        public Keys HotKey
        {
            set
            {
                if (hotkeyEvent != null)
                {
                    hotkeyEvent.RemoveEventHandler(null, hotkeyEventHandler);
                }
                Type keyboardManager = typeof(KeyboardManager);
                hotkeyEvent = keyboardManager.GetEvent(value.ToString() + "KeyPressed");
                MethodInfo hotKeyMethod = this.GetType().GetMethod("LeftMousePressed");
                hotkeyEventHandler = new EventHandler(HotKeyMethod);
                hotkeyEvent.AddEventHandler(null, hotkeyEventHandler);
            }
        }

        public event EventHandler MouseHover = delegate { };
        public event EventHandler MouseUnHover = delegate { };
        public event EventHandler LeftMousePress = delegate { };
        public event EventHandler LeftMouseRelase = delegate { };
        public event EventHandler LeftMouseDoubleClick = delegate { };
        public event EventHandler RightMousePress = delegate { };
        public event EventHandler RightMouseRelase = delegate { };
        public event EventHandler RightMouseDoubleClick = delegate { };

        public PCButton(Texture2D lButtonSprite, Rectangle lLocation)
        {
            mButtonSprite = lButtonSprite;
            mDrawRectange = new Rectangle(0, 0, lLocation.Width, lLocation.Height);
            mLocation = lLocation;

            mStartPoints = new Point[4];
            mButtonState = PCButtonState.none;
        }

        /// <summary>
        /// Set the positions of different button states
        /// </summary>
        /// <param name="lButtonState">The button state to define</param>
        /// <param name="position">The position of the button image in the sprite</param>
        public void ConfigureButton(PCButtonState lButtonState, Point position)
        {
            mStartPoints[(int)lButtonState] = position;
        }

        /// <summary>
        /// Checks to see if a button group's rectangle is big enough to contain the button and if not expands it
        /// </summary>
        /// <param name="lButtonGroupArea">The current rectangle of the button group</param>
        public void AddToButtonGroup(ref Rectangle lButtonGroupArea)
        {
            if (!lButtonGroupArea.Contains(mLocation))
            {
                {
                    int xDist = mLocation.X - lButtonGroupArea.X;
                    if (xDist < 0)
                    {
                        lButtonGroupArea.X = mLocation.X;
                        lButtonGroupArea.Width -= xDist;
                    }

                    xDist = mLocation.Right - lButtonGroupArea.Right;
                    if (xDist > 0)
                    {
                        lButtonGroupArea.Width += xDist;
                    }
                }
                {
                    int yDist = mLocation.Y - lButtonGroupArea.Y;
                    if (yDist < 0)
                    {
                        lButtonGroupArea.Y = mLocation.Y;
                        lButtonGroupArea.Height -= yDist;
                    }

                    yDist = mLocation.Bottom - lButtonGroupArea.Bottom;
                    if (yDist > 0)
                    {
                        lButtonGroupArea.Height += yDist;
                    }
                }
            }
        }

        public virtual bool CheckForCollision(Point position)
        {
            return mLocation.Contains(position);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(mButtonSprite, mLocation, mDrawRectange, Color.White);
        }

        public virtual void MouseHovered()
        {
            mButtonState = PCButtonState.hover;

            mDrawRectange.X = mStartPoints[(int)PCButtonState.hover].X;
            mDrawRectange.Y = mStartPoints[(int)PCButtonState.hover].Y;

            MouseHover(this, new EventArgs());
        }
        public virtual void MouseUnHovered()
        {
            mButtonState = PCButtonState.none;

            mDrawRectange.X = mStartPoints[(int)PCButtonState.none].X;
            mDrawRectange.Y = mStartPoints[(int)PCButtonState.none].Y;

            MouseUnHover(this, new EventArgs());
        }
        public virtual void LeftMousePressed()
        {
            mButtonState = PCButtonState.pressed;

            mDrawRectange.X = mStartPoints[(int)PCButtonState.pressed].X;
            mDrawRectange.Y = mStartPoints[(int)PCButtonState.pressed].Y;

            LeftMousePress(this, new EventArgs());
        }
        public virtual void LeftMouseReleased()
        {
            mButtonState = PCButtonState.released;

            mDrawRectange.X = mStartPoints[(int)PCButtonState.released].X;
            mDrawRectange.Y = mStartPoints[(int)PCButtonState.released].Y;

            LeftMouseRelase(this, new EventArgs());
        }
        public virtual void LeftMouseDoubeClicked()
        {
            mButtonState = PCButtonState.pressed;

            mDrawRectange.X = mStartPoints[(int)PCButtonState.pressed].X;
            mDrawRectange.Y = mStartPoints[(int)PCButtonState.pressed].Y;

            LeftMouseDoubleClick(this, new EventArgs());
        }
        public virtual void RightMousePressed()
        {
            //mButtonState = PCButtonState.pressed;

            //mDrawRectange.X = mStartPoints[(int)PCButtonState.pressed].X;
            //mDrawRectange.Y = mStartPoints[(int)PCButtonState.pressed].Y;

            RightMousePress(this, new EventArgs());
        }
        public virtual void RightMouseReleased()
        {
            //mButtonState = PCButtonState.released;

            //mDrawRectange.X = mStartPoints[(int)PCButtonState.released].X;
            //mDrawRectange.Y = mStartPoints[(int)PCButtonState.released].Y;

            RightMouseRelase(this, new EventArgs());
        }
        public virtual void RightMouseDoubeClicked()
        {
            //mButtonState = PCButtonState.pressed;

            //mDrawRectange.X = mStartPoints[(int)PCButtonState.pressed].X;
            //mDrawRectange.Y = mStartPoints[(int)PCButtonState.pressed].Y;

            RightMouseDoubleClick(this, new EventArgs());
        }

        private delegate void HotKeyHandler(object sender, EventArgs e);
        public void HotKeyMethod(object sender, EventArgs e)
        {
            LeftMousePressed();
        }
    }

    public enum PCButtonState
    {
        none = 0,
        hover,
        pressed,
        released,
    }
}
