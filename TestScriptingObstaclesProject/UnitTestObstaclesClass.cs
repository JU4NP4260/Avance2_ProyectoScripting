using NUnit.Framework;

namespace TestScriptingObstaclesProject
{
    public class ObstaclesTests
    {
        public Obstaculo obstaculo;
        Random random = new Random();

        [SetUp]
        public void Setup()
        {
            obstaculo = new Obstaculo(0);
            obstaculo.GetPower();
        }

        [Test]
        public void IsNotNull()
        {
            Assert.Greater(obstaculo.Power, 0);
        }

        [Test]
        public void Test_ScalePower()
        {
            // Arrange
            Random random = new Random();
            int rndScalePower = random.Next(1, 11);
            Obstaculo obstaculo = new Obstaculo(rndScalePower);
            int obsPower = obstaculo.Power;

            // Assert
            Assert.That(obsPower, Is.EqualTo(obstaculo.G * rndScalePower + 1));
        }

        [Test]
        public void GiveChestEquipment()
        {
            Player player = new Player(10, 1);
            int oldPower = player.poderActual;
            Chest OBS = new Chest(8);
            player.Combat(OBS);
            Assert.IsTrue(player.poderActual != oldPower);
        }
    }

    public class PlayerTest
    {
        [Test]
        public void SumVida()
        {
            Player player = new Player(10, 1);
            Angel angel = new Angel(1);
            player.SumarVida(angel.Power);
            int playerHp = player.vidaActual;
            if(angel == null) { Assert.Fail(); }
            else { if (angel.Power + playerHp > playerHp) { Assert.Pass(); } }
        }

        [Test]
        public void PlayerPierde()
        {
            DungeonSystem.Intance.GenerateDungeon(10,10);
            Player player = new Player(10, 1);
            Obstaculo OBS = new Obstaculo(15);
            int OBSstartPower = OBS.Power;
            player.Figth(OBS);
            Assert.IsTrue(player.alive == false);
            Assert.IsTrue(OBS.Power == OBSstartPower + 10);
            Assert.IsTrue(player.CurrentCell == DungeonSystem.Intance.GetStartCell());
        }

        [Test]
        public void PlayerGana()
        {
            Player player = new Player(10, 1);
            Obstaculo OBS = new Obstaculo(0);
            player.Figth(OBS);
            Assert.IsTrue(player.poderActual > 10);
        }

        [Test]
        public void PlayerGear()
        {
            Player player = new Player(10, 1);
            Equipment equipment = new Equipment(10);
            player.AddEquipment(equipment);
            Assert.IsTrue(player.poderActual == 20);
        }

        [Test]
        public void PlayerGear2()
        {
            Player player = new Player(10, 1);
            Equipment equipment = new Equipment(5);
            player.AddEquipment(equipment);
            Assert.IsTrue(player.poderActual == 15);
        }
    }
}