using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            char currentPlayer = 'X';
            int movesLeft = 9;

            while (true)
            {
                Console.Clear();
                PrintBoard(board);
                Console.WriteLine("Player " + currentPlayer + "'s turn. Choose a row and column (e.g. 1,1):");

                string[] input = Console.ReadLine().Split(',');
                int row = int.Parse(input[0]) - 1;
                int col = int.Parse(input[1]) - 1;

                if (board[row, col] == ' ')
                {
                    board[row, col] = currentPlayer;
                    movesLeft--;
                }
                else
                {
                    Console.WriteLine("That spot is already taken. Try again.");
                    Console.ReadLine();
                    continue;
                }

                if (CheckForWin(board, currentPlayer))
                {
                    Console.Clear();
                    PrintBoard(board);
                    Console.WriteLine("Player " + currentPlayer + " wins!");
                    Console.ReadLine();
                    break;
                }

                if (movesLeft == 0)
                {
                    Console.Clear();
                    PrintBoard(board);
                    Console.WriteLine("It's a tie!");
                    Console.ReadLine();
                    break;
                }

                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }
        }

        static void PrintBoard(char[,] board)
        {
            Console.WriteLine("  1 2 3");
            Console.WriteLine(" -------");

            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + 1 + "|");

                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + "|");
                }

                Console.WriteLine();
                Console.WriteLine(" -------");
            }
        }

        static bool CheckForWin(char[,] board, char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                    return true;

                if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
                    return true;
            }

            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
                return true;

            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
                return true;

            return false;
        }
    }
}
