using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminarium2
{
    class Cannon
    {
        MouseState oldMouseState, currentMouseState;
        Vector2 ballVelocity;
        Vector2 position;
        public Cannon(Texture2D texture, Vector2 position, Vector2 velocity, float radius, Point boundary)
        {

        }

        public void Update()
        {
            oldMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            if(oldMouseState.LeftButton==ButtonState.Released && currentMouseState.LeftButton==ButtonState.Pressed)
            {

                ballVelocity.X = Mouse.GetState().Position.X - position.X;
                ballVelocity.Y = Mouse.GetState().Position.Y - position.Y;
            }


        }

    }
}
