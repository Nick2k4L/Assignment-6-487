using Assignment4_487;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _487Assignment4.Decorator_Pattern
{
    public class ScreenDecorator : ZombieDecorator
    {

        public override string ZombieType { get; set; } = "Screen Zombie";

        public override int AccessoryHealth { get; set; } = 25;

        private bool isFromAbove;

        public override int GetTotalHealth => this.zombie.GetTotalHealth + this.AccessoryHealth;

        public override bool isMetal { get; set; }

        public ScreenDecorator(IZombieComponent zombie) : base(zombie)
        {
            //this.GetTotalHealth = zombie.GetTotalHealth + this.AccessoryHealth;
            this.isMetal = true;
        }

        public override bool Die()
        {
            return this.zombie.Die();
        }

        public override bool GetMetalStatus()
        {
            if (this.isMetal)
            {
                return true;
            }
            else
            {
                this.AccessoryHealth = 0;
                this.ZombieType = "Regular Zombie";
                return false;
            }
        }

        public override void RepresentZombie()
        {
            if (this.AccessoryHealth > 0 && this.isMetal)
            {
                Console.Write($"{this.ZombieType} / {this.GetTotalHealth}, ");
            }
            else
            {
                this.zombie.RepresentZombie();
            }
        }

        public override void TakeDamage(int damage)
        {
            if (this.AccessoryHealth > 0 && this.isMetal && !this.isFromAbove)
            {
                this.AccessoryHealth -= damage;
                if (this.AccessoryHealth <= 0)
                {
                    this.isMetal = false;
                    this.ZombieType = "Regular Zombie";
                    this.zombie?.TakeDamage(Math.Abs(this.AccessoryHealth));
                }
            }
            else
            {
                this.zombie?.TakeDamage(damage);
            }
            this.isFromAbove = false;
        }

        public override void MagnetForce()
        {
            this.isMetal = false;
            this.GetMetalStatus();
        }

        public override void FromAboveDamage(int damage)
        {
            this.isFromAbove = true;
            this.TakeDamage(damage);
        }
    }
}
