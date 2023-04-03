using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptingObstaclesProject
{
    public class Mago : Obstaculo
    {
        public Mago(int power) : base(power)
        {

        }

        enum Elementos { Fire, Water, Earth }
    }
}
