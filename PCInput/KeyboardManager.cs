using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XGT.PCInput
{
    public static class KeyboardManager
    {
        private static KeyboardState mCurrentKeyboardState, mPreviousKeyboardState;
        private static MouseState mCurrentMouseState, mPreviousMouseState;
        private static int[] keyDuration;
        private static int[] mouseDuration;

        public KeyboardState CurrentKeyboardState
        {
            get
            {
                return mCurrentKeyboardState;
            }
        }
        public KeyboardState PreviousKeyboardState
        {
            get
            {
                return mPreviousKeyboardState;
            }
        }
        public MouseState CurrentMouseState
        {
            get
            {
                return mCurrentMouseState;
            }
        }
        public MouseState PreviousMouseState
        {
            get
            {
                return mPreviousMouseState;
            }
        }

        public delegate void KeyPressedEventHandler(object sender, KeyPressedEventArgs eventArgs);
        public event KeyPressedEventHandler KeyPressed;
        protected void OnKeyPressed(KeyPressedEventArgs eventArgs)
        {
            if (KeyPressed != null)
            {
                KeyPressed(this, eventArgs);
            }
        }

        public static void Init()
        {
            mCurrentKeyboardState = Keyboard.GetState();
            mPreviousKeyboardState = Keyboard.GetState();
            mCurrentMouseState = Mouse.GetState();
            mPreviousMouseState = Mouse.GetState();

            keyDuration = new int[(int)Keys.Zoom];
            mouseDuration = new int[(int)MouseButtons.rightButton];
        }

        public static void Update(GameTime gameTime)
        {
            mPreviousKeyboardState = mCurrentKeyboardState;
            mCurrentKeyboardState = Keyboard.GetState();

            for (int keyId = 0; keyId < (int)Keys.Zoom; keyId++)
            {
                if (mCurrentKeyboardState.IsKeyDown((Keys)keyId))
                {
                    if (keyDuration[keyId] == 0)
                    {
                        
                    }
                    keyDuration[keyId] += gameTime.ElapsedGameTime.Milliseconds;
                }
                else
                {
                    keyDuration[keyId] = 0;
                }
            }
        }

    }

    public enum MouseButtons
    {
        leftButton = 0,
        middleButton,
        rightButton,
    };
}
