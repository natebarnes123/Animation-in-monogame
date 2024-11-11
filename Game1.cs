using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.InteropServices;

namespace Animation_in_monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;


        Texture2D brownTribble;
        Texture2D greyTribble;
        Rectangle greyTribbleRect;
        Rectangle brownTribbleRect;
        Vector2 greyTribbleSpeed;
        Vector2 brownTribbleSpeed;
        public Game1()
        {
            

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            greyTribbleRect = new Rectangle(300, 10, 100, 100);
            window = new Rectangle(0, 0, 800, 600);
            greyTribbleSpeed = new Vector2(5, 2);

            brownTribbleRect = new Rectangle(100, 50, 100, 100);
            brownTribbleSpeed = new Vector2(7, 1);

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
            if (greyTribbleRect.Top > window.Height || greyTribbleRect.Bottom < 0)
                greyTribbleSpeed.Y *= -1;

            

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
