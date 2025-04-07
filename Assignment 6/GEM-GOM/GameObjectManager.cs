using _487Assignment4.Observer_Pattern;
using Assignment4_487;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _487Assignment4.GEM_GOM
{
    // Concrete Observer / Listener
    public class GameObjectManager : IObserver
    {
        /// <summary>
        /// A list of all zombies
        /// </summary>
        public List<IZombieComponent>? zombies = new List<IZombieComponent>();
        private List<IZombieComponent>? zombieRemover = new List<IZombieComponent>();

        public void AddZombie(IZombieComponent zombie)
        {
            this.zombies?.Add(zombie);
            zombie.Attach(this);
        }

        public void DeleteZombie(IZombieComponent zombie)
        {
            this.zombies?.Remove(zombie);
            zombie.Detach(this);
        }

        public void Update(IZombieComponent zombie)
        {
            if (!zombie.IsAlive)
            {
                this.zombieRemover?.Add(zombie);
            }
        }

        public void RemoveDeadZombies()
        {
            foreach (var zombie in this.zombieRemover)
            {
                this.DeleteZombie(zombie);
            }
            this.zombieRemover.Clear();
        }
    }
}
