using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Position
    {
        public int row { get; set; }
        public int col { get; set; }

        public Position(int inputRow, int inputCol) { this.row = inputRow; this.col = inputCol; }
        public Position(Position inputPosition) { row = inputPosition.row; col = inputPosition.col; }

        public override bool Equals(object inputPosition)
        {
            return ((Position)inputPosition).row == this.row && ((Position)inputPosition).col == this.col;
        }

    }
}
