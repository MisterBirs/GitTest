using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GameBoard
    {
        public Piece[,] board { get; set; }

        public GameBoard()
        {
            board = new Piece[10, 10];
        }
        public GameBoard(params Piece[] pieces)
        {
            board = new Piece[10, 10];
            PlacingPieces(pieces);
        }
        public void ResetBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = (i + 1) % 2; j < board.GetLength(1); j = j + 2)
                {
                    board[i, j] = new Piece(Players.player_2, new Position(i, j));
                }
            }

            for (int i = board.GetLength(0) - 1; i > 5; i--)
            {
                for (int j = (i + 1) % 2; j < board.GetLength(1); j = j + 2)
                {
                    board[i, j] = new Piece(Players.player_1, new Position(i, j));
                }
            }
        }
        public bool IsSquareEmpty(Position position)
        {
            if (board[position.row, position.col] == null)
                return true;
            else
                return false;
        }
        public bool IsInBoardArea(Position inputPosition)
        {
            if (inputPosition.row < 0 || inputPosition.row >= board.GetLength(0) || inputPosition.col < 0 || inputPosition.col >= board.GetLength(1))
                return false;
            else
                return true;
        }
        public squareStatus ReturnSquareStatus(Position inputPosition)
        {
            if (!IsInBoardArea(inputPosition))
                return squareStatus.outside;
            if (IsSquareEmpty(inputPosition))
                return squareStatus.empty;
            if (board[inputPosition.row, inputPosition.col].player == Players.player_1)
                return squareStatus.player_1;
            else
                return squareStatus.player_2;
        }
        public void PlacingPieces(params Piece[] pieces)
        {
            foreach (Piece piece in pieces)
            {
                if (!IsInBoardArea(piece.position))
                    throw new Exception("Placing Pieces is outside the area of the game board");

                if (ReturnSquareStatus(piece.position) != squareStatus.empty)
                    throw new Exception("The square already contains a piece");

                board[piece.position.row, piece.position.col] = piece;
            }

        }
        public void MoveAPiece(ref Piece piece, Position destinationPosition)
        {
            if (!IsInBoardArea(destinationPosition))
                throw new Exception("Placing Pieces is outside the area of the game board");

            if (!IsSquareEmpty(destinationPosition))
                throw new Exception("The square already contains a piece");

            board[piece.position.row, piece.position.col] = null;
            piece.SetPosition(destinationPosition);
            PlacingPieces(piece);
        }
        public Piece GetPieceFromPosition(Position position)
        {
            if (ReturnSquareStatus(position) == squareStatus.empty || ReturnSquareStatus(position) == squareStatus.outside)
                return null;
            else
                return board[position.row, position.col];
        }
        public void RemovePiece(params Piece[] pieces)
        {
            foreach (Piece piece in pieces)
            {
                if (!IsInBoardArea(piece.position))
                    throw new Exception("ERROR, The piece can not be removed because the square is  outside the area of the game board");
                if (IsSquareEmpty(piece.position))
                    throw new Exception("ERROR, The piece can not be removed because the square is empty");
                if (!GetPieceFromPosition(piece.position).Equals(piece))
                    throw new Exception("ERROR, The requested piece is not found on the board");

                board[piece.position.row, piece.position.col] = null;
            }
        }


    }
}
