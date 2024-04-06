using System.Runtime.ExceptionServices;

namespace rocketGame2._0
{
    public class Entity
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

        public int getWidth()
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

        public virtual void onContact(List<Entity> entities)
        {

        }

        public bool ifContact(Entity entity)
        {
            bool ifcontact = false;

            Entity first = this;
            Entity second = entity;

            //wyzej jest entity
            if (entity.Y < Y)
            {
                first = entity;
                second = this;
            }

            if(first.Y + first.Height - 1 < second.Y)
            {
                // tutaj ifcontact = false
                return ifcontact;
            }

            int yCounter = second.Y;
            for(int i = 0; i < second.Height; i++)
            {
                if(yCounter - first.Y >= first.Height)
                {
                    break;
                }
                string lineFirst = first.View.ElementAt(yCounter - first.Y);
                string lineSecond = second.View.ElementAt(i);

                bool ifStartedSpaces = false;
                int xIterator = first.X;
                foreach (var singleLetter in lineFirst)
                {
                    if (singleLetter != Consts.background)
                    {
                        ifStartedSpaces = true;

                        //nie wychodzi poza zakres stringa
                        if(xIterator >= second.X && xIterator <= second.X + second.Height - 1)
                        {
                            var element = lineSecond.ElementAt(xIterator - second.X);
                            if(element != Consts.background)
                            {
                                ifcontact = true;
                            }
                        }
                    }
                    else
                    {
                        if (ifStartedSpaces)
                        {
                            break;
                        }
                    }
                    xIterator++;
                }

                yCounter++;
            }
            return ifcontact;
        }



    }
}
