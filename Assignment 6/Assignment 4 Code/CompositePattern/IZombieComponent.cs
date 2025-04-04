using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_487
{
    public interface IZombieComponent // Interface for our composite pattern
    {
        int GetTotalHealth {  get; } // gets total health
        void TakeDamage(int damage);
        bool Die();
        void RepresentZombie();
    }
}
