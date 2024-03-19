using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace rocketGame2._0
{
    class EntitiesManagement
    {
        public void SpawnObjects(List<Entity> entities)
        {
            Random rnd = new Random();
            List<string> view = new List<string>();
            view.Add("00");
            view.Add("00");
            Entity entity = new Entity(view, rnd.Next(0,Consts.boardWidth - 1), 0);

            entities.Add(entity);
        }
        public void MoveObjects(List<Entity> entities)
        {
            List<Entity> toDelete = new List<Entity>();

            foreach (var item in entities)
            {
                if(!(item is Ship))
                {
                    item.Y++;
                    if (item.Y >= Consts.boardWidth)
                    {
                        toDelete.Add(item);
                    }
                }
                
            }

            foreach (var entityToDelete in toDelete)
            {
                entities.Remove(entityToDelete);
            }
        }

        public bool ifDied(List<Entity> entities, Ship ship)
        {
            bool result = false;

            foreach (var item in entities)
            {
                if (item is Ship)
                {
                    continue;
                }
                if(ship.ifContact(item) == true)
                {
                    result = true;
                    break;
                }

            }
            return result;
        }
    }
}
