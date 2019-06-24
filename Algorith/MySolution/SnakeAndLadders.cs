
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorith.MySolution
{
   public class SnakeAndLadders
    {
        public static void Run()
        {
            int size = 36;
            int[] board = new int[size];
            for (int i = 0; i < size; i++)
            {
                board[i] = -1;
            }
            //ladders
            board[2] = 15;
            board[14] = 24;
            board[20] = 31;

            // Snakes
            board[11] = 1;
            board[29] = 3;
            board[34] = 21;

            var s = new SnakeAndLadders();
            Console.WriteLine("Minimum Dice throws needed to reach to end: " + s.FindMinMoves(board));
        }

        public class Vertex
        {
           public int cell;
            public int moves;
        }

        public int FindMinMoves(int[] board)
        {
            int size = board.Length;

            bool[] visited = new bool[size];

            var queue = new Queue<Vertex>();

            Vertex vertex = new Vertex();
            vertex.cell = 0;
            vertex.moves = 0;

            queue.Enqueue(vertex);
            visited[0] = true;

            while(queue.Count>0)
            {
                vertex = queue.Dequeue();
                int cellNum = vertex.cell;

                if (cellNum == size - 1) break;

                for (int i = cellNum+1  ; i < (cellNum+6) && i<size; i++)
                {

                    if (visited[i]!=true)
                    {
                        var currentVertex = new Vertex();
                        currentVertex.moves = vertex.moves + 1;
                        visited[i] = true;

                        if (board[i]==-1)
                        {
                            currentVertex.cell = i;


                        }
                        else
                        {
                            currentVertex.cell = board[i];
                            }

                        queue.Enqueue(currentVertex);
                    }
                }
            }


            return vertex.moves;
        }
    }
}
