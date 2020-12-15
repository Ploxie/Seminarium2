using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
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
        Texture2D lineTexture;

        float radius;

        float angle;


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

            lineTexture = CreateLineTexture(3, 100, Color.Black);

            radius = 50.0f;
            ballTex = CreateCircleTexture((int)radius, Color.White);
            pos = new Vector2(50, 50); //Start position
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

        public Texture2D CreateLineTexture(int width, int height, Color color)
        {
            Texture2D texture = new Texture2D(GraphicsDevice, width, height);

            Color[] colors = new Color[width * height];

            for(int i = 0; i < width * height; i++)
            {
                colors[i] = Color.Transparent;
            }

            int middleX = width / 2;
            int middleY = height / 2;

            for (int y = 0; y < middleY; y++)
            {
                colors[y * width + middleX] = color;
            }

            texture.SetData(colors);

            return texture;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            Vector2 bottomLeftCorner = new Vector2(0, Window.ClientBounds.Height);
            Vector2 mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            angle = (float)Math.Atan2(mousePosition.Y - bottomLeftCorner.Y, mousePosition.X - bottomLeftCorner.X) + MathHelper.ToRadians(-90);



            car.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            car.Draw(spriteBatch);

            spriteBatch.Draw(lineTexture, new Rectangle(1, Window.ClientBounds.Height+1, 3, 100), null, Color.White, angle, new Vector2(0, 0f), SpriteEffects.None, 0.0f);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
