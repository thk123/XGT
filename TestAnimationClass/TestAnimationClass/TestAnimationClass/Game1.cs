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
using XGT.Animation;
using XGT.PCInput;

namespace TestAnimationClass
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D baseTexture;
        AnimatedSprite mySprite;
        ButtonManager mainWindowButtonManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            KeyboardManager.Init();
            MouseManager.Init();
            mainWindowButtonManager = new ButtonManager();

            KeyboardManager.EscapeKeyPressed += new EventHandler(KeyboardManager_EscapeKeyPressed);
            KeyboardManager.AKeyPressed += new EventHandler(KeyboardManager_AKeyPressed);

            MouseManager.LeftMouseDoubleClick += new EventHandler(MouseManager_LeftMouseDoubleClick);
            MouseManager.ScrollWheelScrolled += new EventHandler(MouseManager_ScrollWheelScrolled);
            base.Initialize();
        }

        void MouseManager_ScrollWheelScrolled(object sender, EventArgs e)
        {
            Console.WriteLine("Scroll whell scrolled");
        }

        void MouseManager_LeftMouseDoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine("Double clicked");
        }

        void KeyboardManager_AKeyPressed(object sender, EventArgs e)
        {
            Console.WriteLine("Hello");
        }

        void KeyboardManager_EscapeKeyPressed(object sender, EventArgs e)
        {
            this.Exit();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            baseTexture = Content.Load<Texture2D>("BaseTexture");
            mySprite = new AnimatedSprite(baseTexture, 4, new Rectangle(0, 0, 100, 100));
            mySprite.GlobalPosition = new Vector2(50f, 50f);
            PCButton myBtn = new PCButton(baseTexture, new Rectangle(10, 10, 100, 100));
            myBtn.MouseHover += new EventHandler(myBtn_MouseHover);
            myBtn.RightMousePress += new EventHandler(myBtn_RightMousePress);
            myBtn.HotKey = Keys.G;
            myBtn.LeftMousePress += new EventHandler(myBtn_LeftMousePress);
            myBtn.LeftMouseDoubleClick += new EventHandler(myBtn_LeftMouseDoubleClick);
            myBtn.ConfigureButton(PCButtonState.hover, new Point(100, 0));
            mainWindowButtonManager.AddButton(myBtn);

            // TODO: use this.Content to load your game content here
        }

        void myBtn_LeftMousePress(object sender, EventArgs e)
        {
            Console.WriteLine("clciked");
        }

        void myBtn_LeftMouseDoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine("Left mouse double clicked");
        }

        void myBtn_RightMousePress(object sender, EventArgs e)
        {
            Console.WriteLine("Right clicked button");
        }

        void myBtn_MouseHover(object sender, EventArgs e)
        {
            Console.WriteLine("Mouse hover");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardManager.Update(gameTime);
            MouseManager.Update(gameTime);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            mySprite.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            mySprite.Draw(gameTime, spriteBatch);
            mainWindowButtonManager.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
