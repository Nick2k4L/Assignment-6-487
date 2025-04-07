using _487Assignment4.Observer_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_487
{
    // THIS IS OUR CONCRETE SUBJECT
    public interface IZombieComponent : ISubject 
    {
        int GetTotalHealth {  get; } // gets total health

        string ZombieType { get; } // gets the type of zombie

        bool isMetal { get; set; }

        bool IsAlive { get; set; }

        public IZombieComponent Parent { get; set; }

        bool GetMetalStatus();

        void MagnetForce();

        void FromAboveDamage(int damage);

        void TakeDamage(int damage);
        bool Die();
        void RepresentZombie();
    }
}
