using System;

namespace AngryBirds.Birds
{
    public class Bird : IBird
    {
        protected int flyDist = 15;

        public virtual int[] LogFly(int[] lvl)
        {
            int[] logFly = lvl;

            bool pigNotReached = true;
            int temp = flyDist;
            int curPos = 0;

            while (temp > 0 && curPos < lvl.Length && pigNotReached)
            {
                if (logFly[curPos] == 0)
                    pigNotReached = false;
                int step = Math.Max(1, logFly[curPos]);
                temp -= step;
                if (temp >= 0)
                {
                    logFly[curPos] = -Math.Abs(logFly[curPos]);
                    curPos++;
                }
            }
            return logFly;
        }
    }
}

