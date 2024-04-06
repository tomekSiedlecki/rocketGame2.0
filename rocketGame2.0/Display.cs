using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rocketGame2._0
{
    public class Display
    {
        public void DisplayBoard(List<Entity> entities)
        {
            Console.WriteLine("╔" + new String('═', Consts.boardWidth) + "╗");

            List<Entity> inRendering = new List<Entity>();

            for(int i = 0; i < Consts.boardHeight; i++) 
            {
                foreach(Entity entity in entities)
                {
                    if(entity.Y == i)
                    {
                        inRendering.Add(entity);
                    }
                }
                DeleteItems(inRendering, i);
                Console.WriteLine("║" + CreateLine(inRendering, i) + "║");
            }

            Console.WriteLine("╚" + new String('═', Consts.boardWidth) + "╝");
        }

        public string CreateLine(List<Entity> inRendering, int y)
        {
            string line = new string(Consts.background, Consts.boardWidth);
            char[] charArray = line.ToCharArray();


            foreach (var entity in inRendering)
            {
                int entityLine = y - entity.Y;
                string entityLineString = entity.View.ElementAt(entityLine);

                int x = entity.X;
                bool ifStartedSpaces = false;
                foreach (var singleLetter in entityLineString)
                {
                    if(x < 0)
                    {
                        x++;
                        continue;
                    }
                    if(x > Consts.boardWidth - 1)
                    {
                        break;
                    }
                    if (singleLetter != Consts.background)
                    {
                        ifStartedSpaces = true;
                        charArray[x] = singleLetter;
                    }
                    else
                    {
                        if (ifStartedSpaces)
                        {
                            break;
                        }
                    }
                    x++;
                }
            }
            line = new string(charArray);
            return line;
        }

        public void DeleteItems(List<Entity> inRendering, int y)
        {
            List<Entity> toDelete = new List<Entity>();
            foreach (var entity in inRendering)
            {
                int lastLineOfObject = entity.Y + entity.Height -1;
                if (lastLineOfObject < y)
                {
                    toDelete.Add(entity);
                }
            }

            foreach (var entityToDelete in toDelete)
            {
                inRendering.Remove(entityToDelete);
            }
        }
    }
}
