using System;

namespace SpaceStation
{
    class Program
    {
        static void Main(string[] args)
        {
            DeathStar deathstar = new DeathStar();
            SpaceStation[] spacestation = { deathstar };
            foreach (var item in spacestation)
            {
                item.FireLaser();
            }
        }
    }
}
