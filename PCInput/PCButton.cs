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
        private Keys mHotKey;

        /// <summary>
        /// The location where this button will be drawn
        /// </summary>
        public Rectangle Location
        {
            get
            {
                return mLocation;
            }
        }

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
            get
            {
                return mHotKey;
            }
            set
            {
                Type keyboardManager = typeof(KeyboardManager);
                EventInfo hotkeyEvent = keyboardManager.GetEvent(value.ToString() + "KeyPressed");
                MethodInfo hotKeyMethod = this.GetType().GetMethod("LeftMousePressed");
                HotKeyHandler myDelegate = new HotKeyHandler(HotKeyMethod);
                hotkeyEvent.AddEventHandler(null, myDelegate);
                //Delegate hotkeyHandler = Delegate.CreateDelegate(hotKeyMethod.GetType(), hotKeyMethod);
                  //hotkeyEvent.AddEventHandler(null, HotKeyPressed);


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

        public void ConfigureButton(PCButtonState lButtonState, Point position)
        {
            mStartPoints[(int)lButtonState] = position;
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
