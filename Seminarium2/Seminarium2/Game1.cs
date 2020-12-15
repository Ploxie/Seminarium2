using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Seminarium2
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Car car;
        Texture2D tank;
        Vector2 pos, vel;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            tank = Content.Load<Texture2D>("tank");

            Func<Vector2, GameTime, Vector2> carPath = (position, gameTime) => //del 2
            {
                float amplitude = 50.0f;
                float frequency = 0.1f;

                float t = ((float)gameTime.TotalGameTime.TotalMilliseconds / 10.0f);

                return position + new Vector2(t * 2.0f, (float)((1 + Math.Cos(t * frequency)) * Math.Sin(t * frequency)) * amplitude);
            };

            Func<Vector2, GameTime, Vector2> circlePath = (position, gameTime) => // del 1
            {
                float angle = MathHelper.ToRadians(360) * ((float)gameTime.TotalGameTime.TotalMilliseconds / 1000.0f);
                float radius = 50.0f;

                Vector2 circle = new Vector2((float)Math.Cos(angle) * radius, (float)Math.Sin(angle) * radius);

                return position + circle;
            };

            car = new Car(tank, Window, new Vector2(100, 250), circlePath);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            car.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            car.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
