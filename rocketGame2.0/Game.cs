using rocketGame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rocketGame2._0
{
    class Game
    {
        public List<Entity> entities;
        public Display display;
        public Ship ship;

        public void Setup()
        {
            entities = new List<Entity>();
            display = new Display();

            List<string> shipView = new List<string>();
            shipView.Add(" ^ ");
            shipView.Add("^*^");
            shipView.Add("***");
            ship = new Ship(shipView);

            entities.Add(ship);
        }

        public async Task Run()
        {
            Setup();
            Console.WriteLine("running");
            var display = Display();
            var colision = Colision();
            var move = Move();


            await display;
            await colision;
            await move;
        }

        private async Task Display()
        {
            while (true)
            {
                Console.Clear();
                display.DisplayBoard(entities);
                await Task.Delay(Consts.displayRefreshRate);
            }
        }

        private async Task Colision()
        {
            
        }

        private async Task Move()
        {
            while(true)
            {
                var keyPressed = Console.ReadKey(true);
                if(keyPressed.Key == Consts.leftControlKey)
                {
                    ship.MoveLeft();
                }
                else if (keyPressed.Key == Consts.rightControlKey)
                {
                    ship.MoveRight();
                }
            }
        }
    }
}
