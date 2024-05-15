using System;

namespace Sudoku_Solver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] Data = new int[]
            {
                5,3,0,0,7,0,0,0,0,
                6,0,0,1,9,5,0,0,0,
                0,9,8,0,0,0,0,6,0,
                8,0,0,0,6,0,0,0,3,
                4,0,0,8,0,3,0,0,1,
                7,0,0,0,2,0,0,0,6,
                0,6,0,0,0,0,2,8,0,
                0,0,0,4,1,9,0,0,5,
                0,0,0,0,8,0,0,7,9,
            };
            //Data = SwapNumbers(Data, 1, 2);
            Data = RotateClockWise(Data);
            PrintSudoku(Data);
        }

        static int[] RotateClockWise(int[] D)
        {
            int[] Copy = new int[D.Length];
            Array.Copy(D, Copy, D.Length);
            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < 9; k++)
                {
                    D[i * 9 + k] = Copy[(8 - k) * 9 + i];
                }
            }
            return D;
        }

        static int[] RotateCounterClockWise(int[] D)
        {
            int[] Copy = new int[D.Length];
            Array.Copy(D, Copy, D.Length);
            for(int i = 0; i < 9; i++)
            {
                for(int k = 0; k < 9; k++)
                {
                    D[i * 9 + k] = Copy[(k + 1) * 9 - i - 1];
                }
            }
            return D;
        }

        static int[] FlipHorizontal(int[] D)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int k = 0; k < 4; k++)
                {
                    int holder = D[i * 9 + k];
                    D[i * 9 + k] = D[i * 9 + 8 - k];
                    D[i * 9 + 8 - k] = holder;
                }
            }
            return D;
        }

        static int[] FlipVertical(int[] D)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int k = 0; k < 4; k++)
                {
                    int holder = D[k * 9 + i];
                    D[k * 9 + i] = D[(8 - k) * 9 + i];
                    D[(8 - k) * 9 + i] = holder;
                }
            }
            return D;
        }

        static int[] SwapNumbers(int[] D, int n, int n2)
        {
            for(int i = 0; i < D.Length; i++)
            {
                if (D[i] == n)
                {
                    D[i] = n2;
                }
                else if (D[i] == n2)
                {
                    D[i] = n;
                }
            }
            return D;
        }

        static int[] SwapRows(int[] D, int r1, int r2)
        {
            for(int i = 0; i < 9; i++)
            {
                int holder = D[r1 * 9 + i];
                D[r1 * 9 + i] = D[r2 * 9 + i];
                D[r2 * 9 + i] = holder;
            }
            return D;
        }

        static int[] SwapColumns(int[] D, int c1, int c2)
        {
            for (int i = 0; i < 9; i++)
            {
                int holder = D[i * 9 + c1];
                D[i * 9 + c1] = D[i * 9 + c2];
                D[i * 9 + c2] = holder;
            }
            return D;
        }

        static void PrintSudoku(int[] D)
        {
            Console.WriteLine("Printing the sudoku board:");
            for(int i = 0; i < D.Length; i++)
            {
                Console.Write(D[i]);
                if((i + 1) % 9 == 0)
                {
                    Console.Write("\n");
                }
            }
        }
    }
}
