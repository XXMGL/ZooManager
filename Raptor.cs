using System;

namespace ZooManager
{
    public class Raptor : Bird
    {
        private bool isHunt=false;
        public Raptor(string name)
        {
            emoji = "🦅";
            species = "Raptor";
            this.name = name;
            reactionTime = 1;
        }

        public override void Activate()
        {
            isHunt = false;
            base.Activate();
            Console.WriteLine("I am a Raptor. I'll eat cats and mouse.");
            Hunt();
            if (isHunt == true) return;
            Console.WriteLine("Raptor is flying");
            Fly();
        }

        /* Note that our cat is currently not very clever about its hunting.
         * It will always try to attack "up" and will only seek "down" if there
         * is no mouse above it. This does not affect the cat's effectiveness
         * very much, since the overall logic here is "look around for a mouse and
         * attack the first one you see." This logic might be less sound once the
         * cat also has a predator to avoid, since the cat may not want to run in
         * to a square that sets it up to be attacked!
         */
        private void Hunt()
        {

            if (Behaviour.Seek(location.x, location.y, Direction.up, "cat")==1 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse")==1)
            {
                Behaviour.Attack(this, Direction.up);
                isHunt = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.down, "cat")==1 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse")==1)
            {
                Behaviour.Attack(this, Direction.down);
                isHunt = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.left, "cat")==1 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse")==1)
            {
                Behaviour.Attack(this, Direction.left);
                isHunt = true;
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.right, "cat")==1 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse")==1)
            {
                Behaviour.Attack(this, Direction.right);
                isHunt = true;
            }
            
        }
        private void Fly()
        {

            if (Behaviour.Seek(location.x, location.y, Direction.up, "cat") == 2 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse") == 2)
            {
                Behaviour.fly(this, Direction.up);
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.down, "cat") == 2 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse") == 2)
            {
                Behaviour.fly(this, Direction.down);
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.left, "cat") == 2 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse") == 2)
            {
                Behaviour.fly(this, Direction.left);
            }
            else if (Behaviour.Seek(location.x, location.y, Direction.right, "cat") == 2 || Behaviour.Seek(location.x, location.y, Direction.up, "mouse") == 2)
            {
                Behaviour.fly(this, Direction.right);
            }
        }
    }
}

