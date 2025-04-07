//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Assignment4_487
//{
//    public class ZombieList : IZombieComponent
//    {
//        private List<IZombieComponent> zombieList = new List<IZombieComponent>(); // Our list of zombiecomponents

//        public int ZombieCount
//        {
//            get
//            {
//                return zombieList.Count;
//            }
//        }

//        public void AddZombie(IZombieComponent zombie) // Adding our Zombie to the list
//        {
//            zombieList.Add(zombie);
//        }

//        public void RemoveZombie(IZombieComponent zombie) // Removing our Zombie from the list, probably when dead
//        {
//            zombieList.Remove(zombie);
//        }

//        public void TakeDamage(int damage)
//        {
//            zombieList[0].TakeDamage(damage); // First Zombie would take damage
//            this.Die();
//        }

//        public bool Die()
//        {
//            if(zombieList[0].Die())
//            {
//                this.RemoveZombie(zombieList[0]);
//                return true;
//            }
            
//            return false;
//        }

   
//        public void RepresentZombie()
//        {
//            foreach (var zombie in zombieList)
//            {
//                zombie.RepresentZombie(); // Prints out a list of all of our zombies
//            }
//        }
//    }
//}
