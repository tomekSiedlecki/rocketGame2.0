using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rocketGame2._0
{
    class EntitiesManagement
    {
        public void SpawnObjects(List<Entity> entities)
        {
            List<string> view = new List<string>();
            view.Add("00");
            view.Add("00");
            Entity entity = new Entity(view, 0, 0);

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
    }
}
