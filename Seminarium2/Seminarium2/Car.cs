using Microsoft.Xna.Framework;
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
        Vector2 position;

        Vector2 carOrigin;
        Vector2 velocity;

        float carRotation = 0;

        int speed;

        public Car(Texture2D car, Vector2 position, Vector2 velocity)
        {
            this.car = car;

            this.position = position;
            this.velocity = velocity;

            carOrigin = new Vector2(car.Width / 2, car.Height / 2);
  
        }

        public void Update(GameTime gameTime)
        {
            speed = 5;
            carRotation += (float)gameTime.ElapsedGameTime.TotalSeconds * speed; //?
            position += velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
       
            spriteBatch.Draw(car, position, null, Color.White, carRotation, carOrigin, 1, SpriteEffects.None, 0);
        }
    }
}
