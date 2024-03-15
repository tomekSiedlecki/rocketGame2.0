using rocketGame2._0;

namespace rocketGame
{
    class Entity
    {
        public List<string> View { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Entity(List<string> View, int X, int Y)
        {
            this.View = View;
            this.X = X;
            this.Y = Y;

            Height = View.Count;
            Width = getWidth();
        }

        private int getWidth()
        {
            int widest = 0;
            foreach (var item in View)
            {
                int count = getLineWidth(item);
                if (count > widest) widest = count;
            }
            return widest;
        }

        public int getLineWidth(string line)
        {
            int count = 0;
            //zmienna ktora dopoki w stringu nie ma obiektu tylko sa spacje to jest false
            bool ifStartedSpaces = false;
            foreach (var singleLetter in line)
            {
                if (singleLetter != Consts.background)
                {
                    ifStartedSpaces = true;
                    count++;
                }
                else
                {
                    if (ifStartedSpaces)
                    {
                        break;
                    }
                }
            }
            return count;
        }

    }
}
