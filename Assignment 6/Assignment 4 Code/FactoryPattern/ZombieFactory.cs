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
                    return new
                case "ScreenZombie":
                    return new 
                case "BucketZombie":
                    return new 
                default:
                    throw new NotImplementedException("No Zombie of this type");
            }
        }
    }
}
