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
        //private bool hurt;
        private int hurtinround;
        private Random rand;
        private int[] successors;

        //Constructor for a Peacock
        public Peacock(int feathers, Random randomiser)
        {
            this.feathers = feathers;
            attractivity = 3 + feathers;
            resistance = 6 - feathers;
            dead = false;
            hurtinround = -10;
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
            bool endofround = false;                //var to jump to mark end of move

            //don't do anything if dead or hurt
            if (dead | round == hurtinround + 1)
            {
                endofround = true;
            }
            
            //check if rolled a 6 and else try to sum up
            if (diceroll1 != 6 & !endofround)
            {
                //try if able to sum up
                if (tmpattractivity - (6 - diceroll1) >= 0)
                {
                    tmpattractivity = tmpattractivity - (6 - diceroll1);
                }
                else
                {
                    endofround = true;
                }
            }
            //checking if second roll is 4 or higher
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
            bool endofround = false;            //var to jump to mark end of move

            //don't do anything if dead or hurt
            if (dead | round == hurtinround + 1)
            {
                endofround = true;
            }

            //check if rolled a 6 and else try to sum up
            if (diceroll1 != 6 & !endofround)
            {
                //try if able to sum up
                if (resistance - (6 - diceroll1) >= 0)
                {
                    resistance = resistance - (6 - diceroll1);
                    endofround = true;
                }
            }
            else if (diceroll1 == 6)
            {
                endofround = true;
            }
            //checking if second roll is 4 or higher
            if (!endofround & diceroll2 >= 4)
            {
                hurtinround = round;
            }
            else if (!endofround & resistance - (4 - diceroll2) >= 0)
            {
                resistance = resistance - (4 - diceroll2);
                hurtinround = round;
            }
            else if (!endofround)
            {
                dead = true;
            }
        }
        
        public bool getHurt(int round)
        {
            return hurtinround == round + 1;
        }

        public bool getDeath()
        {
            return dead;
        }

        //Debug only
        public string getDebug()
        {
            StringBuilder tmp = new StringBuilder("[DEBUG] ");
            tmp.Append(" feathers: ");
            tmp.Append(feathers);
            tmp.Append(" attractivity: ");
            tmp.Append(attractivity);
            tmp.Append(" resistance: ");
            tmp.Append(resistance);
            tmp.Append(" dead: ");
            tmp.Append(dead);
            tmp.Append(" hurtinround: ");
            tmp.Append(hurtinround);
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
