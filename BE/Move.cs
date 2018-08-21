using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Move
    {
        public Piece Piece { get; set; }
        public List<Position> Path { get; set; }
        public List<Piece> EatedPieces { get; set; }

        public Move()
        {
            Path = new List<Position>();
            EatedPieces = new List<Piece>();
        }

        public Move(Piece inputPiece)
        {
            Piece = inputPiece;
            Path = new List<Position>();
            EatedPieces = new List<Piece>();
        }

        public Move(Piece inputPice, Position position)
        {
            Piece = inputPice;
            Path = new List<Position>();
            EatedPieces = new List<Piece>();
            Path.Add(position);
        }



    }
}
