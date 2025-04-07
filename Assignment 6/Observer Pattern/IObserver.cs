using Assignment4_487;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _487Assignment4.Observer_Pattern
{
    public interface IObserver
    {
        // Our observer

        void Update(IZombieComponent subject);
    }
}
