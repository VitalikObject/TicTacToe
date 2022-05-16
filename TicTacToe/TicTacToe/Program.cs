using System;
using System.Linq;

namespace TicTacToe
{
    public class Program
    {
        private static char[][] lines = new char[3][];
        private static bool isGameOver = false;
        private const string ALLOWED_CHARS = "XO";
        private const int LINE_LENGHT = 3;

        public static void Main()
        {
            Init();
            while(!isGameOver)
            {
                ExecuteCommand(Console.ReadLine().Split(' '));
                Draw();

                for (int i = 0; i < ALLOWED_CHARS.Length; i++)
                    CalculateWinner(ALLOWED_CHARS.ToArray()[i]);
            }
        }

        private static void Init()
        {
            for (int i = 0; i < lines.Length; i++)
                lines[i] = new char[3] { '-', '-', '-' };

            Draw();
        }

        private static void Draw()
        {
            Console.Clear();

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                    Console.Write(lines[i][j] + " ");

                Console.WriteLine("\n");
            }
        }

        private static void ExecuteCommand(string[] turn)
        {
            if (turn.Length == 3 && turn[0].All(char.IsDigit) && turn[1].All(char.IsDigit))
            {
                int line = Convert.ToInt32(turn[0]);
                int position = Convert.ToInt32(turn[1]);
                line--;
                position--;

                if (line <= 3 && line >= 0 && position <= 3 && position >= 0)
                {
                    if (ALLOWED_CHARS.Contains(turn[2].ToUpper()))
                    {
                        if (lines[line][position] == '-')
                        {
                            lines[line][position] = Convert.ToChar(turn[2].ToUpper());
                        }

                        return;
                    }
                }
            }

            Console.WriteLine("Error occured! Press any key to continue...");
            Console.ReadLine();
        }

        private static void CalculateWinner(char symbol)
        {
            bool isWinner = false;
            int position = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] != symbol) break;

                    if (j == (lines[i].Length-1)) isWinner = true;
                }
            }

            for (int i = 0; i < LINE_LENGHT; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    if (lines[j][i] != symbol) break;

                    if (j == (lines[i].Length - 1)) isWinner = true;
                }
            }

            for (int i = 0; i < lines.Length; i++)
            {

                if (lines[i][position] != symbol) break;
                if (position == (lines[i].Length - 1)) isWinner = true;
                position++;
            }

            position = 0;
            for (int i = (lines.Length - 1); i > 0; i--)
            {

                if (lines[i][position] != symbol) break;
                if (i == 1) isWinner = true;
                position++;
            }

            if (isWinner)
            {
                Console.WriteLine($"Player: {symbol} won!");
                Console.ReadLine();
            }
        }
    }
}
