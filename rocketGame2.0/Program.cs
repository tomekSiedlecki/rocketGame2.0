using rocketGame2._0;
using System.Security.Cryptography.X509Certificates;

namespace rocketGame
{
    class Program
    {
        public static async Task Main()
        {
            //List<Entity> entities = new List<Entity>();
            
            //List<string > view = new List<string>();
            //view.Add("111");
            //view.Add("11 ");
            //view.Add("11 ");
            //Entity entity = new Entity(view, 0,0);


            //List<string> view2 = new List<string>();
            //view2.Add("000");
            //view2.Add("000");
            //view2.Add("000");
            //Entity entity2 = new Entity(view2, 1,1);


            ////List<string> ship = new List<string>();
            ////ship.Add(" ^ ");
            ////ship.Add("^*^");
            ////ship.Add("***");

            ////Ship rocket = new Ship(ship);


            ////entities.Add(rocket);

            //entities.Add(entity);
            //entities.Add(entity2);

            //Console.WriteLine(entity.ifContact(entity2));

            //Display x = new Display();
            //x.DisplayBoard(entities);

            Game game = new Game();
            var gameTask = game.Run();
            await gameTask;
        }
    }
}