//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Assignment4_487
//{
//    public class ZombieWithAccessory : IZombieComponent
//    {
//        private IZombieComponent zombie;
//        private IZombieComponent zombieAccessory;
//        // We need this since each zombie accessory acts as a leaf of a normal
//        // zombie in the composite pattern, we need additonal logic to treat it as such
//        // this is why we create a ZombieWithAcessory Class

//        public string ZombieType {  get; set; }

//        public int AccessoryHealth;

//        public int GetTotalHealth
//        {
//            get
//            {
//                return this.zombieAccessory.GetTotalHealth + this.zombie.GetTotalHealth; // This will get our total health
//            }
//        }

//        public ZombieWithAccessory(string zombieType, IZombieComponent zombie, IZombieComponent accessory)
//        {
//            this.ZombieType = zombieType;
//            this.zombie = zombie;
//            this.zombieAccessory = accessory;
//        }

//        public void TakeDamage(int damage)
//        {
//            if (!this.zombieAccessory.Die())
//            {
//                this.zombieAccessory.TakeDamage(damage);
//                if (this.zombieAccessory.GetTotalHealth <= 0)
//                {
//                    this.zombie.TakeDamage(Math.Abs(this.zombieAccessory.GetTotalHealth)); // leftover health
//                    this.ZombieType = "Regular Zombie";
//                }
//            }
//            else
//            {
//                this.zombie.TakeDamage(damage);
//            }
//        }

//        public bool Die()
//        {
//            return this.zombie.Die();
//        }

//        public void RepresentZombie()
//        {
//            if (!this.zombieAccessory.Die())
//            {
//                Console.Write($"{this.ZombieType} / {this.GetTotalHealth}, ");
//            }
//            else
//            {
//                zombie.RepresentZombie();
//            }
//        }
//    }
//}
