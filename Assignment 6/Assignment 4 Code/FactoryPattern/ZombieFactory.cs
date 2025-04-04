using Assignment4_487.CompositePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_487
{
    public class ZombieFactory
    {
        public ZombieFactory()
        {
            
        }


        public IZombieComponent CreateZombie(string name)
        {
            switch(name)
            {

                case "RegularZombie":
                    return new Zombie("Regular Zombie");
                case "ConeZombie":
                    return new ZombieWithAccessory("Cone Zombie", new Zombie("Regular Zombie"), new Cone());
                case "ScreenZombie":
                    return new ZombieWithAccessory("Screen Zombie", new Zombie("Regular Zombie"), new Screen());
                case "BucketZombie":
                    return new ZombieWithAccessory("Bucket Zombie", new Zombie("Regular Zombie"), new Bucket());
                default:
                    throw new NotImplementedException("No Zombie of this type");
            }
        }
    }
}
