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

        private Texture2D mBaseTexture;
        private int mMillisecondsPerFrame;
        private int mMillisecondsElapsed;
        private int mTotalFrames;
        private int mCurrentFrame;
        private int mTotalAnimationStances;
        private int mCurrentAnimationStance;
        private bool mVisible;
        private Rectangle mFrameSize;
        private Rectangle mCurrentFrameRect;
        private Vector2 mGlobalPosition;
        private float mRotation;
        private Color mColor;

        public int FrameRate
        {
            get
            {
                return mMillisecondsPerFrame / millisecondsInASecond;
            }
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
                    AnimationStanceChanged(this, new AnimationStanceChangedEventArgs(mCurrentAnimationStance, value));
                    mCurrentAnimationStance = value;
                    mCurrentFrameRect.Y = mCurrentAnimationStance * mFrameSize.Height;
                }
                else
                {
                    System.Diagnostics.Debug.Print("Cannot set animation stance as greater than total number of animation stances");
                }
            }

        }
        public event EventHandler<AnimationStanceChangedEventArgs> AnimationStanceChanged;

        public bool Visible
        {
            get
            {
                return mVisible;
            }
            set
            {
                mVisible = value;
                VisibleChanged(this, new EventArgs());
            }
        }
        public event EventHandler<EventArgs> VisibleChanged;

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

        public AnimatedSprite(Texture2D lSpriteTexture, int lFrameRate, Rectangle lFrameSize)
        {
            mColor = Color.White;
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

        public void Translate(Vector2 translationVector)
        {
            mGlobalPosition += translationVector;
        }

        public void Rotate(float lRotation)
        {
            mRotation += lRotation;
        }

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

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Assuming sprite batch has begun
            spriteBatch.Draw(mBaseTexture, mGlobalPosition, mCurrentFrameRect, mColor, mRotation, Vector2.Zero,1f, SpriteEffects.None, 0);
        }
    }
}
