using System;
using System.Linq;

namespace Sudoku_Solver
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // A = 1, B = 2...
            /*int[] Data = new int[]
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
            };*/

            int[] PureSet = calculatePureSet(3);
            PrintSudoku(PureSet);

            int[] Data = new int[]
            {
                0,1,4,0,
                0,3,0,0,
                0,0,0,2,
                0,0,3,0,
            };

            //int[] Valuation = Check(Data, PureSet);

            //Data = FlipDiagonal2(Data);
            
            /*
            Data = SwapBands(Data, 0, 1);
            Data = SwapStacks(Data, 0, 1);
            Data = SwapRows(Data, 2, 3);
            
            if(IdenticalArrays(Data,PureSet))
            {
                Console.WriteLine("Solution! Hurraa!");
                Data = PureSet;
            }

            Data = SwapRows(Data, 2, 3);
            Data = SwapStacks(Data, 0, 1);
            Data = SwapBands(Data, 0, 1);
            */


            //PrintSudoku(Data);
            //CountNumber(Data);
        }

        static int[] calculatePureSet(int size)
        {
            int[] data = new int[(int)Math.Pow(size,4)];
            int[] row = new int[(int)Math.Pow(size, 2)];

            for(int i = 0; i < (int)Math.Pow(size,2); i++)
            {
                row[i] = i + 1;
            }

            for(int y = 0; y < Math.Pow(size,2); y++)
            {
                for(int i = 0; i < row.Length; i++)
                {
                    data[y * row.Length + i] = row[i];
                }

                RotateArray(row, size);

                if(y % 3 == 0 && y > 0)
                {

                }
            }

            return data;
        }

        static int[] RotateArray(int[] data, int n)
        {
            if (n % data.Length == 0)
            {
                return data;
            }
            n = n % data.Length;
            if (n < 0)
            {
                n = data.Length - Math.Abs(n);
            }

            int[] holder = new int[Math.Abs(n)];
            for(int i = 0; i < holder.Length; i++)
            {
                holder[i] = data[i];
            }
            for(int i = 0; i < data.Length - holder.Length; i++)
            {
                data[i] = data[(i + data.Length + n) % data.Length];
            }
            for(int i = 0; i < holder.Length; i++)
            {
                data[i + data.Length - holder.Length] = holder[i];
            }

            return data;
        }

        static int[] RotateClockWise(int[] D)
        {
            int size = (int)Math.Sqrt(Math.Sqrt(D.Length));
            int[] Copy = new int[D.Length];
            Array.Copy(D, Copy, D.Length);
            for (int i = 0; i < Math.Pow(size, 2); i++)
            {
                for (int k = 0; k < Math.Pow(size, 2); k++)
                {
                    D[i * (int)Math.Pow(size, 2) + k] = Copy[((int)Math.Pow(size, 2) - 1 - k) * (int)Math.Pow(size, 2) + i];
                }
            }
            return D;
        }

        static int[] RotateCounterClockWise(int[] D)
        {
            int size = (int)Math.Sqrt(Math.Sqrt(D.Length));
            int[] Copy = new int[D.Length];
            Array.Copy(D, Copy, D.Length);
            for(int i = 0; i < Math.Pow(size,2); i++)
            {
                for(int k = 0; k < Math.Pow(size, 2); k++)
                {
                    D[i * (int)Math.Pow(size, 2) + k] = Copy[(k + 1) * (int)Math.Pow(size, 2) - i - 1];
                }
            }
            return D;
        }

        static int[] FlipHorizontal(int[] D)
        {
            int size = (int)Math.Sqrt(Math.Sqrt(D.Length));
            for (int i = 0; i < Math.Pow(size,2); i++)
            {
                for(int k = 0; k < Math.Floor(Math.Pow(size, 2) / 2); k++)
                {
                    int holder = D[i * (int)Math.Pow(size,2) + k];
                    D[i * (int)Math.Pow(size, 2) + k] = D[i * (int)Math.Pow(size, 2) + (int)Math.Pow(size, 2) - 1 - k];
                    D[i * (int)Math.Pow(size, 2) + (int)Math.Pow(size, 2) - 1 - k] = holder;
                }
            }
            return D;
        }

        static int[] FlipVertical(int[] D)
        {
            int size = (int)Math.Sqrt(Math.Sqrt(D.Length));
            for (int h = 0; h < Math.Pow(size,2); h++)
            {
                for(int v = 0; v < Math.Floor(Math.Pow(size, 2) / 2); v++)
                {
                    int holder = D[v * (int)Math.Pow(size, 2) + h];
                    D[v * (int)Math.Pow(size, 2) + h] = D[((int)Math.Pow(size, 2) - 1 - v) * (int)Math.Pow(size, 2) + h];
                    D[((int)Math.Pow(size, 2) - 1 - v) * (int)Math.Pow(size, 2) + h] = holder;
                }
            }
            return D;
        }

        static int[] FlipDiagonal(int[] D) //From NW to SE
        {
            int size = (int)Math.Sqrt(Math.Sqrt(D.Length));
            int[] Copy = new int[D.Length];
            for (int r = 0; r < Math.Pow(size,2); r++)
            {
                for (int c = 0; c < Math.Pow(size, 2); c++)
                {
                    Copy[r * (int)Math.Pow(size, 2) + c] = D[c * (int)Math.Pow(size, 2) + r];
                }
            }
            return Copy;
        }

        static int[] FlipDiagonal2(int[] D) //From SW, NE
        {
            int size = (int)Math.Sqrt(Math.Sqrt(D.Length));
            int[] Copy = new int[D.Length];
            for (int r = 0; r < Math.Pow(size, 2); r++)
            {
                for (int c = 0; c < Math.Pow(size, 2); c++)
                {
                    Copy[r * (int)Math.Pow(size, 2) + c] = D[((int)Math.Pow(size,2) - 1 - c) * (int)Math.Pow(size,2) + (int)Math.Pow(size,2) - 1 - r];
                }
            }
            return Copy;
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
            int size = (int)Math.Sqrt(Math.Sqrt(D.Length));
            for (int i = 0; i < Math.Pow(size,2); i++)
            {
                int holder = D[r1 * (int)Math.Pow(size,2) + i];
                D[r1 * (int)Math.Pow(size, 2) + i] = D[r2 * (int)Math.Pow(size, 2) + i];
                D[r2 * (int)Math.Pow(size, 2) + i] = holder;
            }
            return D;
        }

        static int[] SwapBands(int[] D, int s1, int s2)
        {
            int size = (int)Math.Sqrt(Math.Sqrt(D.Length));
            for (int i = 0; i < size; i++)
            {
                D = SwapRows(D, s1 * size + i, s2 * size + i);
            }
            return D;
        }

        static int[] SwapColumns(int[] D, int c1, int c2)
        {
            int size = (int)Math.Sqrt(Math.Sqrt(D.Length));
            for (int i = 0; i < Math.Pow(size,2); i++)
            {
                int holder = D[i * (int)Math.Pow(size, 2) + c1];
                D[i * (int)Math.Pow(size, 2) + c1] = D[i * (int)Math.Pow(size, 2) + c2];
                D[i * (int)Math.Pow(size, 2) + c2] = holder;
            }
            return D;
        }

        static int[] SwapStacks(int[] D, int s1, int s2)
        {
            int size = (int)Math.Sqrt(Math.Sqrt(D.Length));
            for(int i = 0; i < size; i++)
            {
                D = SwapColumns(D, s1 * size + i, s2 * size + i);
            }
            return D;
        }

        static void PrintSudoku(int[] D)
        {
            int size = (int)Math.Sqrt(Math.Sqrt(D.Length));
            Console.WriteLine("Printing the sudoku board:");
            for(int i = 0; i < D.Length; i++)
            {
                if (i % size == 0 && i % Math.Pow(size, 2) != 0)
                {
                    Console.Write("|");
                }
                Console.Write(D[i] + ",");
                if((i + 1) % Math.Pow(size,2) == 0)
                {
                    Console.Write("\n");
                    if ((i + 1) % Math.Pow(size,3) == 0)
                    {
                        for ( int k = 0; k < size; k++)
                        {
                            Console.Write("-------");
                        }
                        
                        Console.Write("\n");
                    }
                }
            }
        }

        static void printArray(int[] data)
        {
            string s = "";
            for(int i = 0; i < data.Length; i++)
            {
                s += data[i];
                if (i != data.Length - 1)
                {
                    s += ", ";
                }
            }
            Console.WriteLine("Printing array: ");
            Console.WriteLine(s);
        }

        static void CountNumber(int[] D)
        {
            int[] n = new int[9];
            for (int i = 0; i < D.Length; i++)
            {
                if (D[i] != 0)
                {
                    n[D[i] - 1] += 1;
                }
            }
            for (int i = 0; i < n.Length; i++)
            {
                Console.WriteLine(i + 1 + ": " + n[i]);
            }
        }

        static bool IdenticalArrays(int[] a1, int[] a2)
        {
            if(a1.Length != a2.Length)
            {
                return false;
            }

            for(int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != 0 && a2[i] != 0)
                {
                    if (a1[i] != a2[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
