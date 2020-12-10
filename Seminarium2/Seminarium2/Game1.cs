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


            Func<Vector2, GameTime, Vector2> carPath = (position, gameTime) => // Velocity
            {
                float amplitude = 5.0f;
                float frequency = 10.0f;
                return new Vector2(1, (float)((1 + Math.Cos(position.X / frequency)) * Math.Sin(position.X / frequency)) * amplitude);
            };

            Func<Vector2, Vector2, GameTime, Vector2> circlePath = (position,origin, gameTime) => // Position
            {
                float angle = MathHelper.ToRadians(360) * ((float)gameTime.TotalGameTime.TotalMilliseconds / 1000.0f);
                float radius = 10.0f;
                //return new Vector2(position.X, position.Y);

                Vector2 circle = new Vector2((float)Math.Cos(angle) * radius, (float)Math.Sin(angle) * radius);

                return (circle);
            };

            car = new Car(tank, new Vector2(350, 250), new Vector2(0,0), circlePath);
        }

        protected override void UnloadContent()
        {
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
