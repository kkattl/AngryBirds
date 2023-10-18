using System;

namespace AngryBirds.Birds
{
    public class MasterBird : Bird
    {
        public override int[] LogFly(int[] lvl)
        {
            int[] logFly = lvl;
            bool abilityUsed = false;

            bool pigNotReached = true;
            int temp = flyDist;
            int curPos = 0;

            while (temp > 0 && curPos < lvl.Length && pigNotReached)
            {
                if (logFly[curPos] == 0)
                    pigNotReached = false;
                else
                {
                    int step = Math.Max(1, logFly[curPos]);
                    if (!abilityUsed && step > 1)
                    {
                        abilityUsed = true;
                        temp -= 1;
                        curPos++;
                    }
                    else
                    {
                        temp -= step;
                        if (temp >= 0)
                        {
                            logFly[curPos] = -Math.Abs(logFly[curPos]);
                            curPos++;
                        }
                    }
                }
            }
            return logFly;
        }
    }
}
