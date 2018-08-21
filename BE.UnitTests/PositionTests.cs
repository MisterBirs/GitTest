using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BETests.UnitTests
{
    [TestClass()]
    public class PositionTests
    {
        [TestMethod()]
        public void EqualsTest_PositionsAreEquals_ReturnTrue()
        {
            Position position1 = new Position(4, 5);
            Position position2 = new Position(4, 5);

            bool result = position1.Equals(position2);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void EqualsTest_PositionsAreNotEquals_ReturnFalse()
        {
            Position position1 = new Position(4, 5);
            Position position2 = new Position(4, 6);

            bool result = position1.Equals(position2);

            Assert.IsFalse(result);
        }
    }
}