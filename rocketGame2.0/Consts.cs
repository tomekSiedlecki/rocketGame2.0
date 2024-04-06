using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rocketGame2._0
{
    static class Consts
    {
        public const int boardHeight = 10;
        public const int boardWidth = 10;

        public const char background = ' ';

        public const ConsoleKey leftControlKey = ConsoleKey.A;
        public const ConsoleKey rightControlKey = ConsoleKey.D;

        public const int displayRefreshRate = 100;

        public static List<List<string>> asteroidTypes = new List<List<string>>();

        static Consts()
        {
            List<string> view = new List<string>();
            view.Add("00");
            view.Add("00");
            asteroidTypes.Add(view);

            List<string> view2 = new List<string>();
            view2.Add("0");
            asteroidTypes.Add(view2);
        }
            
    }
}
