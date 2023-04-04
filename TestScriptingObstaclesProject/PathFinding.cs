using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptingObstaclesProject
{
    public class PathFinding
    {
        private Grid<CellTesting> grid;
        private List<CellTesting> openList;
        private List<CellTesting> closeList;
        public PathFinding(int width, int height)
        {
            grid = new Grid<CellTesting>(width, height,(Grid<CellTesting> g, int x, int y) => new CellTesting(g, x, y));
        }

        public List<CellTesting> FindPath(int startX, int startY, int endX, int endY)
        {
            CellTesting startCell = grid.GetValue(startX, startY);
            CellTesting endCell = grid.GetValue(endX, endY);

            Player P = new Player(5,3);

            openList = new List<CellTesting> { startCell };
            closeList = new List<CellTesting>();

            while (openList.Count > 0)
            {
                CellTesting currentCell = GetHighestPowerCell(openList);
                if (currentCell == endCell)
                {
                    return CalculatePath(endCell);
                }

                openList.Remove(currentCell);
                P.Combat(currentCell.OBS);
                closeList.Add(currentCell);

                foreach (CellTesting cell in GetNeighboursList(currentCell))
                {
                    if (closeList.Contains(cell)) continue;

                    if (P.poderActual > cell.OBS.Power)
                    {
                        cell.lastNode = currentCell;

                        if (!openList.Contains(cell))
                        {
                            openList.Add(cell);
                        }
                    }

                }
            }

            return null;
        }

        private List<CellTesting> GetNeighboursList(CellTesting currentCell)
        {
            List<CellTesting> neighbourtsList = new List<CellTesting>();

            //Left
            if (currentCell.x - 1 >= 0)
            {
                neighbourtsList.Add(grid.GetValue(currentCell.x - 1, currentCell.y));
            }
            //Right
            if (currentCell.x + 1 < grid.GetWidth)
            {
                neighbourtsList.Add(grid.GetValue(currentCell.x + 1, currentCell.y));
            }
            //Up
            if (currentCell.y + 1 < grid.GetHeight)
            {
                neighbourtsList.Add(grid.GetValue(currentCell.x, currentCell.y + 1));
            }
            //Down
            if (currentCell.y - 1 >= 0)
            {
                neighbourtsList.Add(grid.GetValue(currentCell.x, currentCell.y - 1));
            }

            return neighbourtsList;
        }

        private List<CellTesting> CalculatePath(CellTesting endCell)
        {
            List<CellTesting> path = new List<CellTesting>();

            path.Add(endCell);
            CellTesting currentCell = endCell;

            while (currentCell.lastNode != null)
            {
                path.Add(currentCell.lastNode);
                currentCell = currentCell.lastNode;
            }
            path.Reverse();
            return path;
        }
        private CellTesting GetHighestPowerCell(List<CellTesting> cellList)
        {
            CellTesting high = cellList[0];
            for (int i = 0; i < cellList.Count; i++)
            {
                if (cellList[i].OBS.Power > high.OBS.Power)
                {
                    high = cellList[i];
                }
            }

            return high;
        }
    }
}
