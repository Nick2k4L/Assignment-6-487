//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Assignment4_487.CompositePattern
//{
//    public class Cone : IZombieComponent
//    {
//        public int Health { get; set; } = 25;

//        public int GetTotalHealth
//        {
//            get
//            {
//                return this.Health;
//            }
//        }

//        public bool isMetal { get; set; } = false;

//        public bool Die()
//        {
//            if (this.Health <= 0)
//            {
//                return true;
//            }
//            return false;
//        }

//        public bool GetMetalStatus()
//        {
//            return this.isMetal;
//        }

//        public void RepresentZombie()
//        {
//            Console.Write($"Cone Zombie / {this.GetTotalHealth}");
//        }

//        public void TakeDamage(int damage)
//        {
//            this.Health -= damage;
//        }
//    }
//}
