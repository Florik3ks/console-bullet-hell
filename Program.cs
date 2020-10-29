using System;
using System.Threading;

namespace console_bullet_hell
{
    class Program
    {
        private static bool running;
        private static int gridHeight = 30;
        private static int gridWidth = 121;
        private static int speed = 1;
        private static Cell[,] grid = new Cell[gridHeight, gridWidth];
        static void Main(string[] args)
        {
            Start();
        }
        static void Start()
        {
            Player.setPosition(gridWidth / 2, gridHeight / 2);
            Console.CursorVisible = false;
            Console.SetWindowSize(gridWidth + 1, gridHeight + 3);
            running = true;
            createGrid();
            Game();
        }
        static void Game()
        {
            while (running)
            {
                input();
                updatePlayer();
                updateScreen();
                Thread.Sleep(speed * 1);
            }
        }
        static void input()
        {
            ConsoleKeyInfo input;
            if (!Console.KeyAvailable)
            {
                return;
            }
            input = Console.ReadKey();
            if (input.Key == ConsoleKey.LeftArrow)
            {
                if (Player.getX() > 4)
                {
                    Player.Move(-2, 0);
                }
            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                if (Player.getX() < gridWidth - 5)
                {
                    Player.Move(+2, 0);
                }
            }
            else if (input.Key == ConsoleKey.UpArrow)
            {
                if (Player.getY() > 2)
                {
                    Player.Move(0, -1);
                }
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                if (Player.getY() < gridHeight - 3)
                {
                    Player.Move(0, +1);
                }
            }
        }
        static void updatePlayer()
        {
            for (int y = -1; y < 2; y++)
            {
                for (int x = -2; x < 3; x++)
                {
                    grid[Player.getY() + y, Player.getX() + x].Set(Player.sprite[y + 1,x + 2].ToString());
                }
            }
        }
        static void updateScreen()
        {
            Console.SetCursorPosition(0, 0);
            printGrid();
        }
        static void printGrid()
        {
            string toPrint = "";
            for (int col = 0; col < gridHeight; col++)
            {
                for (int row = 0; row < gridWidth; row++)
                {
                    toPrint += grid[col, row].val;
                    grid[col, row].Clear();
                }
                toPrint += "\n";
            }
            Console.WriteLine(toPrint);
        }
        static void createGrid()
        {
            for (int col = 0; col < gridHeight; col++)
            {
                for (int row = 0; row < gridWidth; row++)
                {
                    Cell cell = new Cell();
                    if (row == 0 || row > gridWidth - 2 || col == 0 || col > gridHeight - 2)
                    {
                        cell.Set("*");
                    }
                    else
                    {
                        cell.Clear();
                    }
                    grid[col, row] = cell;
                }
            }
        }
    }
}
