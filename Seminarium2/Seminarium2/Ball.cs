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

        public Ball(Vector2 position, Texture2D texture, Vector2 velocity, float radius)
        {
            this.position = position;
            this.texture = texture;
            this.velocity = velocity;
            this.radius = radius;
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
        }

        public float Radius
        {
            get
            {
                return radius;
            }
        }

    }
}
