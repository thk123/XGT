using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
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

        public Rectangle Location
        {
            get
            {
                return mLocation;
            }
        }

        public PCButtonState ButtonState
        {
            get
            {
                return mButtonState;
            }
        }

        public PCButton(Texture2D lButtonSprite, Rectangle lLocation)
        {
            mButtonSprite = lButtonSprite;
            mDrawRectange = new Rectangle(0, 0, lLocation.Width, lLocation.Height);
            mLocation = lLocation;

            mStartPoints = new Point[4];
            mButtonState = PCButtonState.none;
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
        public virtual void MousePressed()
        {
            mButtonState = PCButtonState.pressed;

            mDrawRectange.X = mStartPoints[(int)PCButtonState.pressed].X;
            mDrawRectange.Y = mStartPoints[(int)PCButtonState.pressed].Y;

            MousePress(this, new EventArgs());
        }
        public virtual void MouseReleased()
        {
            mButtonState = PCButtonState.released;

            mDrawRectange.X = mStartPoints[(int)PCButtonState.released].X;
            mDrawRectange.Y = mStartPoints[(int)PCButtonState.released].Y;

            MouseRelase(this, new EventArgs());
        }

        public void configureButton(PCButtonState lButtonState, Point position)
        {
            mStartPoints[(int)lButtonState] = position;
        }

        public virtual bool checkForCollision(Point position)
        {
            return mLocation.Contains(position);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(mButtonSprite, mLocation, mDrawRectange, Color.White);
        }

        public event EventHandler MouseHover = delegate { };
        public event EventHandler MouseUnHover = delegate { };
        public event EventHandler MousePress = delegate { };
        public event EventHandler MouseRelase = delegate { };

    }

    public enum PCButtonState
    {
        none = 0,
        hover,
        pressed,
        released,
    }
}
