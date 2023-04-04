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

        private Cell Startcell = DungeonSystem.Intance.GetStartCell();
        private Cell currentCell;

        private Equipment[] equipmentEquiped = new Equipment[2];

        public Cell CurrentCell { get => currentCell;}

        public Player(int poderBase, int vidaBase)
        {
            this.PoderBase = poderBase;
            this.poderActual = poderBase;
            this.VidaBase = vidaBase;
        }

        public void RecalculatePower()
        {
            poderActual += equipmentEquiped[0].Power;

            if (equipmentEquiped[1] != null)
            {
                poderActual += equipmentEquiped[1].Power;
            }
        }

        public void Combat(Obstaculo Enemy)
        {
            int r = GetObstacleType(Enemy);

            switch (r)
            {
                case 1:
                    SumarVida(1);
                    Enemy.OnDying();
                    break;

                    case 2:

                    if (equipmentEquiped[0] != null)
                    {
                        Mago EnemyMage = (Mago)Enemy;

                        float BonusATK = 0;

                        switch (EnemyMage.Element)
                        {
                            case Elementos.Fire:

                                for (int i = 0; i < equipmentEquiped.Length -1 ; i++)
                                {
                                    if (equipmentEquiped[i]?.Element == Elementos.Water)
                                    {
                                        BonusATK += 1.6f;
                                    }
                                }

                                break;

                            case Elementos.Water:

                                for (int i = 0; i < equipmentEquiped.Length - 1; i++)
                                {
                                    if (equipmentEquiped[i]?.Element == Elementos.Earth)
                                    {
                                        BonusATK += 1.6f;
                                    }
                                }

                                break;
                            case Elementos.Earth:

                                for (int i = 0; i < equipmentEquiped.Length - 1; i++)
                                {
                                    if (equipmentEquiped[i]?.Element == Elementos.Fire)
                                    {
                                        BonusATK += 1.6f;
                                    }
                                }
                                break;
                        }

                        int ATK = (int)MathF.Round(poderActual * BonusATK);
                        Figth(ATK, EnemyMage);
                    }
                    else
                    {
                        Figth(Enemy);
                    }
                        
                    break;
                    
                case 3:

                    Chest chest = (Chest)Enemy;

                    AddEquipment(chest.GeneratesAnEquipment());

                    Enemy.OnDying();

                    break;

                 case 4:

                    Figth(Enemy);

                    break;
            }

            ;
        }

        public void AddEquipment(Equipment equipment) 
        {

            if (equipmentEquiped[0] != null)
            {
                if (equipmentEquiped[1] == null)
                {
                    equipmentEquiped[1] = equipment;
                }
                else
                {
                    if (equipment.Power > equipmentEquiped[0].Power)
                    {
                        equipmentEquiped[0] = equipment;
                    }
                    else if (equipment.Power > equipmentEquiped[1].Power)
                    {
                        equipmentEquiped[1] = equipment;
                    }
                }
            }
            else
            {
                equipmentEquiped[0] = equipment;
            }

            RecalculatePower();

        }

        public void Figth(Obstaculo enemy) 
        {
            if (enemy.Power >= poderActual)
            {
                OnDying();
                enemy.OnWining(poderActual);
            }
            else
            {
                OnWining(enemy.Power);
                enemy.OnDying();
            }
        }

        public void Figth(int i,Obstaculo enemy)
        {
            if (i > poderActual)
            {
                OnDying();
                enemy.OnWining(poderActual);
            }
            else
            {
                OnWining(i);
                enemy.OnDying();
            }
        }

        private int GetObstacleType(Obstaculo P) 
        {
            if (P is Angel)
            {
                return 1;
            }
            else if (P is Mago)
            {
                return 2;
            }
            else if (P is Chest)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        public void OnDying()
        {
            vidaActual--;
            if (vidaActual < 1)
                alive = false;
            currentCell = Startcell;
        }

        public void OnWining(int suma)
        {
            poderActual += suma;
        }

        public void SumarVida(int cantidad)
        {
            vidaActual += cantidad;
        }
    }
}
