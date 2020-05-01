using System;

namespace EXTicTacToe
{
    class MainClass
    {
        /*
        Tic Tac Toe : Use arrays, loops, ifs, user input, etc. to create a tic-tac-toe game.
        Create a 3 x 3 tic-tac-toe board.
        This will be a 3 x 3 array of char.
        Initialize your tic-tac-toe board with the dash character ("-").
        Inside of a loop . . .
            Ask player 1 where he/she would like to move.
            Input the numeric row.
            Input the numeric col.
            Put an 'X' at that location in the board array.
            Print out the board.
            Ask player 2 where he/she would like to move.
            Input the numeric row.
            Input the numeric col.
            Put an 'O' at that location in the board array.
            Print out the board.
            Repeat.
        The above description is the basic game.
        Improvement: If you haven't done so yet, create a Method that will take the board array and print it out.
        Above, at the two places that you need to print out the board, make a call to this new Method.
        Improvement: If you haven't done so yet, add some checking to make sure that the user input (the row and the col) is a valid move.
        Entering numbers that are outside the size of the board is invalid.
        Entering numbers that overwrite an existing piece is invalid.
        It would be easy to implement some or all of this checking as a new Method (but not required).
        Bonus (+5 points): Try and figure out if someone has won.
        */
        public static void Main(string[] args)
        {
            char[,] board = CreateBoard();     //Created a 3 x 3 tic-tac-toe board. This will be a 3 x 3 array of char.

            Console.WriteLine("Let's play Tic Tac Toe!");
            Console.WriteLine("What is the name of Player 1?");
            string player1 = Console.ReadLine();
            Console.WriteLine("What is the name of Player 2?");
            string player2 = Console.ReadLine();
            Console.WriteLine($"{player1} is X and {player2} is O.");
            Console.WriteLine($"{player1} goes first.");
            PrintBoard(board); //Prints the empty board
            char play1 = 'X';
            char play2 = 'O';
            bool didIWin; //created boolean value type called didIWin

            do
            {
                board = GetPosition(player1, play1, board); //Ask player 1 where he/she would like to move.
                PrintBoard(board); //Print out the board.
                didIWin = CheckForWin(board, play1, player1); //Try and figure out if player 1 has won.
                if (didIWin == true) //if there is a winner, the game is over
                {
                    break; 
                }
                
                board = GetPosition(player2, play2, board);//Ask player 2 where he/she would like to move.
                PrintBoard(board); //Print out the board.
                didIWin = CheckForWin(board, play2, player2); //Try and figure out if player 2 has won.
                if (didIWin == true) //if there is a winner, the game is over
                {
                    break;
                }
            } while (didIWin == false);
        }//end Main ()

        public static char[,] CreateBoard() //Created a 3 x 3 tic-tac-toe board. This will be a 3 x 3 array of char.
        {
            char[,] board = new char[3, 3];
            for (int row = 0; row <= board.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= board.GetUpperBound(1); col++)
                {
                    board[row, col] = '-'; //Initialize your tic - tac - toe board with the dash character("-").
                }
                Console.WriteLine();
            }
            return board;
        }//end CreateBoard()

        public static char[,] GetPosition(string player, char playValue, char[,] board) //Asking the player for their next position, and checking if it is valid

        {
            int row;
            int column;
            do
            {
                try
                {
                    Console.WriteLine($"{player}, what number row would you like to move to? ");//Asks player 1 and 2 where he/she would like to move.
                    Console.WriteLine("Please input a number from 0 to 2: ");
                    row = int.Parse(Console.ReadLine());//Input the numeric row.

                    Console.WriteLine($"{player}, what number column would you like to move to? ");
                    Console.WriteLine("Please input a number from 0 to 2: ");
                    column = int.Parse(Console.ReadLine());//Input the numeric col.

                    if ( row > 2 || row < 0 || column > 2 || column < 0)//Entering numbers that are outside the size of the board is invalid.
                     {
                        Console.WriteLine("Please enter a valid number row or column"); 
                        Console.WriteLine();
                        continue;
                    }

                    if (board[row, column] == '-')
                    {
                        board[row, column] = playValue; //Put an 'X' or 'O' at that location in the board array.
                        return board;
                    }
                    else  //Entering numbers that overwrite an existing piece is invalid.
                    {
                        Console.WriteLine("HEY NO STEALING POSITIONS!");
                        Console.WriteLine();
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            } while (true);
        }//end GetPosition()

        public static void PrintBoard(char[,] board) //create a Method that will take the board array and print it out.
        {
            for (int row = 0; row <= board.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= board.GetUpperBound(1); column++)
                {
                    Console.Write(board[row, column]);
                }
                Console.WriteLine();
            }
        }//end PrintBoard()

        public static bool CheckForWin(char[,] board, char playValue, string player) //Try and figure out if someone has won.
        {
            if (   board[0,0] == playValue && board[0,1] == playValue && board[0,2] == playValue
                || board[1,0] == playValue && board[1,1] == playValue && board[1,2] == playValue
                || board[2,0] == playValue && board[2,1] == playValue && board[2,2] == playValue
                || board[0,0] == playValue && board[1,1] == playValue && board[2,2] == playValue
                || board[0,2] == playValue && board[1,1] == playValue && board[2,0] == playValue
                || board[0,0] == playValue && board[1,0] == playValue && board[2,0] == playValue
                || board[0,1] == playValue && board[1,1] == playValue && board[2,1] == playValue
                || board[0,2] == playValue && board[1,2] == playValue && board[2,2] == playValue)
            {
                Console.WriteLine($"Congratulations!!! {player} Wins!");
                Console.WriteLine("Thanks for playing!");
                return true;
            }
            return false;
        }//end CheckForWin()
    }
}
