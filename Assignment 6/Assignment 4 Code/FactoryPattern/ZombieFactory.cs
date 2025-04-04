using _487Assignment4.Decorator_Pattern;
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
            //var zombie = new Zombie();
            switch (name)
            {
                
                case "RegularZombie":
                    return new Zombie();
                case "ConeZombie":
                    return new ConeDecorator(new Zombie());
                case "ScreenZombie":
                    return new ScreenDecorator(new Zombie());
                case "BucketZombie":
                    return new BucketDecorator(new Zombie());
                default:
                    throw new NotImplementedException("No Zombie of this type");
            }
        }
    }
}
