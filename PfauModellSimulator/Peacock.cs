using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PfauModellSimulator
{
    class Peacock
    {
        private int feathers;
        private int attractivity;
        private int resistance;
        private bool dead;
        private bool hurt;
        private Random rand;

        //Constructor for a Peacock

        public Peacock(int feathers, Random randomiser)
        {
            this.feathers = feathers;
            attractivity = 3 + feathers;
            resistance = 6 - feathers;
            dead = false;
            hurt = false;
            rand = randomiser;
        }
        public void movePartner()
        {
            //variables
            int diceroll1 = rand.Next(1, 6);
            int diceroll2 = rand.Next(1, 6);
            int tmpattractivity = attractivity;

            //TODO: game logic
            if (diceroll1 != 6)
            {
                if (tmpattractivity - (6 - diceroll1) >= 0)
                {
                    tmpattractivity = tmpattractivity - (6 - diceroll1);
                }
                else
                {
                    
                }
            }
            if (true)
            {

            }
                       
        }

        public void moveEnemy()
        {
            //variables
            int diceroll1 = rand.Next(1, 6);
            int diceroll2 = rand.Next(1, 6);

            //TODO: game logic

        }
    }
}
