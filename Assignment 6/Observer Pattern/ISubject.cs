using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _487Assignment4.Observer_Pattern
{
    public interface ISubject
    {
        // here we are adding the necessary 
        // calls for our Subject within this observer pattern
        public void Attach(IObserver observer);

        public void Detach(IObserver observer);

        public void Notify();
    }
}
