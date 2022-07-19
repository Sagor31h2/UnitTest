using NUnit.Framework;
namespace Sparky
{
    [TestFixture]
    public class FiboNUnit
    {
        private Fibo _fibo;
        [SetUp]
        public void Setup()
        {
            _fibo = new Fibo();

        }

        //first test
        [Test]
        public void Fibo_InputRange1_GetListOfFibo()
        {
            _fibo.Range = 1;
            var list = _fibo.GetFiboSeries();
            Assert.Multiple(() =>
            {
                CollectionAssert.IsNotEmpty(list);
                CollectionAssert.IsOrdered(list);
                CollectionAssert.Contains(list, 0);

            });
        }

        //second test range 6
        [Test]
        public void Fibo_InputRange6_GetListOfFibo()
        {
            int[] expected = { 0, 1, 1, 2, 3, 5 };
            _fibo.Range = 6;
            var list = _fibo.GetFiboSeries();
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(list, 3);
                Assert.AreEqual(list.Count, 6);
                CollectionAssert.DoesNotContain(list, 4);
                CollectionAssert.AreEquivalent(list, expected);

            });
        }





    }
}