using rocketGame2._0;
using System.Security.Cryptography.X509Certificates;

namespace rocketGame
{
    class Program
    {
        public static void Main()
        {
            List<Entity> entities = new List<Entity>();
            
            List<string > view = new List<string>();
            view.Add("***");
            view.Add(" * ");
            view.Add("***");
            Entity entity = new Entity(view, 0,0);

            List<string> ship = new List<string>();
            ship.Add(" ^ ");
            ship.Add("^*^");
            ship.Add("***");

            Entity entity2 = new Entity(ship, 0, 4);


            entities.Add(entity);
            entities.Add(entity2);

            Display x = new Display();
            x.DisplayBoard(entities);
        }
    }
}