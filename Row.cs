using System.Collections.Generic;

namespace ticTacToe
{
    public class Row
    {
        public List<Space> Spaces;
        public char RowInd;
        public Row(char ind)
        {
            this.RowInd = ind;
            this.Spaces = new List<Space>{};
            int i = 1;
            while(i < 4)
            {
                this.Spaces.Add(new Space(ind, i));
                i++;
            }
        }
    }
}
