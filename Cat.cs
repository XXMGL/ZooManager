using System;

namespace ZooManager
{
    public class Cat : Animal
    {
        public Cat(string name)
        {
            emoji = "🐱";
            species = "cat";
            this.name = name;
            reactionTime = new Random().Next(1, 6); // reaction time 1 (fast) to 5 (medium)
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a cat. Meow.");
            if(Flee())return;
            Hunt();
        }

        /* Note that our cat is currently not very clever about its hunting.
         * It will always try to attack "up" and will only seek "down" if there
         * is no mouse above it. This does not affect the cat's effectiveness
         * very much, since the overall logic here is "look around for a mouse and
         * attack the first one you see." This logic might be less sound once the
         * cat also has a predator to avoid, since the cat may not want to run in
         * to a square that sets it up to be attacked!
         */
        public void Hunt()
        {
            if (Behaviour.Seek(location.x, location.y, Direction.up, "mouse")==1)
            {
                Console.WriteLine("I find a rat");
                Behaviour.Attack(this, Direction.up);
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.down, "mouse")==1)
            {
                Console.WriteLine("I find a rat");
                Behaviour.Attack(this, Direction.down);
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.left, "mouse")==1)
            {
                Console.WriteLine("I find a rat");
                Behaviour.Attack(this, Direction.left);
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.right, "mouse")==1)
            {
                Console.WriteLine("I find a rat");
                Behaviour.Attack(this, Direction.right);
            }
        }
        private bool Flee()
        {
            if (Behaviour.Seek(location.x, location.y, Direction.up, "Raptor")==1)
            {
                if (Behaviour.Retreat(this, Direction.down)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.down, "Raptor")==1)
            {
                if (Behaviour.Retreat(this, Direction.up)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.left, "Raptor")==1)
            {
                if (Behaviour.Retreat(this, Direction.right)) return true;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.right, "Raptor")==1)
            {
                if (Behaviour.Retreat(this, Direction.left)) return true;
            }
            return false;
        }
    }
}

