using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_3280_Assignment_4
{
    /// <summary>
    /// Here is my class that handles the business logic for the tic-tac-toe game.
    /// </summary>
    class ticTacToe
    {
        /// <summary>
        /// constructor for the tic-tac-toe game.
        /// </summary>
        

        /// <summary>
        /// string that hold the tic tac toe multi demensional array board.
        /// </summary>
        public string[,] ticTacBoard { get; set; }
        
        /// <summary>
        /// int that holds player one wins.
        /// </summary>
        public int playerOneWins = 0;
        
        /// <summary>
        /// int that holds player two wins.
        /// </summary>
        public int playerTwoWins = 0;
        
        /// <summary>
        /// int that holds ties.
        /// </summary>
        public int ties = 0;

        /// <summary>
        /// boolean used to see if the game has started and allow the tiles to be clicked.
        /// </summary>
        public static bool gameHasStarted = false;

        /// <summary>
        /// boolean used to hold if it's player one's turn. If it's false, then it's player two's turn.
        /// </summary>
        public static bool playerOnesTurn = true;

        /// <summary>
        /// holds a value that holds how many turns have been taken. Helps the method that triggers if there is a tie.
        /// </summary>
        public static int turnCount;

        /// <summary>
        /// Method that checks if there is a game winning move. Called after each turn.
        /// </summary>
        public bool checkIfWon()
        {
            bool win1 = checkHorizontalWin();
            bool win2 = checkVerticalWin();                 //call the three methods to determine who won.
            bool win3 = checkDiagonallWin();

            if (win1 == false && win2 == false && win3 == false)    //only continues if there isn't a win
            {
                if (playerOnesTurn == true)
                {
                    playerOnesTurn = false;             //switch turns
                    return false;

                }
                else
                {
                    playerOnesTurn = true;             //switch turns
                    return false;
                }
            }
            else
            {
                if (playerOnesTurn == true)           //award player 1   
                {
                    playerOneWins++;
                    return true;
                }
                else
                {
                    playerTwoWins++;  //award player 2
                    return true;
                }
            }
        }
        
        /// <summary>
        /// Method to check the horizontal rows for a win. lots of if statements
        /// </summary>
        bool checkHorizontalWin()
        {
            if ((ticTacBoard[0, 0] == "X" && ticTacBoard[0, 1] == "X" && ticTacBoard[0, 2] == "X") || (ticTacBoard[0, 0] == "O" && ticTacBoard[0, 1] == "O" && ticTacBoard[0, 2] == "O"))
            {
                ticTacBoard[0, 0] = "W";
                ticTacBoard[0, 1] = "W";
                ticTacBoard[0, 2] = "W";
                return true;
                

                

            }
            else if ((ticTacBoard[1, 0] == "X" && ticTacBoard[1, 1] == "X" && ticTacBoard[1, 2] == "X") || (ticTacBoard[1, 0] == "O" && ticTacBoard[1, 1] == "O" && ticTacBoard[1, 2] == "O"))
            {

                ticTacBoard[1, 0] = "W";
                ticTacBoard[1, 1] = "W";
                ticTacBoard[1, 2] = "W";
                return true;
                

            }
            else if ((ticTacBoard[2, 0] == "X" && ticTacBoard[2, 1] == "X" && ticTacBoard[2, 2] == "X") || (ticTacBoard[2, 0] == "O" && ticTacBoard[2, 1] == "O" && ticTacBoard[2, 2] == "O"))
            {
                ticTacBoard[2, 0] = "W"; 
                ticTacBoard[2, 1] = "W"; 
                ticTacBoard[2, 2] = "W";
                return true;
                
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method to check the vertical rows for a win. lots of if statements
        /// </summary>
        bool checkVerticalWin()
        {
            if ((ticTacBoard[0, 0] == "X" && ticTacBoard[1, 0] == "X" && ticTacBoard[2, 0] == "X") || (ticTacBoard[0, 0] == "O" && ticTacBoard[1, 0] == "O" && ticTacBoard[2, 0] == "O"))
            {
                ticTacBoard[0, 0] = "W";
                ticTacBoard[1, 0] = "W";
                ticTacBoard[2, 0] = "W";
                return true;

            }
            else if ((ticTacBoard[0, 1] == "X" && ticTacBoard[1, 1] == "X" && ticTacBoard[2, 1] == "X") || (ticTacBoard[0, 1] == "O" && ticTacBoard[1, 1] == "O" && ticTacBoard[2, 1] == "O"))
            {
                ticTacBoard[0, 1] = "W";
                ticTacBoard[1, 1] = "W";
                ticTacBoard[2, 1] = "W";
                return true;

            }
            else if ((ticTacBoard[0, 2] == "X" && ticTacBoard[1, 2] == "X" && ticTacBoard[2, 2] == "X") || (ticTacBoard[0, 2] == "O" && ticTacBoard[1, 2] == "O" && ticTacBoard[2, 2] == "O"))
            {
                ticTacBoard[0, 2] = "W";
                ticTacBoard[1, 2] = "W";
                ticTacBoard[2, 2] = "W";
                return true;

            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method to check the diagonal rows for a win. lots of if-statements.
        /// </summary>
        bool checkDiagonallWin()
        {
            if ((ticTacBoard[0, 0] == "X" && ticTacBoard[1, 1] == "X" && ticTacBoard[2, 2] == "X") || (ticTacBoard[0, 0] == "O" && ticTacBoard[1, 1] == "O" && ticTacBoard[2, 2] == "O"))
            {
                ticTacBoard[0, 0] = "W";
                ticTacBoard[1, 1] = "W";
                ticTacBoard[2, 2] = "W";
                return true;


            }
            else if ((ticTacBoard[2, 0] == "X" && ticTacBoard[1, 1] == "X" && ticTacBoard[0, 2] == "X") || (ticTacBoard[2, 0] == "O" && ticTacBoard[1, 1] == "O" && ticTacBoard[0, 2] == "O"))
            {
                ticTacBoard[2, 0] = "W";
                ticTacBoard[1, 1] = "W";
                ticTacBoard[0, 2] = "W";
                return true;

            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// starts the game, also acts as the reset button
        /// </summary>
        public void startGame()
        {
            ticTacBoard = new string[3, 3];    //set up the variables for the tic-tac-toe game.
            gameHasStarted = true;
            playerOnesTurn = true;
            turnCount = 0;
            
            
        }

        /// <summary>
        /// method that updates the game board after every turn.
        /// </summary>
        public void updateGameBoard(int row, int column)
        {
            if (playerOnesTurn == true)
            {
                ticTacBoard[row, column] = "X";
            }
            else
            {
                ticTacBoard[row, column] = "O";
            }
             
        }

        

    }
}
