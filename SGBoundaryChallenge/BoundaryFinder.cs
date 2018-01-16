using System.Collections.Generic;

namespace SGBoundaryChallenge
{
    public class BoundaryFinder
    {
        public Boundaries FindBoundaries(bool[,] blob, int size)
        {
            Grid matrix = new Grid(blob, size);

            Queue<GridCell> q = new Queue<GridCell>();
            GridCell first = FindOne(matrix);

            if(first == null)
            {
                return new Boundaries
                {
                    Top = -1,
                    Bottom = -1,
                    Left = -1,
                    Right = -1,
                    CellReads = matrix.GetAccessCount()
                };
            }

            q.Enqueue(first);

            Boundaries boundaries = new Boundaries
            {
                Top= first.I,
                Bottom = first.I,
                Left = first.J,
                Right = first.J
            };

            // While Queue is not empty, go through cells
            while (q.Count > 0)
            {
                GridCell current = q.Dequeue();

                if (current.I < boundaries.Top) boundaries.Top = current.I;
                if (current.I > boundaries.Bottom) boundaries.Bottom = current.I;

                if (current.J<boundaries.Left) boundaries.Left = current.J;
                if (current.J > boundaries.Right) boundaries.Right = current.J;

                List<GridCell> toVisit = GetSurroundingCells(matrix, current);

                foreach(GridCell cell in toVisit)
                {
                    if (!matrix.HasBeenVisited(cell.I, cell.J) && matrix.Visit(cell.I, cell.J))
                    {
                        q.Enqueue(cell);
                    }
                }
            }

            boundaries.CellReads = matrix.GetAccessCount();
            return boundaries;
        }

        private List<GridCell> GetSurroundingCells(Grid grid, GridCell current)
        {
            List<GridCell> toVisit = new List<GridCell>();

            // Left Cell
            if (current.J > 0)
            {
                toVisit.Add(new GridCell(current.I, current.J - 1));
            }

            // Right Cell
            if (current.J < grid.Size - 1)
            {
                toVisit.Add(new GridCell(current.I, current.J + 1));
            }

            // Top Cell
            if (current.I > 0)
            {
                toVisit.Add(new GridCell(current.I - 1, current.J));
            }

            // Bottom Cell
            if (current.I < grid.Size - 1)
            {
                toVisit.Add(new GridCell(current.I + 1, current.J));
            }

            return toVisit;
        }


        private GridCell FindOne(Grid grid)
        {
            Queue<GridCell> q = new Queue<GridCell>();


            int mid = grid.Size / 2;
            GridCell first = new GridCell(mid, mid);

            if (!grid.HasBeenVisited(first.I, first.J))
            {
                if (grid.Visit(first.I, first.J))
                {
                    return first;
                }
                q.Enqueue(first);
            }

            while (q.Count > 0)
            {
                GridCell current = q.Dequeue();
                List<GridCell> toVisit = GetSurroundingCells(grid, current);

                foreach (GridCell cell in toVisit)
                {
                    if (!grid.HasBeenVisited(cell.I, cell.J))
                    {
                        if (grid.Visit(cell.I, cell.J))
                        {
                            return cell;
                        }
                        q.Enqueue(cell);
                    }
                }
            }

            return null;
        }

    }
}
