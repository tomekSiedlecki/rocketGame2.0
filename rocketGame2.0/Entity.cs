using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rocketGame
{
    class Entity
    {
        public List<string> View {get;set;}

        public int Width { get; set; }
        public int Height { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Entity(List<string> View, int X, int Y) 
        {
            this.View = View;
            this.X = X;
            this.Y = Y;
        }
    }
}
