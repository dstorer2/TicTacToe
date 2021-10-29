using System;
using System.Collections;
using System.Collections.Generic;

namespace ticTacToe
{
    public class Board
    {
        public List<Row> Rows;
        public Board()
        {
            this.Rows = new List<Row>{};
            char row = 'A';
            while(row != 'D')
            {
                this.Rows.Add(new Row(row));
                row++;
            }
        }
    }
}
