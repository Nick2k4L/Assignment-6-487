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

        string ZombieType { get; } // gets the type of zombie

        bool isMetal { get; set; }

        bool GetMetalStatus();

        void MagnetForce();

        void FromAboveDamage(int damage);

        void TakeDamage(int damage);
        bool Die();
        void RepresentZombie();
    }
}
