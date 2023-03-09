using System;
namespace ZooManager
{
    public class Creature
    {

        public string emoji;
        public string species;
        public string HomePlanet;
        public string name;
        public int reactionTime = 5; // default reaction time for animals (1 - 10)
        public bool isHunt = false;
        public Point location;
        public void ReportLocation()
        {
            Console.WriteLine($"I am at {location.x},{location.y}");
        }
        virtual public void Activate()
        {
            Console.WriteLine($"Animal {name} at {location.x},{location.y} activated");
        }





    }
}
