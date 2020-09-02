using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS_3280_Assignment_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        /// <summary>
        /// creating the tictactoe game object.
        /// </summary>
        ticTacToe ticTacGame = new ticTacToe();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// my code that holds what happens if one of the tiles is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Label MyLabel = (Label)sender;
            string coordinateOne = ((Label)sender).Name.ToString().Substring(5,1);  //get the coordinates of what was clicked. All labels in in their coordinates. Confusing as hell line of code but it works to update the array.
            string coordinateTwo = ((Label)sender).Name.ToString().Substring(6, 1);  //get the coordinates of what was clicked. All labels in in their coordinates. Confusing as hell line of code but it works to update the array.
            int coordinate1;
            Int32.TryParse(coordinateOne, out coordinate1);
            int coordinate2;
            Int32.TryParse(coordinateTwo, out coordinate2);
            
            

            if (ticTacToe.gameHasStarted == true)
            {
               if (ticTacToe.playerOnesTurn == true)     //if it is player one's turn
                {
                    if (MyLabel.Content.ToString() == "E")
                    {
                        MyLabel.Content = "X";
                        ticTacGame.updateGameBoard(coordinate1, coordinate2);
                        if (ticTacGame.checkIfWon() == true)
                        {
                            gameStatusLabel.Content = "Player 1 Wins!";
                            playerOneWinsLabel.Content = ticTacGame.playerOneWins;
                            showWinningMove();
                            ticTacToe.gameHasStarted = false;
                        }

                        ticTacToe.turnCount++;                    //increment the turn count
                        if (ticTacToe.turnCount == 9)
                        {
                            ticTacToe.gameHasStarted = false;            //shut down the game
                            gameStatusLabel.Content = "Game Tied";       //update the label.
                            ticTacGame.ties++;
                            tiesLabel.Content = ticTacGame.ties;

                        }
                    }

                    

                    

                }
                else
                {
                    if (MyLabel.Content.ToString() == "E")
                    {
                        MyLabel.Content = "O";
                        ticTacGame.updateGameBoard(coordinate1, coordinate2);
                        if (ticTacGame.checkIfWon() == true)
                        {
                            gameStatusLabel.Content = "Player 2 Wins!";
                            playerTwoWinsLabel.Content = ticTacGame.playerTwoWins;
                            showWinningMove();
                            ticTacToe.gameHasStarted = false;
                        }

                        ticTacToe.turnCount++;                    //increment the turn count
                        if (ticTacToe.turnCount == 9)
                        {
                            ticTacToe.gameHasStarted = false;            //shut down the game
                            gameStatusLabel.Content = "Game Tied";       //update the label.
                            ticTacGame.ties++;
                            tiesLabel.Content = ticTacGame.ties;
                        }
                    }
                }
               
            }

            if (ticTacToe.playerOnesTurn == true && ticTacToe.gameHasStarted == true)
            {
                gameStatusLabel.Content = "Player 1's Turn";
            }
            
            if (ticTacToe.playerOnesTurn == false && ticTacToe.gameHasStarted == true)
            {
                gameStatusLabel.Content = "Player 2's Turn";
            }


        }

        /// <summary>
        /// code for the start game button. Initiates/resets the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startGameButton_Click(object sender, RoutedEventArgs e)
        {
            label00.Background = Brushes.Silver;
            label00.Content = "E";

            label01.Background = Brushes.Silver;
            label01.Content = "E";

            label02.Background = Brushes.Silver;
            label02.Content = "E";

            label10.Background = Brushes.Silver;
            label10.Content = "E";
            
            label11.Background = Brushes.Silver;           //reset the UI
            label11.Content = "E";
            
            label12.Background = Brushes.Silver;
            label12.Content = "E";

            label20.Background = Brushes.Silver;
            label20.Content = "E";
            
            label21.Background = Brushes.Silver;
            label21.Content = "E";

            label22.Background = Brushes.Silver;
            label22.Content = "E";

            gameStatusLabel.Content = "Player 1's Turn";
           
            ticTacGame.startGame();                       //reset the tictactoe game
        }

        /// <summary>
        /// update the game status label.
        /// </summary>
        void updateLabels()
        {
            if (ticTacToe.playerOnesTurn == true)
            {
                gameStatusLabel.Content = "Player 1's Turn";
            }
            else
            {
                gameStatusLabel.Content = "Player 2's Turn";
            }
        }

        /// <summary>
        /// highlights the winning move combination. created this static method of the UI to update the background color of the winning move. Logic is handled by the ticTac class.
        /// </summary>
        public void showWinningMove()
        {
            if (ticTacGame.ticTacBoard[0,0] == "W")
            {
                label00.Background = Brushes.Gold;
            }
            if (ticTacGame.ticTacBoard[0, 1] == "W")
            {
                label01.Background = Brushes.Gold;
            }
            if (ticTacGame.ticTacBoard[0, 2] == "W")
            {
                label02.Background = Brushes.Gold;
            }
            if (ticTacGame.ticTacBoard[1, 0] == "W")
            {
                label10.Background = Brushes.Gold;

            }
            if (ticTacGame.ticTacBoard[1, 1] == "W")                      //if statements that check if the label/element in the game array is part of the winning move.
            {
                label11.Background = Brushes.Gold;
            }
            if (ticTacGame.ticTacBoard[1, 2] == "W")
            {
                label12.Background = Brushes.Gold;
            }
            if (ticTacGame.ticTacBoard[2, 0] == "W")
            {
                label20.Background = Brushes.Gold;
            }
            if (ticTacGame.ticTacBoard[2, 1] == "W")
            {
                label21.Background = Brushes.Gold;
            }
            if (ticTacGame.ticTacBoard[2, 2] == "W")
            {
                label22.Background = Brushes.Gold;
            }
        }

    }
}
