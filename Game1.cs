using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Animation_in_monogame
{
    enum Screen
    {
        Intro,
        TribbleYard
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;
        Random generator;

        
        Texture2D untitled;
        Texture2D brownTribble, greyTribble, creamTribble, orangeTribble;
        Rectangle greyTribbleRect, brownTribbleRect, creamTribbleRect, orangeTribbleRect;
        Vector2 greyTribbleSpeed, brownTribbleSpeed, creamTribbleSpeed, orangeTribbleSpeed;

        Screen screen;
        MouseState mouseState;
        public Game1()
        {
            

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            generator = new Random();
            greyTribbleRect = new Rectangle(300, 10, 100, 100);
            window = new Rectangle(0, 0, 800, 600);
            greyTribbleSpeed = new Vector2(5, 2);

            brownTribbleRect = new Rectangle(100, 50, 100, 100);
            brownTribbleSpeed = new Vector2(3, 2);

            creamTribbleRect = new Rectangle(150, 200, 100, 100);
            creamTribbleSpeed = new Vector2(4, 2);

            orangeTribbleRect = new Rectangle(200, 100, 100, 100);
            orangeTribbleSpeed = new Vector2(3, 4);

            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            screen = Screen.Intro;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            greyTribble = Content.Load<Texture2D>("tribblegrey");
            brownTribble = Content.Load<Texture2D>("tribblebrown");
            orangeTribble = Content.Load<Texture2D>("tribbleorange");
            creamTribble = Content.Load<Texture2D>("tribblecream");
            untitled = Content.Load<Texture2D>("untitled");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;
            }
            else if (screen == Screen.TribbleYard)
            {
                // TODO: Add your update logic here
                greyTribbleRect.X += (int)greyTribbleSpeed.X;
                if (greyTribbleRect.Right > window.Width || greyTribbleRect.Left < 0)
                    greyTribbleSpeed.X *= -1;
                greyTribbleRect.Y += (int)greyTribbleSpeed.Y;
                if (greyTribbleRect.Bottom > window.Height || greyTribbleRect.Top < 0)
                    greyTribbleSpeed.Y *= -1;

                brownTribbleRect.X += (int)brownTribbleSpeed.X;
                if (brownTribbleRect.Right > window.Width || brownTribbleRect.Left < 0)
                    brownTribbleSpeed.X *= -1;
                brownTribbleRect.Y += (int)brownTribbleSpeed.Y;
                if (brownTribbleRect.Bottom > window.Height || brownTribbleRect.Top < 0)
                {
                    brownTribbleRect.X = generator.Next(0, 150);
                    brownTribbleRect.Y = generator.Next(0, 150);
                }
                  
                    orangeTribbleRect.X += (int)orangeTribbleSpeed.X;
                    if (orangeTribbleRect.Right > window.Width || orangeTribbleRect.Left < 0)
                       orangeTribbleSpeed.X *= -1;
                    orangeTribbleRect.Y += (int)orangeTribbleSpeed.Y;
                    if (orangeTribbleRect.Bottom > window.Height || orangeTribbleRect.Top < 0)
                        orangeTribbleSpeed.Y *= -1;

                creamTribbleRect.X += (int)creamTribbleSpeed.X;
                if (creamTribbleRect.Right > window.Width || creamTribbleRect.Left < 0)
                    creamTribbleSpeed.X *= -1;
                    
                creamTribbleRect.Y += (int)creamTribbleSpeed.Y;
                if (creamTribbleRect.Bottom > window.Height || creamTribbleRect.Top < 0)
                    creamTribbleSpeed.Y *= -1;


            }
            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(untitled, window, Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(greyTribble, greyTribbleRect, Color.White);
                _spriteBatch.Draw(brownTribble, brownTribbleRect, Color.White);
                _spriteBatch.Draw(creamTribble, creamTribbleRect, Color.White);
                _spriteBatch.Draw(orangeTribble, orangeTribbleRect, Color.White);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
