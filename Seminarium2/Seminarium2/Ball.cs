using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminarium2
{
    class Ball
    {
        private Texture2D texture;
        private Vector2 velocity;
        private Vector2 position;
        private float radius;
        private float speed;
        int bX;
        int bY;



        public Ball(Texture2D texture, Vector2 position, float speed, float radius, Point boundary)
        {          
            this.texture = texture;
            this.position = position;
            this.speed = speed;
            this.radius = texture.Height / 2; 
            this.bX = boundary.X;
            this.bY = boundary.Y;           
        }

        public void Update(GameTime gameTime)
        {
            if(velocity.Length() == 0)
            {
                return;
            }
            position += Vector2.Normalize(velocity) * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (position.X - radius <= 0 || position.X - radius >= bX)
            {
                velocity.X *= -1;
            }

            if (position.Y - radius <= 0 || position.Y - radius >= bY)
            {
                velocity.Y *= -1;
            }
        }


        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, null, Color.White, 0, new Vector2(texture.Width / 2.0f, texture.Height / 2.0f), 1, SpriteEffects.None, 0);
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
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
                return radius;
            }
        }


        public void Update()
        {
            position += velocity;

        }


    }
}
