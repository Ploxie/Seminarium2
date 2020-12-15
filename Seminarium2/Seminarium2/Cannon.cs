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

        public Cannon()
        {

        }

        public void Update()
        {
            oldMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            if(oldMouseState.LeftButton==ButtonState.Released && currentMouseState.LeftButton==ButtonState.Pressed)
            {

            }
        }

    }
}
