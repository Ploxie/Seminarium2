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
        Vector2 startPosition;
        Vector2 position;

        Vector2 carOrigin;
        Vector2 velocity;

        float carRotation = 0;
        float ballHitbox;
        float speed;

        private Func<Vector2, GameTime, float, Vector2> carPath;

        private Rectangle bounds;

        public Car(Texture2D car, GameWindow window, Vector2 position, float speed,Func<Vector2, GameTime,float, Vector2> carPath,float ballHitbox)
        {
            this.car = car;

            this.position = position;
            startPosition = position;
            this.speed = speed;
            this.ballHitbox = ballHitbox;
            this.carPath = carPath;

            this.bounds = new Rectangle(0, 0, window.ClientBounds.Width, window.ClientBounds.Height);

            carOrigin = new Vector2(car.Width / 2, car.Height / 2);
  
        }

        public void Update(GameTime gameTime)
        {
            Vector2 newPos = carPath(startPosition, gameTime, speed);
            velocity = (newPos - position);

            carRotation = (float)Math.Atan2(position.Y - newPos.Y, position.X - newPos.X) + MathHelper.ToRadians(180);

            position += velocity;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(car, position, null, Color.White, carRotation, carOrigin, 1, SpriteEffects.None, 0);
            //spriteBatch.Draw(car, startPosition, null, Color.Red, 0.0f, carOrigin, 1, SpriteEffects.None, 0);
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

        public float Radius
        {
            get
            {
                return ballHitbox;
            }
        }
    }
}
