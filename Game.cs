using System;

namespace ticTacToe
{
    public class Game
    {
        public Board GameBoard;
        public char Turn;
        public string Status;
        public void start()
        {
            this.Status = "Continue";
            this.Turn = 'X';
            this.GameBoard = new Board();
            displayBoard();
            while(Status == "Continue")
            {
                string endOfTurn = takeTurn();
                if(endOfTurn == "Nice move!")
                {
                    if(this.Turn == 'X')
                    {
                        this.Turn = 'O';
                    } else {
                        this.Turn = 'X';
                    }
                } else {
                    Console.WriteLine(endOfTurn);
                }
                string stat = checkForVictory();
                this.Status = stat;
                displayBoard();
            }
            Console.WriteLine(this.Status);
        }
        public void displayBoard()
        {
            foreach(var row in GameBoard.Rows)
            {
                string fullRow = "";
                foreach(var space in row.Spaces)
                {
                    fullRow += space.Index+": "+space.Marker.ToString()+" ";
                }
                Console.WriteLine(fullRow);
                Console.WriteLine();
            }
        }
        public string takeTurn()
        {
            Console.WriteLine($"{Turn}'s turn!");
            Console.WriteLine("Enter a space index:");
            string userInput = Console.ReadLine();
            foreach(var row in GameBoard.Rows)
            {
                foreach(var space in row.Spaces)
                {
                    if(userInput == space.Index)
                    {
                        space.Marker = Turn;
                        return "Nice move!";
                    }
                }
            }
            return "That wasn't a valid input. Enter the value of the index of the space in which you would like to play (e.g. 'A1' or 'C3'";
        }
        public string checkForVictory()
        {
            string weHaveAWinner = "Continue";
            string XVictory = "XXX";
            string OVictory = "OOO";
            string col1 = "";
            string col2 = "";
            string col3 = "";
            string forwardDiagonal = "";
            string backwardDiagonal = "";
            bool isCatsGame = true;
            foreach(var row in GameBoard.Rows)
            {
                string checkHorizontal = "";
                foreach(var space in row.Spaces)
                {
                    // add up diagonal markers
                    if(space.Index == "A1" || space.Index == "B2" || space.Index == "C3")
                    {
                        forwardDiagonal += space.Marker.ToString();
                    }
                    if(space.Index == "A3" || space.Index == "B2" || space.Index == "C1")
                    {
                        backwardDiagonal += space.Marker.ToString();
                    }
                    // add up markers in each column for column victory checks
                    if(space.ColumnInd == 1)
                    {
                        col1 += space.Marker.ToString();
                    }
                    if(space.ColumnInd == 2)
                    {
                        col2 += space.Marker.ToString();
                    }
                    if(space.ColumnInd == 3)
                    {
                        col3 += space.Marker.ToString();
                    }
                    // add up each space in row to check for horizontal victory
                    checkHorizontal += space.Marker.ToString();
                    // if there is a space open on the board, it's not a cat's game (cats' game? (cats game???))
                    if(space.Marker == '-')
                    {
                        isCatsGame = false;
                    }
                }
                // check for horizontal victories
                if(checkHorizontal == OVictory)
                {
                    weHaveAWinner = "O wins!";
                }
                if(checkHorizontal == XVictory)
                {
                    weHaveAWinner = "X wins!";
                }
            }
            // check for vertical victories
            if(col1 == XVictory || col2 == XVictory || col3 == XVictory)
            {
                weHaveAWinner = "X wins!";
            }
            if(col1 == OVictory || col2 == OVictory || col3 == OVictory)
            {
                weHaveAWinner = "O wins!";
            }
            // check for dagonal victories
            if(forwardDiagonal == OVictory)
                {
                    weHaveAWinner = "O wins!";
                }
            if(backwardDiagonal == XVictory)
            {
                weHaveAWinner = "X wins!";
            }
            // check for cats game
            if(isCatsGame)
            {
                weHaveAWinner = "Cats game!";
            }
            return weHaveAWinner;
        }
    }
}
