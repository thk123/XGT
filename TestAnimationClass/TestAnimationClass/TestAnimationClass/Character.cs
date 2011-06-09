using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XGT.PCInput;
using XGT.Animation;

namespace TestAnimationClass
{
    class Character
    {
        private Vector2 position;
        private bool moving;
        private AnimatedSprite sprite;

        public Character(Texture2D lTexture)
        {
            position = Vector2.Zero;

            KeyboardManager.LeftKeyHeld += new EventHandler(KeyboardManager_LeftKeyHeld);
            KeyboardManager.RightKeyHeld+=new EventHandler(KeyboardManager_RightKeyHeld);
            KeyboardManager.UpKeyHeld+=new EventHandler(KeyboardManager_UpKeyHeld);
            KeyboardManager.DownKeyHeld+=new EventHandler(KeyboardManager_DownKeyHeld);

            moving = false;

            sprite = new AnimatedSprite(lTexture, 60, new Rectangle(0, 0, 100, 100));
            sprite.AnimationStance = 0; 
        }

        public void Update(GameTime gameTime)
        {
            if (moving)
            {
                sprite.AnimationStance = 1;
            }
            else
            {
                sprite.AnimationStance = 0;
            }
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position, Color.White);
            
            moving = false;
        }

        void KeyboardManager_DownKeyHeld(object sender, EventArgs e)
        {
            position.Y += 5;
            moving = true;
        }

        void KeyboardManager_UpKeyHeld(object sender, EventArgs e)
        {
            position.Y -= 5;
            moving = true;
        }

        void KeyboardManager_RightKeyHeld(object sender, EventArgs e)
        {
            position.X += 5;
            moving = true;
        }

        void KeyboardManager_LeftKeyHeld(object sender, EventArgs e)
        {
            position.X -= 5;
            moving = true;
        }
    }
}
