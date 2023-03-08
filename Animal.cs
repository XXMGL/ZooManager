using System;
namespace ZooManager
{
    /// <summary>
    /// This class represents animals.
    /// </summary>

    public class Animal : IPredator, IPrey
    {
        public string emoji;
        public string species;
        public string name;
        public int reactionTime = 5; // default reaction time for animals (1 - 10)
        
        public Point location;
        public bool isHunt = false;
        public void ReportLocation()
        {
            Console.WriteLine($"I am at {location.x},{location.y}");
        }

        virtual public void Activate()
        {
            Console.WriteLine($"Animal {name} at {location.x},{location.y} activated");
        }
        public bool Flee(string target)
        {
            if (Behaviour.Seek(location.x, location.y, Direction.up, target) == 1)
            {
                if (Behaviour.Retreat(this, Direction.down)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.down, target) == 1)
            {
                if (Behaviour.Retreat(this, Direction.up)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.left, target) == 1)
            {
                if (Behaviour.Retreat(this, Direction.right)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.right, target) == 1)
            {
                if (Behaviour.Retreat(this, Direction.left)) return true;
            }
            return false;
        }
      /*  public void MoveRandom()
        {

        }*/
        public void Hunt(string target)
        {
            if (isHunt == true) return;
            if (Behaviour.Seek(location.x, location.y, Direction.up, target) == 1)
            {
                Console.WriteLine("I find "+ target);
                Behaviour.Attack(this, Direction.up);
                isHunt = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.down, target) == 1)
            {
                Console.WriteLine("I find " + target);
                Behaviour.Attack(this, Direction.down);
                isHunt = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.left, target) == 1)
            {
                Console.WriteLine("I find " + target);
                Behaviour.Attack(this, Direction.left);
                isHunt = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.right, target) == 1)
            {
                Console.WriteLine("I find " + target);
                Behaviour.Attack(this, Direction.right);
                isHunt = true;
            }
        }
        
    }
    /* /// <summary>
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
     }*/
   
}
