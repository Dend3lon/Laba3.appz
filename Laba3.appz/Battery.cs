using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.appz
{
    public class Battery
    {
        private int chargemAh;
        private int Power;
        public Battery(int chargemAh)
        {
            this.chargemAh = chargemAh;
            Power = CalcHours();

        }

        public int CalcHours()
        {
            if (chargemAh >= 2000 && chargemAh < 4000)
                return 12;
            else if (chargemAh >= 4000 && chargemAh <= 7000)
                return 24;
            else
                throw new IndexOutOfRangeException();
        }

        public void ConsumeCharge(List<string> actions)
        {
            int totalConsumption = 0;
            foreach (var action in actions)
            {
                if (action == "video" || action == "play")
                {
                    totalConsumption += 2;
                }
                else if (action == "work" || action == "audio")
                {
                    totalConsumption += 1;
                }
            }
            if (Power < totalConsumption)
            {
                Console.WriteLine("Недостатньо заряду батареї для виконання дій.");
                return;
            }

            Power -= totalConsumption;
        }

        public int GetRemainingHours()
        {
            return Power;
        }

    }
}
