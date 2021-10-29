namespace ticTacToe
{
    public class Space
    {
        public char Row;
        public int ColumnInd;
        public string Index;
        public char Marker;
        public Space(char row, int column)
        {
            this.Row = row;
            this.ColumnInd = column;
            this.Index = row.ToString()+column.ToString();
            this.Marker = '-';
        }
    }
}
