using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimestions[0];
            int columns = dimestions[1];

            int[,] matrix = FillMatrix(rows , columns);

            string command;
            long sum = 0;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoCoordinates = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilCoordinates = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int evilRow = evilCoordinates[0];
                int evilCol = evilCoordinates[1];
                DestroySells(matrix, ref evilRow, ref evilCol);

                int ivoRow = ivoCoordinates[0];
                int ivoCol = ivoCoordinates[1];
                sum += CollectValues(matrix, ref ivoRow, ref ivoCol);
            }

            Console.WriteLine(sum);

        }

        private static long CollectValues(int[,] matrix, ref int ivoRow, ref int ivoCol)
        {
            long sum = 0;
            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (ivoRow >= 0 && ivoRow < matrix.GetLength(0) && ivoCol >= 0 && ivoCol < matrix.GetLength(1))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }

            return sum;
        }

        private static void DestroySells(int[,] matrix, ref int evilRow, ref int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow >= 0 && evilRow < matrix.GetLength(0) && evilCol >= 0 && evilCol < matrix.GetLength(1))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        private static int[,] FillMatrix(int rows , int columns)
        {
            int[,] matrix = new int[rows,columns];
            int value = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = value++;
                }
            }
            return matrix;
        }
    }
}
