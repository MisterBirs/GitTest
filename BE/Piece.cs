using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Piece
    {
        public Players player { get; set; }
        public Position position { get; set; }


        public Piece(Players inputPlayer, int inputRow, int inputCol)
        {
            this.player = inputPlayer;
            this.position = new Position(inputRow, inputCol);
        }
        public Piece(Players inputPlayer, Position inputPosition)
        {
            this.player = inputPlayer;
            position = new Position(inputPosition);
        }
        public Piece(Piece piece)
        {
            this.player = piece.player;
            this.position = new Position(position);
        }

        public void SetPosition(Position inputPosition)
        {
            this.position.row = inputPosition.row;
            this.position.col = inputPosition.col;
        }
        public Position PositionForwardRight()
        {
            return new Position(position.row - 1, position.col + 1);
        }
        public Position PositionForwardLeft()
        {
            return new Position(position.row - 1, position.col - 1);
        }
        public Position PositionBackRight()
        {
            return new Position(position.row + 1, position.col + 1);
        }
        public Position PositionBackLeft()
        {
            return new Position(position.row + 1, position.col - 1);
        }

        public Position PositionJumpForwardRight()
        {
            return new Position(position.row - 2, position.col + 2);
        }//test
        public Position PositionJumpForwardLeft()
        {
            return new Position(position.row - 2, position.col - 2);
        }
        public Position PositionJumpBackRight()
        {
            return new Position(position.row + 2, position.col + 2);
        }
        public Position PositionJumpBackLeft()
        {
            return new Position(position.row + 2, position.col - 2);
        }





        public override bool Equals(object obj)
        {
            return ((Piece)obj).player == this.player && ((Piece)obj).position.Equals(this.position);
        }
        

    }
}
