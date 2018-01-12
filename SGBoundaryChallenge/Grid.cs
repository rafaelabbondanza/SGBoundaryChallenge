using System;
using System.Collections.Generic;
using System.Text;

namespace SGBoundaryChallenge
{
    public class Grid
    {
        private bool[,] Mtx;
        public int Size;

        private HashSet<int> Visited;

        public Grid(bool[,] mtx, int size)
        {
            Mtx = mtx;
            Size = size;
            Visited = new HashSet<int>();
        }

        public bool Visit(int i, int j)
        {
            Visited.Add(VisitedKey(i, j));
            return Mtx[i, j];
        }

        public int GetAccessCount()
        {
            return Visited.Count;
        }

        public bool HasBeenVisited(int i, int j)
        {
            return Visited.Contains(VisitedKey(i, j));
        }

        private int VisitedKey(int i, int j)
        {
            return i * Size + j;
        }

    }
}
