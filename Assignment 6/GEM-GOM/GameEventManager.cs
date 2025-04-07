using Assignment4_487;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _487Assignment4.GEM_GOM
{
    // Sender
    public class GameEventManager
    {
        private GameObjectManager gameObjectManager;
        public GameEventManager(GameObjectManager objects)
        {
            this.gameObjectManager = objects;
        }

        public void DoDamageFromAbove(int d, IZombieComponent e)
        {
            e.FromAboveDamage(d);
        }

        public void DoDamage(int d, IZombieComponent e)
        {
            e.TakeDamage(d);
        }

        public void ApplyMagnentForce(IZombieComponent e)
        {
            e.MagnetForce();
        }


        public void SimulateCollisionDetection(int plant)
        {
            switch(plant)
            {
                case 1:

                    this.DoDamage(25, this.gameObjectManager.zombies[0]);
                    break;
                case 2:
                    this.DoDamageFromAbove(40, this.gameObjectManager.zombies[0]);
                    break;
                case 3:
                    this.ApplyMagnentForce(this.gameObjectManager.zombies[0]);
                    break;
            }
        }
    }
}
