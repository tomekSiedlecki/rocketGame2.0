using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rocketGame2._0;

namespace rocketGameMenu
{
    public class GameMenu
    {
        public void gameStart()
        {
            Console.WriteLine("Game starts in 3");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Game starts in 2");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Game starts in 1");
            Thread.Sleep(1000);
            Console.Clear();
        }

        public void gameEnd(Game game)
        {
            Console.Clear();
            animate("You died");
            animate("Your score: " + game.score);

        }
        //to jest duplikat funkcji potem trzeba cos z tym zrobic
        public void animate(string text, int min = 50, int max = 150)
        {
            Random random = new Random();
            foreach (var letter in text)
            {
                Thread.Sleep(random.Next(min, max));
                Console.Write(letter);
            }
            Console.Write("\n");
        }
    }
}
