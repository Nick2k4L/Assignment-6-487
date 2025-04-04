using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_487
{
    public class Screen : IZombieComponent
    {
        public int Health { get; set; } = 25;

        public bool isMetal { get; set; } = true;

        public int GetTotalHealth
        {
            get
            {
                return this.Health;
            }
        }

        public bool GetMetalStatus()
        {
            return this.isMetal;
        }


        public bool Die()
        {
            if (this.Health <= 0)
            {
                return true;
            }
            return false;
        }

        public void RepresentZombie()
        {
            Console.Write($"Screen Zombie / {this.GetTotalHealth}");
        }

        public void TakeDamage(int damage)
        {
            this.Health -= damage;
        }
    }
}
