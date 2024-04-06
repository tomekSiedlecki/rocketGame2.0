using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rocketGame2._0
{
    public class Asteroid : Entity
    {
        public Asteroid(List<string> View, int X, int Y) : base(View, X, Y)
        {

        }

        public override void onContact(List<Entity> entities)
        {
            Console.WriteLine("Booom");
        }
    }
}
