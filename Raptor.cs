using System;

namespace ZooManager
{
    /// <summary>
    /// This class represents raptors, use the Iattacker interface.
    /// raptor: will attack mouse and cats, can move 2 steps when detect a prey
    /// </summary>
    public class Raptor : Bird, Iattacker 
    {
        private bool isHunt=false;
        public Raptor(string name)
        {
            emoji = "🦅";
            species = "Raptor";
            this.name = name;
            reactionTime = 1;
        }

        /// <summary>
        /// Activate all behaviours of raptor.
        /// </summary>
        /// <returns>void</returns>
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

        /// <summary>
        /// Checking four direction( in one step) and attack if cat/mouse is detected
        /// </summary>
        /// <returns>void</returns>
        public void Hunt()
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
        /// <summary>
        /// Checking four direction( in two step) and attack if cat/mouse is detected
        /// </summary>
        /// <returns>void</returns>
        public void Fly()
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

