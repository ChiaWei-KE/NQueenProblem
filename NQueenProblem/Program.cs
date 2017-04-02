using System;
using System.Diagnostics;

namespace NQueenProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 15; i++)
                QueenProblem(i);
        }
 
        static void QueenProblem(int n){
            var solutionCount = new long[1];
            var stopWatch = new Stopwatch();
 
            stopWatch.Start();
            QueenProblem(0, new int[n], solutionCount);
            stopWatch.Stop();
 
            Console.WriteLine($"Number of solution for {n} x {n} is {solutionCount[0]}. Used time = {stopWatch.Elapsed.TotalSeconds: 0.00} seconds.");
        }
 
        static void QueenProblem(int currentRow, int[] solution, long[] solutionCount)
        {
            var dimension = solution.Length;
 
            if (currentRow == dimension) {
                solutionCount[0]++;
                //Console.WriteLine(string.Join(", ", solution));
                return;
            }
 
            bool verticalTest, diagonalTest;
            int step, row, diff, value1, value2;
 
            for (int position = 0; position < dimension; position++) {
                verticalTest = true;
                diagonalTest = true;
 
                //Check vertical
                for (step = 0; step <= currentRow - 1; step++)
                    if (solution[step] == position) {
                        verticalTest = false;
                        break;
                    }
                if (!verticalTest) continue;
 
                //Check diagonal
                row = currentRow - 1;
                diff = currentRow - row;
                while (row >= 0) {
                    value1 = position - diff;
                    value2 = position + diff;
                    step = currentRow - diff;
 
                    if (solution[step] == value1 || solution[step] == value2) {
                        diagonalTest = false;
                        break;
                    }
                    diff++;
                    row--;
                }
 
                //If both tests passed, go to next level
                if(verticalTest && diagonalTest) {
                    solution[currentRow] = position;
                    QueenProblem(currentRow + 1, solution, solutionCount);
                }
            
            }
        }
    }
}