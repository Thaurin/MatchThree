using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MatchThree
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int a = 128, b = 128;
        int x, y;
        int growDirection = 1;
        int xDirection = 1;
        int yDirection = 1;
        float rotation = 0;
        Texture2D texture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1368;
            graphics.PreferredBackBufferHeight = 768;
            this.IsFixedTimeStep = true;
            this.graphics.SynchronizeWithVerticalRetrace = true;
        }
  
        protected override void Initialize()
        {
            texture = new Texture2D(this.GraphicsDevice, 100, 100);
            Board board = new Board();

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = this.Content.Load<Texture2D>("blue_gem");
        }

        protected override void UnloadContent()
        {
            this.Content.Unload();
        }

        protected override void OnActivated(object sender, System.
                                          EventArgs args)
        {
            this.Window.Title = "MatchThree";
            base.OnActivated(sender, args);
        }

        protected override void OnDeactivated(object sender, System.
                                              EventArgs args)
        {
            this.Window.Title = "MatchThree (paused)";
            base.OnActivated(sender, args);
        }

        protected override void Update(GameTime gameTime)
        {
            if (!IsActive) return;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (a < 100 || a > 110) { growDirection *= -1; }
            if (x > graphics.GraphicsDevice.Viewport.Width - texture.Width || x < 0) { xDirection *= -1; }
            if (y > graphics.GraphicsDevice.Viewport.Height - texture.Height || y < 0) { yDirection *= -1; }

            //a += 5 * growDirection;
            //b = a;
            x += 5 * xDirection;
            y += 5 * yDirection;
            rotation += 0.1f;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(sortMode: SpriteSortMode.Deferred);   
            spriteBatch.Draw(texture,
                destinationRectangle: new Rectangle(x, y, a, b),
                origin: new Vector2(texture.Width / 2, texture.Height / 2),
                rotation: rotation);   // Vector2.Zero);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
