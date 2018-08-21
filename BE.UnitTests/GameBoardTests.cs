using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BE;



namespace BETests.UnitTests
{

    [TestClass, TestCategory("GameBoard")]
    public class GameBoardTests
    {
        [TestMethod]
        public void IsSlotEmpty_SquareIsEmpty_ReturnTrue()
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.ResetBoard();

            bool result = gameBoard.IsSquareEmpty(new Position(0, 0));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsSlotEmpty_SquaretIsNotEmpty_ReturnFalse()
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.ResetBoard();

            bool result = gameBoard.IsSquareEmpty(new Position(0, 1));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsInBoardArea_PositionInBottomRightEdgeInArea_ReturnTrue()
        {
            GameBoard gameBoard = new GameBoard();
            bool result = gameBoard.IsInBoardArea(new Position(9, 9));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsInBoardArea_PositionInTopLeftEdgeInArea_ReturnTrue()
        {
            GameBoard gameBoard = new GameBoard();
            bool result = gameBoard.IsInBoardArea(new Position(0, 0));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsInBoardArea_PositionOnTheRightOutsideTheArea_ReturnFalse()
        {
            GameBoard gameBoard = new GameBoard();
            bool result = gameBoard.IsInBoardArea(new Position(9, 10));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsInBoardArea_PositionOnTheBottomOutsideTheArea_ReturnFalse()
        {
            GameBoard gameBoard = new GameBoard();
            bool result = gameBoard.IsInBoardArea(new Position(10, 9));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsInBoardArea_PositionOnTheLeftOutsideTheArea_ReturnFalse()
        {
            GameBoard gameBoard = new GameBoard();
            bool result = gameBoard.IsInBoardArea(new Position(9, -1));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsInBoardArea_PositionOnTheTopOutsideTheArea_ReturnFalse()
        {
            GameBoard gameBoard = new GameBoard();
            bool result = gameBoard.IsInBoardArea(new Position(-1, 0));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckSquareStatus_PositionOutSideTheArea_ReturnOutside()
        {
            GameBoard gameBoard = new GameBoard();
            var result = gameBoard.ReturnSquareStatus(new Position(-1, 0));

            Assert.AreEqual(squareStatus.outside, result);

        }

        [TestMethod]
        public void CheckSquareStatus_SquareIsEmpty_ReturnEmpty()
        {
            GameBoard gameBoard = new GameBoard();
            var result = gameBoard.ReturnSquareStatus(new Position(0, 0));

            Assert.AreEqual(squareStatus.empty, result);

        }

        [TestMethod]
        public void CheckSquareStatus_PieceOfPlayer1InSquare_Player1()
        {
            GameBoard gameBoard = new GameBoard();
            var result = gameBoard.ReturnSquareStatus(new Position(0, 0));

            Assert.AreEqual(squareStatus.empty, result);

        }

        [TestMethod()]
        public void PlacingPiecesTest_PlacingAPieceSuccessfully()
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.PlacingPieces(new Piece(Players.player_1, 5, 6), new Piece(Players.player_1, 0, 0));

            bool result = !gameBoard.IsSquareEmpty(new Position(5, 6)) && !gameBoard.IsSquareEmpty(new Position(0, 0));
            Assert.IsTrue(result);

        }

        [TestMethod(), ExpectedException(typeof(Exception))]
        public void PlacingPiecesTest_PlacingOutSideOfArea_Exception()
        {
            GameBoard gameBoard = new GameBoard();
            Piece piece = new Piece(Players.player_1, new Position(5, 10));
            gameBoard.PlacingPieces(piece);
        }

        [TestMethod(), ExpectedException(typeof(Exception))]
        public void PlacingPiecesTest_alreadyContainsAPiece_Exception()
        {
            GameBoard gameBoard = new GameBoard();
            Piece piece1 = new Piece(Players.player_1, new Position(4, 2));
            Piece piece2 = new Piece(Players.player_1, new Position(4, 2));
            gameBoard.PlacingPieces(piece1);
            gameBoard.PlacingPieces(piece2);

        }

        [TestMethod()]
        public void MoveAPieceTest_MoveSuccessfully()
        {
            GameBoard gameBoard = new GameBoard();
            Position SourcePosition = new Position(4, 5);
            Position destinationPosition = new Position(1, 0);
            Piece piece = new Piece(Players.player_1, SourcePosition);
            gameBoard.PlacingPieces(piece);
            gameBoard.MoveAPiece(ref piece, destinationPosition);

            bool result = gameBoard.GetPieceFromPosition(destinationPosition).Equals(piece)
                && gameBoard.ReturnSquareStatus(SourcePosition) == squareStatus.empty
                && gameBoard.ReturnSquareStatus(destinationPosition) == squareStatus.player_1;

            Assert.IsTrue(result);
        }

        [TestMethod(), ExpectedException(typeof(Exception))]
        public void MoveAPieceTest_SquareIsOutSideOfArea_Exception()
        {
            GameBoard gameBoard = new GameBoard();
            Position SourcePosition = new Position(4, 5);
            Position destinationPosition = new Position(-1, 0);
            Piece piece = new Piece(Players.player_1, SourcePosition);
            gameBoard.PlacingPieces(piece);
            gameBoard.MoveAPiece(ref piece, destinationPosition);

            bool result = gameBoard.GetPieceFromPosition(destinationPosition).Equals(piece)
                && gameBoard.ReturnSquareStatus(SourcePosition) == squareStatus.empty
                && gameBoard.ReturnSquareStatus(destinationPosition) == squareStatus.player_1;

            Assert.IsTrue(result);
        }

        [TestMethod(), ExpectedException(typeof(Exception))]
        public void MoveAPieceTest_alreadyContainsAPiece_Exception()
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.PlacingPieces(new Piece(Players.player_1, new Position(1, 0)));
            Position SourcePosition = new Position(4, 5);
            Position destinationPosition = new Position(1, 0);
            Piece piece = new Piece(Players.player_1, SourcePosition);
            gameBoard.PlacingPieces(piece);
            gameBoard.MoveAPiece(ref piece, destinationPosition);

            bool result = gameBoard.GetPieceFromPosition(destinationPosition).Equals(piece)
                && gameBoard.ReturnSquareStatus(SourcePosition) == squareStatus.empty
                && gameBoard.ReturnSquareStatus(destinationPosition) == squareStatus.player_1;

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetPiecesFromPositionTest_ThereIsPieceInPosition_ReturnPiece()
        {
            Piece piece = new Piece(Players.player_1, new Position(4, 5));
            GameBoard gameBoard = new GameBoard();
            gameBoard.PlacingPieces(piece);

            Piece result = gameBoard.GetPieceFromPosition(new Position(4, 5));
            Assert.AreEqual(piece, result);
        }

        [TestMethod()]
        public void GetPiecesFromPositionTest_ThereisNoPieceInPosition_returnNull()
        {
            GameBoard gameBoard = new GameBoard();
            Piece result = gameBoard.GetPieceFromPosition(new Position(4, 6));
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void RemovePieceTest_RemovalSuccessful()
        {
            Piece piece1 = new Piece(Players.player_1, 0, 0);
            Piece piece2 = new Piece(Players.player_2, 9, 9);
            GameBoard gameBoard = new GameBoard(piece1, piece2);

            gameBoard.RemovePiece(piece1,piece2);
            bool result = gameBoard.IsSquareEmpty(piece1.position) && gameBoard.IsSquareEmpty(piece2.position);
            Assert.IsTrue(result);

        }

        [TestMethod(), ExpectedException(typeof(Exception))]
        public void RemovePieceTest_SquareIsEmpty_Exception()
        {
            Piece piece = new Piece(Players.player_1, 0, 0);
            GameBoard gameBoard = new GameBoard();

            gameBoard.RemovePiece(piece);
        }

        [TestMethod(), ExpectedException(typeof(Exception))]
        public void RemovePieceTest_SquareIsOutSideOfArea_Exception()
        {
            Piece piece = new Piece(Players.player_1, -1, 0);
            GameBoard gameBoard = new GameBoard();

            gameBoard.RemovePiece(piece);
        }

        [TestMethod(), ExpectedException(typeof(Exception))]
        public void RemovePieceTest_ThereIsAnotherPieceOnTheSquare_Exception()
        {
            Piece piece = new Piece(Players.player_1, 0, 0);
            GameBoard gameBoard = new GameBoard();
            gameBoard.PlacingPieces(new Piece(Players.player_2, 0, 0));

            gameBoard.RemovePiece(piece);
        }

        [TestMethod()]
        public void GameBoardConstructorTest()
        {
            GameBoard gameBoard = new GameBoard(new Piece(Players.player_1, 0, 0), new Piece(Players.player_2, 1, 1));
            bool result = !gameBoard.IsSquareEmpty(new Position(0, 0)) && !gameBoard.IsSquareEmpty(new Position(1, 1));
            Assert.IsTrue(result);
        }
    }
}
