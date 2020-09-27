//hw: set up players replaying the game

using System;
using System.Threading;

namespace Tic_Tac_Toe
{
    class Program
    {
        static char[] arr =  {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        static int player = 1;
        static int counter = 0;
        static int choice;
        static int flag;

        static void Main(string[] args)
        {
            do {
                Console.Clear();
                Console.WriteLine("Player1: X and Player2: O");
                Console.WriteLine('\n');

                if (player % 2 == 0) {
                    Console.WriteLine("Player 2 Turn");
                }
                else {
                    Console.WriteLine("Player 1 Turn");
                }

                Console.WriteLine("\n");
                Board();

                int choice = int.Parse(Console.ReadLine());
                if (arr[choice] != 'X' && arr[choice] != 'O') {
                    if (player % 2 == 0) {
                        arr[choice] = 'O';
                        player--;
                    } else {
                        arr[choice] = 'X';
                        player++;
                    }
                    
                } else {
                    Console.WriteLine("Sorry the square {0} is already filled with {}!", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Letting the board chill...");
                    Thread.Sleep(2000);
                }
                counter++;
                flag = checkWin();
            }  while (flag == 0);

            Console.Clear();
            Board();

            if (flag == 1) {
                Console.WriteLine("Player {0} has won", (player == 2) ? 1:2);
            } else {
                Console.WriteLine("Draw");
            }

            Console.ReadLine();
        }
        
        private static void runGame() {
            //put game code in hear for easy loopability
        }

        private static int checkWin() {
            //horizontal
            for (int i=1;i<10; i+=3) {
                if (arr[i] == arr[i+1] && arr[i+1] == arr[i+2]) {
                    return 1;
                }
            }
            //vertical
            for (int i=1;i<4; ++i) {
                if (arr[i]==arr[i+3] && arr[i+3] == arr[i+6]) {
                    return 1;
                }
            }
            //diagonal
            if (arr[1] == arr[5] && arr[5]==arr[9]) {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7]) {
                return 1;

            }
            //checkDraw
            if (counter == 9) {
                return 2;
            }

            return 0;
        }

        private static void ResetBoard() {
            arr[1] = '1';
            arr[2] = '2';
            arr[3] = '3';
            arr[4] = '4';
            arr[5] = '5';
            arr[6] = '6';
            arr[7] = '7';
            arr[8] = '8';
            arr[9] = '9';
        }

        private static void Board() {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }
    }
}
