using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rocketGameMenu
{
    public class Menu
    {
        public void start()
        {
            animate("ROMECZEK STUDIOS");
            Thread.Sleep(1000);
            animate("prezentuje: ");
            Thread.Sleep(1000);
            Console.Clear();

            animate("Rocket Game");
            Thread.Sleep(1500);
            Console.Clear();
            Thread.Sleep(1000);
            animate("2.0", 1000,1000);
            Thread.Sleep(3000);

            Console.Clear();
        }

        public void animate(string text ,int min = 50, int max = 150)
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
