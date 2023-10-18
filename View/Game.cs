using AngryBirds.Birds;
using AngryBirds.Lvls;
using System.Collections.Generic;

namespace AngryBirds.View
{
    public class Game
    {
        BirdsBand birdsBand = new BirdsBand();
        Lvl lvl = new Lvl();

        public void loadObtancles(params ILvl[] obtancles)
        {
            lvl.Add(obtancles);
        }

        public void loadBirds(params IBird[] birds)
        {
            birdsBand.Add(birds);
        }

        public string[] game()
        {

            int[] level = lvl.CreateLvl();
            string[] result = new string[2];
            result[0] = drowLvl(level);

            level = birdsBand.LogFly(level);

            result[1] = drowLvl(level, false);

            return result;
        }

        private string drowLvl(int[] lvl, bool beforeBirdFly = true)
        {
            Dictionary<int, char> data = new Dictionary<int, char>
            {
                {0, '⚉'},
                {1, ' '}, {-1, ' '},
                {3, '┊'}, {-3, '‥'},
                {5, '┃'}, {-5, '╻'},
                {20, '☗'}, {-20, '☖'}
            };

            int lvlSize = lvl.Length;
            string result = "";


            for (int i = 0; i < lvlSize; i++)
            {
                result += '▁';
            }
            result += "\n";


            string ending = "No pig";
            if (beforeBirdFly)
            {
                for (int i = 0; i < lvlSize; i++)
                {
                    result += data[lvl[i]];
                }
            }
            else
            {
                bool birdPasted = false;
                bool next;
                bool nnext;

                for (int i = 0; i < lvlSize; i++)
                {
                    if (birdPasted)
                    {
                        result += data[lvl[i]];
                        if (lvl[i] == 0)
                            ending = "Defeat";
                    }
                    else
                    {
                        next = i + 1 < lvlSize && lvl[i + 1] > 0;
                        nnext = i + 2 < lvlSize && lvl[i + 2] >= 0;

                        if (lvl[i] <= 0 && next && nnext)
                        {
                            birdPasted = true;
                            result += '▶';
                            if (lvl[i] == 0)
                                ending = "Win";

                        }
                        else
                        {
                            result += data[lvl[i]];
                        }
                    }
                }
            }
            result += "\n";

            for (int i = 0; i < lvlSize; i++)
                result += '▔';

            if (!beforeBirdFly)
                result += "\n" + ending;
            return result;
        }
    }
}
