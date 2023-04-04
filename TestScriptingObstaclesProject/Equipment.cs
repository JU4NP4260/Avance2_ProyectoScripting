using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptingObstaclesProject
{
    public class Equipment
    {
        Elementos element;
        int power;

        public Equipment(int power)
        {
            this.power = power;

            Random random = new Random();

            int i = random.Next(0, 3);

            element = (Elementos)Enum.ToObject(typeof(Elementos), i);
        }

        public Elementos Element { get => element;}
        public int Power { get => power;}
    }
}
