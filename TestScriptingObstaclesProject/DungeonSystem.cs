using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptingObstaclesProject
{
    internal class DungeonSystem
    {
        public static DungeonSystem Intance = new DungeonSystem();

        Grid<Cell> grid;

        public Grid<Cell> GenerateDungeon(int width, int height)
        {
            grid = new Grid<Cell>(width, height, (Grid<Cell> g, int x, int y) => new Cell(g, x, y));
            return grid;
        }

        public Cell GetStartCell() 
        {
            return grid.GetValue(0, 0);
        }
    }

    public class Grid<TGridObject>
    {
        private int width;
        private int height;
        private TGridObject[,] gridArray;

        public int GetWidth { get => width; }
        public int GetHeight { get => height; }
        public TGridObject[,] GridArray { get => gridArray;}

        public Grid(int width, int height, Func<Grid<TGridObject>, int, int, TGridObject> CreateGridObject)
        {
            this.width = width;
            this.height = height;

            gridArray = new TGridObject[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {

                    gridArray[x, y] = CreateGridObject(this, x, y);
                }
            }
        }

        public TGridObject GetValue(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                return gridArray[x, y];
            }
            else
            {
                return default(TGridObject);
            }
        }
    }
}
