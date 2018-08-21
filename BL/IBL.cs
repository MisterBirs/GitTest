using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public static class IBL
    {
        public static bool IsCanEat(this Piece piece, GameBoard gameBoard)
        {
            Players opponent = piece.player == Players.player_1 ? Players.player_2 : Players.player_1;
            Position right = new Position(piece.position.row - 1, piece.position.col + 1);
            Position left = new Position(piece.position.row - 1, piece.position.col - 1);
            Position JumpRight = new Position(piece.position.row - 2, piece.position.col + 2);
            Position JumpLeft = new Position(piece.position.row - 2, piece.position.col - 2);

            if (gameBoard.IsSquareEmpty(piece.position) || !(gameBoard.GetPieceFromPosition(piece.position).Equals(piece)))
                throw new Exception("The requested piece were not found on the board");

            if ((((Players)gameBoard.ReturnSquareStatus(right) == opponent) && gameBoard.ReturnSquareStatus(JumpRight) == squareStatus.empty)
                || (((Players)gameBoard.ReturnSquareStatus(left) == opponent) && gameBoard.ReturnSquareStatus(JumpLeft) == squareStatus.empty))
                return true;
            else
                return false;


        }
        public static bool IsCanEatMore(this Piece piece, GameBoard gameBoard)
        {
            Players opponent = piece.player == Players.player_1 ? Players.player_2 : Players.player_1;
            Position rightBottom = new Position(piece.position.row + 1, piece.position.col + 1);
            Position leftBottom = new Position(piece.position.row + 1, piece.position.col - 1);
            Position JumpRightBottom = new Position(piece.position.row + 2, piece.position.col + 2);
            Position JumpLeftBottom = new Position(piece.position.row + 2, piece.position.col - 2);
            bool canEatBehind = false;
            bool canEatFront = piece.IsCanEat(gameBoard);

            if ((((Players)gameBoard.ReturnSquareStatus(rightBottom) == opponent) && gameBoard.ReturnSquareStatus(JumpRightBottom) == squareStatus.empty)
                || (((Players)gameBoard.ReturnSquareStatus(leftBottom) == opponent) && gameBoard.ReturnSquareStatus(JumpLeftBottom) == squareStatus.empty))
                canEatBehind = true;

            return canEatBehind || canEatFront;



        }
        public static bool IsCanEatForwardRight(this Piece piece, GameBoard gameBoard)
        {
            Players opponent = piece.player == Players.player_1 ? Players.player_2 : Players.player_1;
            Position TopRight = new Position(piece.position.row - 1, piece.position.col + 1);
            Position JumpTopRight = new Position(piece.position.row - 2, piece.position.col + 2);
            if (gameBoard.IsSquareEmpty(piece.position) || !(gameBoard.GetPieceFromPosition(piece.position).Equals(piece)))
                throw new Exception("The requested piece were not found on the board");

            if (((Players)gameBoard.ReturnSquareStatus(TopRight) == opponent && gameBoard.ReturnSquareStatus(JumpTopRight) == squareStatus.empty))
                return true;
            else
                return false;


        }
        public static bool IsCanEatForwardLeft(this Piece piece, GameBoard gameBoard)
        {
            Players opponent = piece.player == Players.player_1 ? Players.player_2 : Players.player_1;
            Position TopLeft = new Position(piece.position.row - 1, piece.position.col - 1);
            Position JumpTopLeft = new Position(piece.position.row - 2, piece.position.col - 2);
            if (gameBoard.IsSquareEmpty(piece.position) || !(gameBoard.GetPieceFromPosition(piece.position).Equals(piece)))
                throw new Exception("The requested piece were not found on the board");

            if (((Players)gameBoard.ReturnSquareStatus(TopLeft) == opponent && gameBoard.ReturnSquareStatus(JumpTopLeft) == squareStatus.empty))
                return true;
            else
                return false;


        }
        public static bool IsCanEatBackRight(this Piece piece, GameBoard gameBoard)
        {
            Players opponent = piece.player == Players.player_1 ? Players.player_2 : Players.player_1;
            Position bottomRight = new Position(piece.position.row + 1, piece.position.col + 1);
            Position JumpBottomRight = new Position(piece.position.row + 2, piece.position.col + 2);
            if (gameBoard.IsSquareEmpty(piece.position) || !(gameBoard.GetPieceFromPosition(piece.position).Equals(piece)))
                throw new Exception("The requested piece were not found on the board");

            if (((Players)gameBoard.ReturnSquareStatus(bottomRight) == opponent && gameBoard.ReturnSquareStatus(JumpBottomRight) == squareStatus.empty))
                return true;
            else
                return false;


        }
        public static bool IsCanEatBackLeft(this Piece piece, GameBoard gameBoard)
        {
            Players opponent = piece.player == Players.player_1 ? Players.player_2 : Players.player_1;
            Position bottomLeft = new Position(piece.position.row + 1, piece.position.col - 1);
            Position JumpBottomLeft = new Position(piece.position.row + 2, piece.position.col - 2);
            if (gameBoard.IsSquareEmpty(piece.position) || !(gameBoard.GetPieceFromPosition(piece.position).Equals(piece)))
                throw new Exception("The requested piece were not found on the board");

            if (((Players)gameBoard.ReturnSquareStatus(bottomLeft) == opponent && gameBoard.ReturnSquareStatus(JumpBottomLeft) == squareStatus.empty))
                return true;
            else
                return false;


        }



        public static List<Move> LongestMoves(List<List<Move>> list)
        {
            List<Move> longestMovesList = new List<Move>();
            int SizeOfLargestMoves = 0;
            foreach (List<Move> subList in list)
            {
                foreach (Move move in subList)
                {
                    if (move.Path.Count() > SizeOfLargestMoves)
                    {
                        longestMovesList.Clear();
                        longestMovesList.Add(move);
                        SizeOfLargestMoves = move.Path.Count();
                    }
                    else if (move.Path.Count() == SizeOfLargestMoves)
                    {
                        longestMovesList.Add(move);
                    }

                }
            }
            return longestMovesList;

        }
        public static List<Move> EatMoreMoves(Piece piece, GameBoard gameBoard)
        {
            Players opponent = piece.player == Players.player_1 ? Players.player_2 : Players.player_1;
            if (!piece.IsCanEatMore(gameBoard))
            {
                Move move = new Move();
                move.Path.Add(new Position(piece.position));
                List<Move> finalStep = new List<Move>();
                finalStep.Add(move);
                return finalStep;
            }

            List<List<Move>> list = new List<List<Move>>();

            if (piece.IsCanEatForwardRight(gameBoard))
            {
                List<Move> l1 = EatMoreMoves(new Piece(piece.player, piece.PositionJumpForwardRight()), gameBoard);
                foreach (Move move in l1)
                {
                    move.EatedPieces.Insert(0, new Piece(opponent, piece.PositionForwardRight()));
                }
                list.Add(l1);
            }
            if (piece.IsCanEatForwardLeft(gameBoard))
            {
                List<Move> l = EatMoreMoves(new Piece(piece.player, piece.PositionJumpForwardLeft()), gameBoard);
                foreach (Move move in l)
                {
                    move.EatedPieces.Insert(0,new Piece(opponent, piece.PositionForwardLeft()));
                }
                list.Add(l);
            }
            if (piece.IsCanEatBackRight(gameBoard))
            {
                List<Move> l = EatMoreMoves(new Piece(piece.player, piece.PositionJumpBackRight()), gameBoard);
                foreach (Move move in l)
                {
                    move.EatedPieces.Insert(0, new Piece(opponent, piece.PositionBackRight()));
                }
                list.Add(l);
            }
            if (piece.IsCanEatBackLeft(gameBoard))
            {
                List<Move> l = EatMoreMoves(new Piece(piece.player, piece.PositionJumpBackLeft()), gameBoard);
                foreach (Move move in l)
                {
                    move.EatedPieces.Insert(0, new Piece(opponent, piece.PositionBackLeft()));
                }
                list.Add(l);
            }

            List<Move> longestMovesList = LongestMoves(list);
            foreach (Move move in longestMovesList)
                move.Path.Insert(0, piece.position);

            return longestMovesList;

        }
        public static List<Move> EatMoves(Piece piece, GameBoard gameBoard)
        {
            Players opponent = piece.player == Players.player_1 ? Players.player_2 : Players.player_1;
            List<Move> listOfMoves = new List<Move>();
            if(piece.IsCanEatForwardRight(gameBoard))
            {
                List<Move> listOfMovesFromForwardRight = EatMoreMoves(new Piece (piece.player,piece.PositionJumpForwardRight()), gameBoard);
                foreach(Move move in listOfMovesFromForwardRight)
                {
                    move.Piece = new Piece(piece);
                    move.EatedPieces.Insert(0,(new Piece(opponent, new Position(piece.PositionJumpForwardRight()))));
                    listOfMoves.Add(move);
                }
            }
            if (piece.IsCanEatForwardLeft(gameBoard))
            {
                List<Move> listOfMovesFromForwardLeft = EatMoreMoves(new Piece(piece.player, piece.PositionJumpForwardLeft()), gameBoard);
                foreach (Move move in listOfMovesFromForwardLeft)
                {
                    move.Piece = new Piece(piece);
                    move.EatedPieces.Insert(0, (new Piece(opponent, new Position(piece.PositionJumpForwardLeft()))));
                    listOfMoves.Add(move);
                }
            }
            return listOfMoves;


        }
        public static List<Move> PossibleMoves(this Piece piece, GameBoard gameBoard)
        {
            if (!piece.IsCanEat(gameBoard))
            {
                List<Move> moves = new List<Move>();
                Move move1 = new Move(piece, piece.PositionForwardRight());
                Move move2 = new Move(piece, piece.PositionForwardLeft());
                moves.Add(move1);
                moves.Add(move2);
                return moves;
            }
            else
                return EatMoves(piece, gameBoard);
        }

    }
}
