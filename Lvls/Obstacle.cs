namespace AngryBirds.Lvls
{
    public abstract class Obstacle : ILvl
    {
        protected int strength;
        protected int position;

        public int[] CreateLvl()
        {
            int[] lvl = new int[position + 3];
            for (int i = 0; i < position + 3; i++)
            {
                lvl[i] = 1;
            }
            lvl[position] = strength;
            return lvl;
        }
    }
}
