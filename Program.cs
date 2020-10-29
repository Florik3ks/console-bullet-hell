using System;
using System.Threading;
using System.Collections.Generic;

namespace console_bullet_hell
{
    static class Program
    {
        public static int gridHeight = 44;
        public static int gridWidth = 121;
        public static List<Bullet> bullets;
        public static bool running;
        public static int dodgedBullets;
        private static int speed = 1;
        private static int spawnTimer;
        private static int spawnTimerCooldown = 50;
        private static Cell[,] grid = new Cell[gridHeight, gridWidth];
        static void Main(string[] args)
        {
            Start();
        }
        static void Start()
        {
            while (true)
            {
                Console.Title = "Console Bullet Hell owo";
                Player.setPosition(gridWidth / 2, gridHeight / 2);
                Console.CursorVisible = false;
                Console.SetWindowSize(gridWidth + 1, gridHeight + 3);
                running = true;
                bullets = new List<Bullet>();
                spawnTimer = 0;
                dodgedBullets = 0;
                createGrid();
                Game();
            }
        }
        static void Game()
        {
            while (running)
            {
                input();
                updatePlayer();
                updateBullets();
                updateScreen();
                spawnTimer--;
                if (spawnTimer <= 0)
                {
                    spawnTimer = spawnTimerCooldown;
                    spawnBullet();
                }
                Thread.Sleep(speed * 1);
            }
            Console.SetCursorPosition(gridWidth / 2, gridHeight / 2);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("PRESS ENTER");
            Console.ReadLine();
            Console.ResetColor();
        }
        static void spawnBullet()
        {
            int x;
            int y;
            Random rand = new Random();
            int r = rand.Next(0,3);
            if (r == 0){
                // oben
                y = 2;
                x = rand.Next(2, gridWidth - 2);
            }
            else if (r == 1){
                // unten
                x = rand.Next(2, gridWidth - 2);
                y = gridHeight - 2;
            }
            else if(r == 2){
                //links
                x = 2;
                y = rand.Next(2, gridHeight - 2);
            }
            else{
                // rechts
                x = gridWidth - 2;
                y = rand.Next(2, gridHeight - 2);
            }
            bullets.Add(new Bullet(x, y));
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
                    grid[Player.getY() + y, Player.getX() + x].Set(Player.sprite[y + 1, x + 2].ToString());
                }
            }
        }
        static void updateBullets()
        {
            // foreach(Bullet b in bullets){
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                Bullet b = bullets[i];
                grid[(int)b.y, (int)b.x].Set("o");
                b.Move();
            }
        }
        static void updateScreen()
        {
            Console.SetCursorPosition(0, 0);
            printGrid();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Dodged bullets: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(dodgedBullets);
            Console.ResetColor();
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
