using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Player
    {
        public bool isAppleEaten = false;
        public int appleCounter;
        public Queue<Position> playerPosition = new Queue<Position>();
        public bool isAlive = true;
        public char symbol { get; set; }
        public Player(int x, int y)
        {
            playerPosition.Enqueue(new Position(x, y));
            appleCounter = 0;
            symbol = '@';
        }
        public void Move(char[,] map)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        playerPosition.Enqueue(new Position(playerPosition.Last().X, playerPosition.Last().Y - 1));
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        playerPosition.Enqueue(new Position(playerPosition.Last().X, playerPosition.Last().Y + 1));

                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        playerPosition.Enqueue(new Position(playerPosition.Last().X + 1, playerPosition.Last().Y));
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        playerPosition.Enqueue(new Position(playerPosition.Last().X - 1, playerPosition.Last().Y));
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            if (!isAppleEaten)
            {
                playerPosition.Dequeue();
            }
            isAppleEaten = false;
            isDead(playerPosition.Last().X,playerPosition.Last().Y,map);
        }
        private void isDead(int a, int b, char[,] map)
        {
            if (map[b, a] == '-' || map[b, a] == '|' || playerPosition.Where(pos => (pos.X, pos.Y) == (a, b)).Count() > 1)
            {
                PrintDeathMessage();
                isAlive = false;
            }
        }
        static private void PrintDeathMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ты мёртв!");
            Console.ReadKey();
        }
    }
}
