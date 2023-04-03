using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace TestScriptingObstaclesProject
{
    public class Player : ICore
    {
        readonly int PoderBase = 5;
        public int poderActual;
        public bool alive = true;
        readonly int VidaBase = 3;
        public int vidaActual;

        public Player(int poderBase, int vidaBase)
        {
            this.PoderBase = poderBase;
            this.poderActual = poderBase;
            this.VidaBase = vidaBase;
            this.vidaActual = vidaActual;
        }


        // Start is called before the first frame update
        void Start()
        {
            vidaActual = VidaBase;
            poderActual = PoderBase;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void GetEquipment(int TypeE)
        {
            if (TypeE == 1)
                poderActual = poderActual * 2;
            else
                poderActual += TypeE;
        }

        public void comparePower(int enemyPwr)
        {
            if (enemyPwr > poderActual)
                cuandoMuere();
            else
                cuandoGana(enemyPwr);
        }

        public void cuandoMuere()
        {
            vidaActual--;
            if (vidaActual < 1)
                alive = false;
            //volver a la casilla anterior.
        }

        public void cuandoGana(int suma)
        {
            poderActual += suma;
        }

        public void SumarVida(int cantidad)
        {
            vidaActual += cantidad;
        }
    }
}
