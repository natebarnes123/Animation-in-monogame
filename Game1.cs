using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Animation_in_monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;
        Random generator;


        Texture2D brownTribble, greyTribble, creamTribble, orangeTribble;
        Rectangle greyTribbleRect, brownTribbleRect, creamTribbleRect, orangeTribbleRect;
        Vector2 greyTribbleSpeed, brownTribbleSpeed, creamTribbleSpeed, orangeTribbleSpeed;
        
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
            orangeTribbleSpeed = new Vector2(1, 2);

            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            greyTribble = Content.Load<Texture2D>("tribblegrey");
            brownTribble = Content.Load<Texture2D>("tribblebrown");
            orangeTribble = Content.Load<Texture2D>("tribbleorange");
            creamTribble = Content.Load<Texture2D>("tribblecream");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            greyTribbleRect.X += (int)greyTribbleSpeed.X;
            if (greyTribbleRect.Right > window.Width || greyTribbleRect.Left < 0)
                greyTribbleSpeed.X *= -1;
            greyTribbleRect.Y += (int)greyTribbleSpeed.Y;
            if (greyTribbleRect.Bottom > window.Height || greyTribbleRect.Top < 0)
                greyTribbleSpeed.Y *= -1;

            brownTribbleRect.X += (int)brownTribbleSpeed.X;
            if (brownTribbleRect.Right > window.Width || brownTribbleRect.Left > 0)
                brownTribbleSpeed.X *= -1;
            brownTribbleRect.Y += (int)brownTribbleSpeed.Y;
            if (brownTribbleRect.Bottom > window.Height || brownTribbleRect.Top < 0)
            {
                brownTribbleRect.X *= generator.Next(0, 600);

            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(greyTribble, greyTribbleRect, Color.White);
            _spriteBatch.Draw(brownTribble, brownTribbleRect, Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
