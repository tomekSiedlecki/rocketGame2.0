using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rocketGame2._0
{
    public class Ship : Entity
    {
        public Ship(List<string> View, int X = Consts.boardWidth / 2, int Y = Consts.boardHeight / 2)
            : base(View,X, Y)
        {
            this.Y = (Consts.boardHeight - Height) - 2;
            //nie moge zrobic tego w kostruktorze base
            this.X = (Consts.boardWidth/2) - (Width/2);
        }

        public override void onContact(List<Entity> entities)
        {
            Console.WriteLine("ship contact");
        }

        public void MoveLeft()
        {
            if(X > 0)
            {
                X--;
            }
        }

        public void MoveRight()
        {
            if (X + Width < Consts.boardWidth)
            {
                X++;
            }
        }
    }
}
