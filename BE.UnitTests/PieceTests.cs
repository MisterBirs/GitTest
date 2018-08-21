using Microsoft.VisualStudio.TestTools.UnitTesting;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BETests.UnitTests
{
    [TestClass()]
    public class PieceTests
    {
        [TestMethod()]
        public void EqualsTest_EqualPieces_ReturnTrue()
        {
            Piece piece1 = new Piece(Players.player_1, new Position(3, 4));
            Piece piece2 = new Piece(Players.player_1, new Position(3, 4));

            bool result = piece1.Equals(piece2);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void EqualsTest_NotEqualPieces_ReturnFalse()
        {
            Piece piece1 = new Piece(Players.player_1, new Position(3, 4));
            Piece piece2 = new Piece(Players.player_1, new Position(3, 1));

            bool result = piece1.Equals(piece2);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SetPositionTest()
        {
            Piece piece = new Piece(Players.player_1, new Position(2, 3));
            Position position = new Position(1, 0);
            piece.SetPosition(position);

            Assert.AreEqual(position, piece.position);

        }

        [TestMethod()]
        public void PositionForwardRightTest()
        {
            Piece piece = new Piece(Players.player_1, 4, 5);
            Assert.AreEqual(piece.PositionForwardRight(), new Position(3, 6));
        }
        [TestMethod()]
        public void PositionForwardLeftTest()
        {
            Piece piece = new Piece(Players.player_1, 4, 5);
            Assert.AreEqual(piece.PositionForwardLeft(), new Position(3, 4));
        }
        [TestMethod()]
        public void PositionBackRightTest()
        {
            Piece piece = new Piece(Players.player_1, 4, 5);
            Assert.AreEqual(piece.PositionBackRight(), new Position(5, 6));
        }
        [TestMethod()]
        public void PositionBackLeftTest()
        {
            Piece piece = new Piece(Players.player_1, 4, 5);
            Assert.AreEqual(piece.PositionBackLeft(), new Position(5, 4));
        }

    }
}