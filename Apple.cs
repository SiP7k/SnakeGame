using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Apple
    {
        public Position applePosition;
        public char symbol { get; }

        public Apple(char[,] map)
        {
            symbol = '+';
            SpawnNewApple(map);
        }

        public void SpawnNewApple(char[,] map)
        {
            Random rand = new Random();

            applePosition.X = rand.Next(1, map.GetLength(1)-1);
            applePosition.Y = rand.Next(1, map.GetLength(0) - 1);
        }
    }
}
