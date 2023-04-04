using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptingObstaclesProject
{
    public class Mago : Obstaculo
    {
        private Elementos element;

        public Mago(int power) : base(power)
        {
            Random random= new Random();

            int i = random.Next(0,3);

            element = (Elementos)Enum.ToObject(typeof(Elementos),i); 
        }

        public Elementos Element { get => element;}
    }
}
