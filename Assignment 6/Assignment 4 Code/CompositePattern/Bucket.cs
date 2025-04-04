using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_487
{
    public class Bucket : IZombieComponent
    {
        public int Health { get; set; } = 100;

        public int GetTotalHealth
        {
            get
            {
                return this.Health;
            }
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
            Console.Write($"Bucket Zombie / {this.GetTotalHealth}");
        }

        public void TakeDamage(int damage)
        {
            this.Health -= damage;
        }
    }
}
