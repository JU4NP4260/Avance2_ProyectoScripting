using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptingObstaclesProject
{
    public class Chest : Obstaculo
    {
        public Chest(int power) : base(power)
        {
            
        }

        public Equipment GeneratesAnEquipment() 
        {
            return new Equipment((int)MathF.Floor(base.Power/2));
        }


    }
}
