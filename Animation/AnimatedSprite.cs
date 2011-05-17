using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XGT.Animation
{
    public class AnimatedSprite
    {
        private const int millisecondsInASecond = 1000;

        protected Texture2D mBaseTexture;
        private int mMillisecondsPerFrame;
        private int mMillisecondsElapsed;
        private int mTotalFrames;
        private int mCurrentFrame;
        private int mTotalAnimationStances;
        private int mCurrentAnimationStance;
        protected bool mVisible;
        private Rectangle mFrameSize;
        protected Rectangle mCurrentFrameRect;

        public int FrameRate
        {
            set
            {
                if (value < 60)
                {
                    mMillisecondsPerFrame = millisecondsInASecond / value;
                }
                else
                {
                    System.Diagnostics.Debug.Print("Framerate too high, maxiumum frame rate is 60");
                    mMillisecondsPerFrame = 16;
                }
            }
        }

        public int AnimationStance
        {
            get
            {
                return mCurrentAnimationStance;
            }
            set
            {
                if (value < mTotalAnimationStances)
                {
                    EventHandler<AnimationStanceChangedEventArgs> handler;
                    handler = mAnimationStanceChanged;
                    if (handler != null && value != mCurrentAnimationStance) //only throw the event if a new animation stance is set
                    {
                        handler(this, new AnimationStanceChangedEventArgs(mCurrentAnimationStance, value));
                    }
                    mCurrentAnimationStance = value;
                    mCurrentFrameRect.Y = mCurrentAnimationStance * mFrameSize.Height;
                }
                else
                {
                    System.Diagnostics.Debug.Print("Cannot set animation stance as greater than total number of animation stances");
                }
            }

        }
        public event EventHandler<AnimationStanceChangedEventArgs> AnimationStanceChanged
        {
            add
            {
                mAnimationStanceChanged += value;
            }
            remove
            {
                mAnimationStanceChanged -= value;
            }
        }
        private EventHandler<AnimationStanceChangedEventArgs> mAnimationStanceChanged;


        public bool Visible
        {
            get
            {
                return mVisible;
            }
            set
            {
                EventHandler<EventArgs> handler;
                handler = mVisibleChanged;
                if (handler != null && value != mVisible)
                {
                    handler(this, new EventArgs());
                }
                mVisible = value;
            }
        }
        public event EventHandler<EventArgs> VisibleChanged;
        private EventHandler<EventArgs> mVisibleChanged;

        public AnimatedSprite(Texture2D lSpriteTexture, int lFrameRate, Rectangle lFrameSize)
        {
            mBaseTexture = lSpriteTexture;
            FrameRate = lFrameRate;
            mFrameSize = lFrameSize;
            mCurrentFrameRect = mFrameSize;
            mTotalFrames = mBaseTexture.Width / lFrameSize.Width;
            mCurrentFrame = 0;
            mTotalAnimationStances = mBaseTexture.Height / lFrameSize.Height;
            mCurrentAnimationStance = 0;
            mVisible = true;
        }

        /// <summary>
        /// Updates the selected frame with in your sprite
        /// </summary>
        /// <param name="gameTime">The GameTime to ensure that frame rate is consistent</param>
        public void Update(GameTime gameTime)
        {
            mMillisecondsElapsed += gameTime.ElapsedGameTime.Milliseconds;
            if (mMillisecondsElapsed >= mMillisecondsPerFrame)
            {
                if (mCurrentFrame < mTotalFrames - 1)
                {
                    mCurrentFrame++;
                }
                else
                {
                    mCurrentFrame = 0;
                }
                mMillisecondsElapsed = 0;
            }
            mCurrentFrameRect.X = mCurrentFrame * mFrameSize.Width; 
        }
        

        /// <summary>
        /// Draws the sprite at the specifed rectangle -- use if you are managing position, rotation etc of your class
        /// </summary>
        /// <param name="spriteBatch">The (initalised) sprite batch to draw the texture with</param>
        /// <param name="lDrawRectangle">The rectangle with the absolute position of where to draw the sprite</param>
        /// <param name="lColor">The color to draw the sprite with, use Color.White for normal</param>
        public void Draw(SpriteBatch spriteBatch, Rectangle lDrawRectangle, Color lColor)
        {
            if (mVisible)
            {
                spriteBatch.Draw(mBaseTexture, lDrawRectangle, mCurrentFrameRect, lColor);
            }
        }

        /// <summary>
        /// Draw the sprite with the specified properties -- use if you are managing position, rotation etc of your class
        /// </summary>
        /// <param name="spriteBatch">The (initalised) sprite batch to draw the texture with</param>
        /// <param name="lDrawRectangle">The rectangle with the absolute position of where to draw the sprite</param>
        /// <param name="lColor">The color to draw the sprite with, use Color.White for normal</param>
        /// <param name="lRotation">The rotation around the specifed origin in radians</param>
        /// <param name="lOrigin">The relative to the origin of the sprite point to rotate around</param>
        /// <param name="lSpriteEffects">The spriteEffects to draw this sprite with</param>
        /// <param name="lLayerDepth">The depth of a layer. By default, 0 represents the front layer and 1 represents a back layer. Use SpriteSortMode if you want sprites to be sorted during drawing.</param>
        public void Draw(SpriteBatch spriteBatch, Rectangle lDrawRectangle, Color lColor, float lRotation, Vector2 lOrigin, SpriteEffects lSpriteEffects, float lLayerDepth)
        {
            if (mVisible)
            {
                spriteBatch.Draw(mBaseTexture, lDrawRectangle, mCurrentFrameRect, lColor, lRotation, lOrigin, lSpriteEffects, lLayerDepth);
            }
        }

        /// <summary>
        /// Draw the sprite with the specified properties -- use if you are managing position, rotation etc of your class
        /// </summary>
        /// <param name="spriteBatch">The (initalised) sprite batch to draw the texture with</param>
        /// <param name="lDrawPoint">The absolute vector to draw the sprite</param>
        /// <param name="lColor">The color to draw the sprite with, use Color.White for normal</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 lDrawPoint, Color lColor)
        {
            if (mVisible)
            {
                spriteBatch.Draw(mBaseTexture, lDrawPoint, mCurrentFrameRect, lColor);
            }
        }

        /// <summary>
        /// Draw the sprite with the specified properties -- use if you are managing position, rotation etc of your class
        /// </summary>
        /// <param name="spriteBatch">The (initalised) sprite batch to draw the texture with</param>
        /// <param name="lDrawPoint">The absolute vector to draw the sprite</param>
        /// <param name="lColor">The color to draw the sprite with, use Color.White for normal</param>
        /// <param name="lRotation">The rotation around the specifed origin in radians</param>
        /// <param name="lOrigin">The relative to the origin of the sprite point to rotate around</param>
        /// <param name="lScale">The scale factor to apply to this sprite</param>
        /// <param name="lSpriteEffects">The spriteEffects to draw this sprite with</param>
        /// <param name="lLayerDepth">The depth of a layer. By default, 0 represents the front layer and 1 represents a back layer. Use SpriteSortMode if you want sprites to be sorted during drawing.</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 lDrawPoint, Color lColor, float lRotation, Vector2 lOrigin, float lScale, SpriteEffects lSpriteEffects, float lLayerDepth)
        {
            if (mVisible)
            {
                spriteBatch.Draw(mBaseTexture, lDrawPoint, mCurrentFrameRect, lColor, lRotation, lOrigin, lScale, lSpriteEffects, lLayerDepth);
            }
        }
        
        /// <summary>
        /// Draw the sprite with the specified properties -- use if you are managing position, rotation etc of your class
        /// </summary>
        /// <param name="spriteBatch">The (initalised) sprite batch to draw the texture with</param>
        /// <param name="lDrawPoint">The absolute vector to draw the sprite</param>
        /// <param name="lColor">The color to draw the sprite with, use Color.White for normal</param>
        /// <param name="lRotation">The rotation around the specifed origin in radians</param>
        /// <param name="lOrigin">The relative to the origin of the sprite point to rotate around</param>
        /// <param name="lScaleVector">The vector scale factor to apply to this sprite</param>
        /// <param name="lSpriteEffects">The spriteEffects to draw this sprite with</param>
        /// <param name="lLayerDepth">The depth of a layer. By default, 0 represents the front layer and 1 represents a back layer. Use SpriteSortMode if you want sprites to be sorted during drawing.</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 lDrawPoint, Color lColor, float lRotation, Vector2 lOrigin, Vector2 lScaleVector, SpriteEffects lSpriteEffects, float lLayerDepth)
        {
            if (mVisible)
            {
                spriteBatch.Draw(mBaseTexture, lDrawPoint, mCurrentFrameRect, lColor, lRotation, lOrigin, lScaleVector, lSpriteEffects, lLayerDepth);
            }
        }
    }
}
