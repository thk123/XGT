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
        Texture2D buttonTexture;
       
        ButtonManager mainWindowButtonManager; //Buttons managers can be instantiated for different screens

        Character player;

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
            KeyboardManager.Init(); //Initalise the Keyboard and Mouse managers before regestring for events
            MouseManager.Init();
            mainWindowButtonManager = new ButtonManager();

            //You can register to individual key presses like this
            KeyboardManager.EscapeKeyPressed += new EventHandler(KeyboardManager_EscapeKeyPressed); 
            KeyboardManager.AKeyPressed += new EventHandler(KeyboardManager_AKeyPressed);

            //You can register to specific mouse events like this
            MouseManager.LeftMouseDoubleClick += new EventHandler(MouseManager_LeftMouseDoubleClick);
            MouseManager.ScrollWheelScrolled += new EventHandler(MouseManager_ScrollWheelScrolled);

            base.Initialize();
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
            buttonTexture = Content.Load<Texture2D>("ButtonTexture");

            PCButton myBtn = new PCButton(buttonTexture, new Rectangle(10, 10, 100, 100)); //create the button with position and size of the button
            myBtn.ConfigureButton(PCButtonState.hover, new Point(100, 0)); //Configure specific button states - eg setting the hover image to be at 100,0 in the texture
            myBtn.ConfigureButton(PCButtonState.pressed, new Point(200,0));
            myBtn.ConfigureButton(PCButtonState.released, new Point(300, 0));

            //Register to specific button events
            myBtn.MouseHover += new EventHandler(myBtn_MouseHover);
            myBtn.RightMousePress += new EventHandler(myBtn_RightMousePress);
            myBtn.LeftMousePress += new EventHandler(myBtn_LeftMousePress);
            myBtn.LeftMouseDoubleClick += new EventHandler(myBtn_LeftMouseDoubleClick);
            
            myBtn.HotKey = Keys.G; //setting the hotkey means that the button listens for this key and fires mouse click
                  
            mainWindowButtonManager.AddButton(myBtn);

            player = new Character(baseTexture);
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

            player.Update(gameTime);

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

            player.Draw(spriteBatch);

            mainWindowButtonManager.Draw(spriteBatch);
            
            spriteBatch.End();
           
            base.Draw(gameTime);
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

        void myBtn_LeftMousePress(object sender, EventArgs e)
        {
            Console.WriteLine("Button Clicked");
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
    }
}
