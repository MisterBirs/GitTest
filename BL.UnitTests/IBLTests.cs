using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;



namespace IBL.UnitTests
{
    [TestClass()]
    public class IBLTests
    {
        [TestMethod()]
        public void IsCanEatTest_CanEat_ReturnTrue()
        {
            Piece EaterPiece = new Piece(Players.player_1, new Position(4, 5));
            Piece EatedPiece = new Piece(Players.player_2, new Position(3, 6));
            GameBoard gameBoard = new GameBoard();
            gameBoard.PlacingPieces(EaterPiece);
            gameBoard.PlacingPieces(EatedPiece);


            bool result = BL.IBL.IsCanEat(EaterPiece, gameBoard);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsCanEatTest_CantEatBecauseSamePlayer_ReturnFlase()
        {
            Piece EaterPiece = new Piece(Players.player_1, new Position(4, 5));
            Piece EatedPiece = new Piece(Players.player_1, new Position(3, 6));
            GameBoard gameBoard = new GameBoard();
            gameBoard.PlacingPieces(EaterPiece);
            gameBoard.PlacingPieces(EatedPiece);


            bool result = BL.IBL.IsCanEat(EaterPiece, gameBoard);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void IsCanEatTest_CantEatBecauseCantJump_ReturnFlase()
        {
            Piece EaterPiece = new Piece(Players.player_1, new Position(6, 5));
            Piece EatedPiece = new Piece(Players.player_2, new Position(5, 6));
            Piece BlockerPiece = new Piece(Players.player_2, new Position(4, 7));

            GameBoard gameBoard = new GameBoard();
            gameBoard.PlacingPieces(EaterPiece);
            gameBoard.PlacingPieces(EatedPiece);
            gameBoard.PlacingPieces(BlockerPiece);


            bool result = BL.IBL.IsCanEat(EaterPiece, gameBoard);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void IsCanEatTest_ThereIsNothingToEat_ReturnFlase()
        {
            Piece EaterPiece = new Piece(Players.player_1, new Position(9, 9));
            Piece EatedPiece = new Piece(Players.player_2, new Position(8, 9));

            GameBoard gameBoard = new GameBoard();
            gameBoard.PlacingPieces(EaterPiece);
            gameBoard.PlacingPieces(EatedPiece);


            bool result = BL.IBL.IsCanEat(EaterPiece, gameBoard);

            Assert.IsFalse(result);
        }

        [TestMethod(), ExpectedException(typeof(Exception))]
        public void IsCanEatTest_EaterPieceWereNotOnABoard_Exception()
        {
            Piece EaterPiece = new Piece(Players.player_1, new Position(9, 9));
            GameBoard gameBoard = new GameBoard();

            bool result = BL.IBL.IsCanEat(EaterPiece, gameBoard);
        }

        [TestMethod(), ExpectedException(typeof(Exception))]
        public void IsCanEatTest_EatedPieceIsOnTheSquare_Exception()
        {
            Piece EaterPiece = new Piece(Players.player_1, new Position(9, 9));
            Piece EatedPiece = new Piece(Players.player_2, new Position(9, 9));

            GameBoard gameBoard = new GameBoard();
            gameBoard.PlacingPieces(EatedPiece);

            bool result = BL.IBL.IsCanEat(EaterPiece, gameBoard);
        }

        [TestMethod()]
        public void IsCanEatMoreTest_CanEatBottomRight_ReturnTrue()
        {
            GameBoard gameBoard = new GameBoard();
            Piece EaterPiece = new Piece(Players.player_1, 4, 4);
            Piece EatedPiece = new Piece(Players.player_2, 5, 5);
            gameBoard.PlacingPieces(EatedPiece, EaterPiece);

            bool result = EaterPiece.IsCanEatMore(gameBoard);

            Assert.IsTrue(result);

        }

        [TestMethod()]
        public void IsCanEatMoreTest_CanEatBottomLeft_ReturnTrue()
        {
            GameBoard gameBoard = new GameBoard();
            Piece EaterPiece = new Piece(Players.player_1, 4, 4);
            Piece EatedPiece = new Piece(Players.player_2, 5, 3);
            gameBoard.PlacingPieces(EatedPiece, EaterPiece);

            bool result = EaterPiece.IsCanEatMore(gameBoard);

            Assert.IsTrue(result);

        }

        [TestMethod()]
        public void IsCanEatMoreTest_CantEatBecauseSamePlayer_ReturnFlase()
        {
            GameBoard gameBoard = new GameBoard();
            Piece EaterPiece = new Piece(Players.player_1, 4, 4);
            Piece EatedPiece = new Piece(Players.player_1, 5, 3);
            gameBoard.PlacingPieces(EatedPiece, EaterPiece);

            bool result = EaterPiece.IsCanEatMore(gameBoard);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void IsCanEatForwardRightTest()
        {
            Piece EaterPiece = new Piece(Players.player_1, 4, 5);
            Piece EatedPiece = new Piece(Players.player_2, 3, 6);

            GameBoard gameBoard = new GameBoard(EaterPiece, EatedPiece);

            bool result = EaterPiece.IsCanEatForwardRight(gameBoard);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsCanEatForwardLeftTest()
        {
            Piece EaterPiece = new Piece(Players.player_1, 4, 5);
            Piece EatedPiece = new Piece(Players.player_2, 3, 4);

            GameBoard gameBoard = new GameBoard(EaterPiece, EatedPiece);

            bool result = EaterPiece.IsCanEatForwardLeft(gameBoard);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsCanEatBackRightTest()
        {
            Piece EaterPiece = new Piece(Players.player_1, 4, 5);
            Piece EatedPiece = new Piece(Players.player_2, 5, 6);

            GameBoard gameBoard = new GameBoard(EaterPiece, EatedPiece);

            bool result = EaterPiece.IsCanEatBackRight(gameBoard);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsCanEatBackLeftTest()
        {
            Piece EaterPiece = new Piece(Players.player_1, 4, 5);
            Piece EatedPiece = new Piece(Players.player_2, 5, 4);

            GameBoard gameBoard = new GameBoard(EaterPiece, EatedPiece);

            bool result = EaterPiece.IsCanEatBackLeft(gameBoard);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void LargestsMovesTest()
        {
            List<Move> list1 = new List<Move>();

            Move move1 = new Move(new Piece(Players.player_1, 1, 1));
            for (int i = 2; i < 4; i++)
                move1.Path.Add(new Position(i, i + 2));

            Move move2 = new Move(new Piece(Players.player_1, 0, 0));
            for (int i = 0; i < 5; i++)
                move2.Path.Add(new Position(i, i + 1));

            list1.Add(move1);
            list1.Add(move2);

            List<Move> list2 = new List<Move>();
            Move move3 = new Move(new Piece(Players.player_1, 2, 2));
            for (int i = 5; i < 9; i++)
                move3.Path.Add(new Position(i, 0));
            list2.Add(move3);

            List<Move> list3 = new List<Move>();
            Move move4 = new Move(new Piece(Players.player_1, 3, 3));
            for (int i = 2; i < 6; i++)
                move4.Path.Add(new Position(i, 2));
            Move move5 = new Move(new Piece(Players.player_1, 0, 3));
            for (int i = 0; i < 4; i++)
                move5.Path.Add(new Position(i, i+3));
            Move move6 = new Move(new Piece(Players.player_1, 0, 3));
            for (int i = 4; i < 9; i++)
                move6.Path.Add(new Position(9, i));

            list3.Add(move4);
            list3.Add(move5);
            list3.Add(move6);

             List<List<Move>> finalList = new List<List<Move>>();
            finalList.Add(list1);
            finalList.Add(list2);
            finalList.Add(list3);

            List<Move> result = BL.IBL.LongestMoves(finalList);
            bool flag = true;
            foreach(Move move in result)
            {
                if (move.Path.Count() != 5)
                    flag = false;
            }
            Assert.IsTrue(flag);



        }
    }
}