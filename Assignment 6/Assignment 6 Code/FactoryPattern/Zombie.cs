﻿using _487Assignment4.Observer_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment4_487
{
    // Concrete Subject
    public class Zombie : IZombieComponent
    {
        public string ZombieType { get; } = "Regular"; // What type of accessory will the Zombie Have
        public int Health { get; set; } = 50; // Zombies Health

        //public bool HasAccessory { get; set; } // Whether the zombie has an accessory or not

        //public int AcessoryHealth { get; set; } // If it has an Acessory, damage that first

        public virtual int GetTotalHealth // Gets the total Health of a zombie
        {
            get
            {
                return this.Health;
            }
        }

        public bool IsAlive { get; set; }

        public bool isMetal { get; set; } = false;

        private List<IObserver> observers = new List<IObserver>();

        public IZombieComponent Parent { get; set; } = null;

        // Constructor for the zombie.
        // Now we pass in a decorator instead of a type im pretty sure
        public Zombie()
        {
            //this.ZombieType = type;
            this.IsAlive = true; // Zombie is created, so "Alive"
        }

        public virtual bool GetMetalStatus()
        {
            return this.isMetal;
        }

        public virtual void MagnetForce()
        {
          
        }

        public virtual void FromAboveDamage(int damage)
        {
            this.Health -= damage;
            this.Die();
        }

        public virtual void TakeDamage(int damage) // Taking Damage
        {
            //Console.WriteLine("///Normal Damage");
            this.Health -= damage;
            this.Die();
        }

        public virtual bool Die() // Set to false once the zombies health goes below zero
        {
            if (this.Health <= 0)
            {
                this.IsAlive = false;
                this.Notify();
                return true;
            }

            return false;
        }

        public virtual void RepresentZombie()
        {
            Console.Write($"{this.ZombieType} / {this.GetTotalHealth}, ");
        }

        public void Attach(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void Notify()
        {
            IZombieComponent subject;

            if (this.Parent != null)
            {
                subject = this.Parent;
            }
            else
            {
                subject = this;
            }

            foreach (var observer in this.observers)
            {
                // pass in the current object
                observer.Update(subject);
            }
        }

        // Methods we might need for each zombie, most likely not many

    }
}
