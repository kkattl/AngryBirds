using System.Collections.Generic;
using System.Linq;

namespace AngryBirds.Lvls
{
    public class Lvl : ILvl
    {
        private List<ILvl> lvls = new List<ILvl>();
        private bool havePig = false;

        public void Add(params ILvl[] lvls)
        {
            foreach (ILvl lvl in lvls)
            {
                bool canAdd = true;

                int[] lvlArr = lvl.CreateLvl();
                foreach (ILvl l in this.lvls)
                {
                    if (l.CreateLvl().Length == lvlArr.Length)
                    {
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    int sum = lvlArr.Sum();

                    if (!havePig && sum == lvlArr.Length - 1)
                    {
                        havePig = true;
                        this.lvls.Add(lvl);
                    }
                    else if (sum != lvlArr.Length - 1)
                        this.lvls.Add(lvl);
                }
            }
        }

        public void Remove(ILvl lvl)
        {
            lvls.Remove(lvl);
        }

        public ILvl GetLvl(int i)
        {
            return lvls[i];
        }

        public int[] CreateLvl()
        {
            var generalLvl = new List<int>();
            foreach (ILvl lvl in lvls)
            {
                List<int> tempLvl = new List<int>(lvl.CreateLvl());
                int tempLvlSize = tempLvl.Count;
                int generalLvlSize = generalLvl.Count;

                if (generalLvlSize < tempLvlSize)
                {
                    for (int i = 0; i < tempLvlSize - generalLvlSize; i++)
                        generalLvl.Add(1);
                }
                else
                {
                    for (int i = 0; i < generalLvlSize - tempLvlSize; i++)
                        tempLvl.Add(1);
                }

                for (int i = 0; i < generalLvl.Count; i++)
                    generalLvl[i] += tempLvl[i] - 1;
            }

            return generalLvl.ToArray();
        }
    }
}
