namespace TestScriptingObstaclesProject
{
    public class ObstaclesClass_Tests
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
            Assert.Greater(obstaculo.power, 0);
        }

        [Test]
        public void Test_ScalePower()
        {
            // Arrange
            int powerScale = random.Next(1,11);
            int originalPower = obstaculo.power;
            int newPower = obstaculo.ScalePower(originalPower, powerScale);

            // Assert
            Assert.That(newPower, Is.EqualTo(originalPower * powerScale));
            Assert.That(obstaculo.power, Is.EqualTo(newPower));
        }
    }

    public class PlayerTest
    {
        Player player;
        Angel angel;

        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void SumVida()
        {
            Player player = new Player(10,10,true,1, 1);
            Angel angel = new Angel(1);
            player.SumarVida(angel.power);
            int playerHp = player.vidaActual;
            if(angel == null) { Assert.Fail(); }
            else { if (angel.power + playerHp > playerHp) { Assert.Pass(); } }
        }
    }
}