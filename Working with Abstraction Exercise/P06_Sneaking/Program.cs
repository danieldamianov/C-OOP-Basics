using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;

        static void Main()
        {
            FillMatrix();

            var moves = Console.ReadLine().ToCharArray();

            int[] samPosition = GetSamPos();

            for (int movesCounter = 0; movesCounter < moves.Length; movesCounter++)
            {
                MoveGuards();

                int[] getEnemy = GetPosExceptForSams(samPosition);

                CheckForSamDeath(samPosition, getEnemy);

                MoveSam(moves[movesCounter], samPosition);

                int[] probableNikoladzePos = GetPosExceptForSams(samPosition);

                CheckForNikoladzeDeath(samPosition, probableNikoladzePos);
            }
        }

        private static void CheckForNikoladzeDeath(int[] samPosition, int[] probableNikoladzePos)
        {
            if (room[probableNikoladzePos[0]][probableNikoladzePos[1]] == 'N' && samPosition[0] == probableNikoladzePos[0])
            {
                room[probableNikoladzePos[0]][probableNikoladzePos[1]] = 'X';
                Console.WriteLine("Nikoladze killed!");
                PrintMatrixAndTermianteProcess();
            }
        }

        private static void MoveSam(char move, int[] samPosition)
        {
            room[samPosition[0]][samPosition[1]] = '.';
            switch (move)
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
            room[samPosition[0]][samPosition[1]] = 'S';
        }

        private static void CheckForSamDeath(int[] samPosition, int[] getEnemy)
        {
            if (samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
            {
                room[samPosition[0]][samPosition[1]] = 'X';
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                PrintMatrixAndTermianteProcess();
            }
            else if (getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
            {
                room[samPosition[0]][samPosition[1]] = 'X';
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                PrintMatrixAndTermianteProcess();
            }
        }

        private static void PrintMatrixAndTermianteProcess()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static int[] GetPosExceptForSams(int[] samPosition)
        {
            int[] getEnemy = new int[2];
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
            return getEnemy;
        }

        private static int[] GetSamPos()
        {
            int[] samPos = new int[2];
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPos[0] = row;
                        samPos[1] = col;
                    }
                }
            }
            return samPos;
        }

        private static void FillMatrix()
        {
            int n = int.Parse(Console.ReadLine());
            room = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }

        private static void MoveGuards()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }


    }
}
