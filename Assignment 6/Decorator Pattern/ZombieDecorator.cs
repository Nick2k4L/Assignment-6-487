using Assignment4_487;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _487Assignment4.Decorator_Pattern
{
    public abstract class ZombieDecorator : IZombieComponent
    {
        public abstract string ZombieType { get; set; }

        public abstract int GetTotalHealth {  get; set; }
        public abstract bool isMetal { get; set; }

        public abstract int AccessoryHealth { get; set; }

        public IZombieComponent? zombie;

        public ZombieDecorator(IZombieComponent zombie)
        {
            this.zombie = zombie;
        }

        public abstract bool Die();

        public abstract void MagnetForce();

        public abstract void FromAboveDamage(int damage);

        public abstract void RepresentZombie();
        
        public abstract void TakeDamage(int damage);

        public abstract bool GetMetalStatus();
    }
}
