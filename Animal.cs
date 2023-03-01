using System;
namespace ZooManager
{
    /// <summary>
    /// This class represents animals.
    /// </summary>

    public class Animal
    {
        public string emoji;
        public string species;
        public string name;
        public int reactionTime = 5; // default reaction time for animals (1 - 10)
        
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
    /// <summary>
    /// This interface represents runner among animals.
    /// </summary>
    public interface Irunner
    {
        bool Flee();
        void MoveRandom();
    }
    /// <summary>
    /// This class represents attacker among animals.
    /// </summary>
    public interface Iattacker
    {
        void Hunt();
        void Fly();
    }
}
