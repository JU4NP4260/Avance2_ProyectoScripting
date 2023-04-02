using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptingObstaclesProject
{
    public class Obstaculo
    {
        //[Header("Power")]
        public int power;
        public int probabilidadMin = 1;     //Temporalmente públicos para revisar que valores llevan a una buena progresión
        public int probabilidadMax = 16;

        //Just For C# implementation
        Random random = new Random();

        public Obstaculo(int power)
        {
            this.power = power;
        }

        public void GetPower()
        {
            //First is UnityEngine.Random implemetation
            //power = Random.Range(probabilidadMin, probabilidadMax);

            //Second is C# pure Implementation
            power = random.Next(probabilidadMin, probabilidadMax);
        }

        public int ScalePower(int originalPower, int powerScale)
        {
            power = (originalPower * powerScale);
            return power;
        }
    }

}
