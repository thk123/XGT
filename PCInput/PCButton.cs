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

        public PCButton(Texture2D lButtonSprite, Rectangle lDrawRectange, Rectangle lLocation)
        {
            mButtonSprite = lButtonSprite;
            mDrawRectange = lDrawRectange;
            mLocation = lLocation;

            mStartPoints = new Point[4];
            mButtonState = PCButtonState.none;
        }

        public void MouseHovered()
        {
            mDrawRectange.X += mStartPoints[(int)PCButtonState.hover].X;

            mouseHover(this, new EventArgs());
        }
        public void MouseUnHover()
        {

        }
        public void MousePressed()
        {
            
        }
        public void MouseReleased()
        {

        }

        public void configureButton(PCButtonState lButtonState, Point position)
        {
            mStartPoints[(int)lButtonState] = position;
        }

        public virtual bool checkForCollision(Point position)
        {
            return mLocation.Contains(position);
        }

        public event EventHandler mouseHover = delegate { };

    }

    public enum PCButtonState
    {
        none = 0,
        hover,
        pressed,
        released,
    }
}
