using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestScriptingObstaclesProject
{
    internal class GridTestClass
    {
        [Test]
        public void NotNullTest() 
        {
            Grid<Cell> grid = DungeonSystem.Intance.GenerateDungeon(10,10);

            int count = 0;

            for (int i = 0; i < grid.GetWidth; i++)
            {
                for (int j = 0; j < grid.GetHeight; j++)
                {
                    Assert.IsNotNull(grid.GridArray[i, j]);
                    count++;
                }
            }

            //Check if the grid generates all the cells
            Assert.IsTrue(count == 10*10);
        }

        [Test]
        public void GridHasEnemies()
        {
            Grid<Cell> grid = DungeonSystem.Intance.GenerateDungeon(10, 10);

            for (int i = 0; i < grid.GetWidth; i++)
            {
                for (int j = 0; j < grid.GetHeight; j++)
                {
                    Assert.IsNotNull(grid.GridArray[i, j].OBS1);
                }
            }
        }

        [Test]
        public void FindPathToGoal()
        {
            PathFinding pathFinding1 = new PathFinding(10, 10);
            PathFinding pathFinding2 = new PathFinding(20, 20);
            PathFinding pathFinding3 = new PathFinding(30, 30);

            //all paths starts at x = 0 & y = 0

            //pathFinding1 destination
            int x1 = 9; int y1 = 9;

            //pathFinding2 destination
            int x2 = 15; int y2 = 15;

            //pathFinding3 destination
            int x3 = 29; int y3 = 29;

            List<CellTesting> path1 = pathFinding1.FindPath(0, 0, x1, y1);
            List<CellTesting> path2 = pathFinding2.FindPath(0, 0, x2, y2);
            List<CellTesting> path3 = pathFinding3.FindPath(0, 0, x3, y3);

            Assert.IsTrue(path1[0].x == 0 && path1[0].y == 0);
            Assert.IsTrue(path1[path1.Count-1].x == x1 && path1[path1.Count - 1].y == y1);

            Assert.IsTrue(path2[0].x == 0 && path2[0].y == 0);
            Assert.IsTrue(path2[path2.Count - 1].x == x2 && path2[path2.Count - 1].y == y2);

            Assert.IsTrue(path3[0].x == 0 && path3[0].y == 0);
            Assert.IsTrue(path3[path3.Count - 1].x == x3 && path3[path3.Count - 1].y == y3);
        }
    }
}
