using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptingObstaclesProject
{
    public class Obstaculo
    {
        int power;
        public int probabilidadMin = 1;     //Temporalmente públicos para revisar que valores llevan a una buena progresión
        public int probabilidadMax = 10;

        public int Power { get => power; }

        public Obstaculo(int x)
        {
            int G = GetPower();
            power = G * x + 1;
        }

        public int GetPower()
        {
            Random random= new Random();
            return random.Next(probabilidadMin, probabilidadMax);
        }

        public int ScalePower(int power, int powerScale)
        {
            power = (power * powerScale);
            return power;
        }
    }

}
