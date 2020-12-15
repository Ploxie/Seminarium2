﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminarium2
{
    class Car
    {
        Texture2D car;
        Vector2 startPosition;
        Vector2 position;

        Vector2 carOrigin;
        Vector2 velocity;

        float carRotation = 0;

        int speed;

        private Func<Vector2, GameTime, float, Vector2> carPath;

        private Rectangle bounds;

        public Car(Texture2D car, GameWindow window, Vector2 position, Func<Vector2, GameTime,float, Vector2> carPath)
        {
            this.car = car;

            this.position = position;
            this.startPosition = position;
            this.velocity = velocity;
            this.carPath = carPath;

            this.bounds = new Rectangle(0, 0, window.ClientBounds.Width, window.ClientBounds.Height);

            carOrigin = new Vector2(car.Width / 2, car.Height / 2);
  
        }

        public void Update(GameTime gameTime)
        {
            //velocity = carPath(position, gameTime);

            //carRotation += (float)gameTime.ElapsedGameTime.TotalSeconds * speed; //?
            Vector2 newPos = carPath(startPosition, gameTime, 10.0f);
            velocity = (newPos - position);
            //position = newPos; 

            carRotation = (float)Math.Atan2(position.Y - newPos.Y, position.X - newPos.X) + MathHelper.ToRadians(180);

            position += velocity;

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(car, position, null, Color.White, carRotation, carOrigin, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(car, startPosition, null, Color.Red, 0.0f, carOrigin, 1, SpriteEffects.None, 0);
        }
    }
}
