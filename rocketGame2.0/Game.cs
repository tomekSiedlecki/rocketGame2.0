using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rocketGame2._0
{
    public class Game
    {
        public List<Entity> entities;
        public Display display;
        public Ship ship;
        public EntitiesManagement entitiesManagement;
        public int score;

        public CancellationTokenSource cancellationTokenSource;
        public bool gameEnded;

        public void Setup()
        {
            cancellationTokenSource = new CancellationTokenSource();

            entities = new List<Entity>();
            display = new Display();
            entitiesManagement = new EntitiesManagement();

            List<string> shipView = new List<string>();
            shipView.Add(" ^ ");
            shipView.Add("^*^");
            ship = new Ship(shipView);

            entities.Add(ship);

            gameEnded = false;

            score = 0;
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
            while (!gameEnded)
            {
                Console.Clear();
                Console.WriteLine("SCORE: " + score);
                display.DisplayBoard(entities);
                await Task.Delay(Consts.displayRefreshRate);
            }
        }

        private async Task Colision()
        {
            while (!gameEnded)
            {
                if(entitiesManagement.ifDied(entities, ship))
                {
                   gameEnded = true;
                }
                await Task.Delay(50);
            }
        }

        private async Task MoveShip()
        {
            while (!gameEnded)
            {
                if (Console.KeyAvailable)
                {
                    var keyPressed = Console.ReadKey(true);
                    if (keyPressed.Key == Consts.leftControlKey)
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
        private async Task SpawnAndMove()
        {
            int counter = 0;
            while (!gameEnded)
            {
                entitiesManagement.MoveObjects(entities);
                if(counter % 3 ==0)
                {
                    entitiesManagement.SpawnObjects(entities);
                    counter = 0;
                }
                await Task.Delay(1000);
                score++;
                counter++;
                
            }
        }
    }
}
