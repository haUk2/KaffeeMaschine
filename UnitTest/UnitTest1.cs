using Kaffeemaschine;
using NUnit.Framework;

namespace UnitTest
{
    public class Tests
    {


        [Test]
        public void KaffeMachenTest()
        {
            KaffeemaschieneClass kaffeemaschiene = new KaffeemaschieneClass();
            kaffeemaschiene.wasserAuffuellen(2);
            kaffeemaschiene.bohnenAuffuellen(2);
            kaffeemaschiene.macheKaffee((decimal)0.15, (decimal)2);
            Assert.IsTrue(kaffeemaschiene.Wasser == 1.9);
        }
    }
}