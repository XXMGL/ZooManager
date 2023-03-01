﻿using System;
namespace ZooManager
{
    public class Mouse : Animal
    {
        public Mouse(string name)
        {
            emoji = "🐭";
            species = "mouse";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(1, 4); // reaction time of 1 (fast) to 3
            /* Note that Mouse reactionTime range is smaller than Cat reactionTime,
             * so mice are more likely to react to their surroundings faster than cats!
             */
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a mouse. Squeak.");
            MoveRandom();
            Flee();
        }

        /* Note that our mouse is (so far) a teeny bit more strategic than our cat.
         * The mouse looks for cats and tries to run in the opposite direction to
         * an empty spot, but if it finds that it can't go that way, it looks around
         * some more. However, the mouse currently still has a major weakness! He
         * will ONLY run in the OPPOSITE direction from a cat! The mouse won't (yet)
         * consider running to the side to escape! However, we have laid out a better
         * foundation here for intelligence, since we actually check whether our escape
         * was succcesful -- unlike our cats, who just assume they'll get their prey!
         */
        public void Flee()
        {
            if (Behaviour.Seek(location.x, location.y, Direction.up, "cat")==1)
            {
                if (Behaviour.Retreat(this, Direction.down)) return;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.down, "cat")==1)
            {
                if (Behaviour.Retreat(this, Direction.up)) return;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.left, "cat")==1)
            {
                if (Behaviour.Retreat(this, Direction.right)) return;
            }
            if (Behaviour.Seek(location.x, location.y, Direction.right, "cat")==1)
            {
                if (Behaviour.Retreat(this, Direction.left)) return;
            }
        }
        private void MoveRandom()
        {
            int steps = 0;
            Random rnd = new Random();
            Direction randomDirection = (Direction)rnd.Next(Enum.GetNames(typeof(Direction)).Length);
            if (Behaviour.Seek(location.x, location.y, Direction.up, "Raptor") == 1)
            {
                steps = Behaviour.Move(this, randomDirection, 2);
            }
            if (Behaviour.Seek(location.x, location.y, Direction.down, "Raptor") == 1)
            {
                steps = Behaviour.Move(this, randomDirection, 2);
            }
            if (Behaviour.Seek(location.x, location.y, Direction.left, "Raptor") == 1)
            {
                steps = Behaviour.Move(this, randomDirection, 2);
            }
            if (Behaviour.Seek(location.x, location.y, Direction.right, "Raptor") == 1)
            {
                steps = Behaviour.Move(this, randomDirection, 2);
            }
        }
    }
}

