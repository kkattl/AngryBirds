using System.Collections.Generic;

namespace AngryBirds.Birds
{
    public class BirdsBand : IBird
    {
        private List<IBird> birds = new List<IBird>();

        public void Add(params IBird[] birds)
        {
            foreach (IBird bird in birds)
            {
                this.birds.Add(bird);
            }
        }

        public void Remove(IBird bird)
        {
            birds.Remove(bird);
        }

        public IBird GetBird(int i)
        {
            return birds[i];
        }

        public int[] LogFly(int[] lvl)
        {
            int[] log = lvl;
            for (int i = 0; i < birds.Count; i++)
            {
                log = birds[i].LogFly(log);
            }
            return log;
        }
    }
}

