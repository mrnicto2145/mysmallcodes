using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace myNamespace{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void OrdinaryTest()
        {
            double a = 1;
            double b = -3;
            double c = 2;
            
            var result = ClassLibraryForTests.Solver.Solve(a,b,c);

            ClassicAssert.AreEqual(2, result[0]);
            ClassicAssert.AreEqual(1, result[1]);        
        }
    }
}
