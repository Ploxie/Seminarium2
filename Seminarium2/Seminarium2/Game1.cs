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
        Ball ball;
        Texture2D tank;
        Vector2 pos, vel;

        Texture2D ballTex;

        float radius;


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

            Func<Vector2, GameTime,float, Vector2> carPath = (position, gameTime, speed) => 
            {
                float amplitude = 50.0f;
                float frequency = 0.1f;

                float t = speed * ((float)gameTime.TotalGameTime.TotalSeconds);

                return position + new Vector2(t, (float)((1 + Math.Cos(t * frequency)) * Math.Sin(t * frequency)) * amplitude);
            };

            Func<Vector2, GameTime,float, Vector2> circlePath = (position, gameTime, speed) =>
            {
                float angle = MathHelper.ToRadians(10 * speed) * ((float)gameTime.TotalGameTime.TotalMilliseconds / 1000.0f);
                float radius = 50.0f;

                Vector2 circle = new Vector2((float)Math.Cos(angle) * radius, (float)Math.Sin(angle) * radius);

                return position + circle;
            };

            car = new Car(tank, Window, new Vector2(100, 250), circlePath);


            radius = 50.0f;
            ballTex = CreateCircleTexture((int)radius, Color.White);
            pos = new Vector2(0, 400); //Start position
            vel = new Vector2(200, 3); //riktning
            ball = new Ball(ballTex, pos, vel, radius);
        }

        public Texture2D CreateCircleTexture(int radius, Color color)
        {
            Texture2D texture = new Texture2D(GraphicsDevice, radius, radius);
            Color[] colorData = new Color[radius * radius];

            float diameter = radius / 2f;
            float diameterSquared = diameter * diameter;

            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    int index = x * radius + y;
                    Vector2 pos = new Vector2(x - diameter, y - diameter);
                    if (pos.LengthSquared() <= diameterSquared)
                    {
                        colorData[index] = color;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;
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
            ball.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
