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
        private float vinkel;

        public Ball( Texture2D texture, Vector2 position, Vector2 velocity, float radius)
        {
            this.position = position;
            this.texture = texture;
            this.velocity = velocity;
            this.radius = radius;
        }

=======
        

        private Texture2D texture;
        private Vector2 velocity;
        private float radius;
        
        public Ball(Vector2 position, Vector2 velocity, float radius)
        {
            this.position = position;
            this.velocity = velocity;
            this.radius = radius;
        }
>>>>>>> Stashed changes
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
        }

        public float Radius
        {
            get
            {
                return radius;
            }
        }

<<<<<<< Updated upstream
=======
        public void Update()
        {
            position += velocity;

        }

        public void Draw(SpriteBatch spritebatch)
        {
            //spritebatch.Draw();
        }
>>>>>>> Stashed changes
    }
}
