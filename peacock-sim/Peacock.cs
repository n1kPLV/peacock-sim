using System;
using System.Linq;
using System.Text;

namespace peacocksim
{
    class Peacock
    {
        //Defining fields
        private int feathers;
        private int attractivity;
        private int resistance;
        private bool dead;
        private bool hurt;
        private Random rand;
        private int[] successors;

        //Constructor for a Peacock
        public Peacock(int feathers, Random randomiser)
        {
            this.feathers = feathers;
            attractivity = 3 + feathers;
            resistance = 6 - feathers;
            dead = false;
            hurt = false;
            rand = randomiser;
            successors = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        //doing auto move(Partner)
        public void movePartner(int round)
        {
            //variables
            int diceroll1 = rand.Next(1, 6);
            int diceroll2 = rand.Next(1, 6);
            int tmpattractivity = attractivity;
            bool endofround = false;

            //don't do anything if dead or hurt
            if(dead | hurt)
            {
                endofround = true;
            }
            
            //check if rolled a 6 and else try to sum up
            if (diceroll1 != 6 & !endofround)
            {
                if (tmpattractivity - (6 - diceroll1) >= 0)
                {
                    tmpattractivity = tmpattractivity - (6 - diceroll1);
                }
                //
                else
                {
                    endofround = true;
                }
            }
            if (!endofround & diceroll2 >= 4)
            {
                successors[round-1] = tmpattractivity + 1;
            }
            else if (!endofround & tmpattractivity - (4 - diceroll2) >= 0)
            {
                tmpattractivity = tmpattractivity - (4 - diceroll2);
                successors[round-1] = tmpattractivity + 1;
            }
            
        }

        public void moveEnemy(int round)
        {
            //variables
            int diceroll1 = rand.Next(1, 6);
            int diceroll2 = rand.Next(1, 6);

            //TODO: game logic

        }
        
        public bool getHurt()
        {
            return hurt;
        }

        public bool getDeath()
        {
            return dead;
        }

        public string getDebug()
        {
            StringBuilder tmp = new StringBuilder("[DEBUG] ");
            tmp.Append(" feathers: ");
            tmp.Append(feathers);
            tmp.Append(" attractivity: ");
            tmp.Append(attractivity);
            tmp.Append(" resistance: ");
            tmp.Append(resistance);
            tmp.Append("");
            tmp.Append("");
            return tmp.ToString();
        }

        public int getTotalSuccessors()
        {
            return successors.Sum();
        }

        public int getFeathers()
        {
            return feathers;
        }
    }
}
