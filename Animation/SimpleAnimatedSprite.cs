using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XGT.Animation
{
    class SimpleAnimatedSprite : AnimatedSprite
    {
        private Vector2 mGlobalPosition;
        private float mRotation;
        private Color mColor;

        public Vector2 GlobalPosition
        {
            get
            {
                return mGlobalPosition;
            }
            set
            {
                mGlobalPosition = value;
                //check if outside bounds?
            }
        }
        public float Rotation
        {
            get
            {
                return mRotation;
            }
            set
            {
                mRotation = value;
            }
        }
        public Color Color
        {
            get
            {
                return mColor;
            }
            set
            {
                mColor = value;
            }
        }

        public SimpleAnimatedSprite(Texture2D lSpriteTexture, int lFrameRate, Rectangle lFrameSize)
            : base(lSpriteTexture, lFrameRate, lFrameSize)
        {
            mColor = Color.White;
        }

        /// <summary>
        /// Translate the sprite by the specified vector
        /// </summary>
        /// <param name="translationVector">The vector to translate the sprite by</param>
        public void Translate(Vector2 translationVector)
        {
            mGlobalPosition += translationVector;
        }

        /// <summary>
        /// Rotate the sprite (Use if you are not managing this in your class)
        /// </summary>
        /// <param name="lRotation">The rotation in radians to rotate the sprite (clockwise)</param>
        public void Rotate(float lRotation)
        {
            mRotation += lRotation;
        }

        /// <summary>
        /// This draw method uses the properties this class manages, use if you have been using functions like translate
        /// </summary>
        /// <param name="spriteBatch">The (initalised) sprite batch to draw the texture with</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (mVisible)
            {
                spriteBatch.Draw(mBaseTexture, mGlobalPosition, mCurrentFrameRect, mColor, mRotation, Vector2.Zero, 1f, SpriteEffects.None, 0);
            }
        }
    }
}
