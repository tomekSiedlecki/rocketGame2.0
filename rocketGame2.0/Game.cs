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
        public EntitiesManagement entitiesManagement;

        public void Setup()
        {
            entities = new List<Entity>();
            display = new Display();
            entitiesManagement = new EntitiesManagement();

            List<string> shipView = new List<string>();
            shipView.Add(" ^ ");
            shipView.Add("^*^");
            ship = new Ship(shipView);

            entities.Add(ship);
        }

        public async Task Run()
        {
            Setup();
            Console.WriteLine("running");
            var display = Display();
            var colision = Colision();
            var spawnAndMove = SpawnAndMove();
            var moveShip = MoveShip();

            await display;
            await colision;
            await spawnAndMove;
            await moveShip;
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
            while (true)
            {
                if (entitiesManagement.ifDied(entities, ship))
                {
                    Console.WriteLine("CONTACT");
                }
                await Task.Delay(50);
            }
        }

        private async Task MoveShip()
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
        private async Task SpawnAndMove()
        {
            while (true)
            {
                entitiesManagement.MoveObjects(entities);
                await Task.Delay(1000);
                entitiesManagement.MoveObjects(entities);
                await Task.Delay(1000);
                entitiesManagement.MoveObjects(entities);
                await Task.Delay(1000);
                entitiesManagement.SpawnObjects(entities);
                entitiesManagement.MoveObjects(entities);
                await Task.Delay(1000);

            }
        }
    }
}
