using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Drawer
    {
        public char[,] Map = new char[,]
        { {'-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-'},
          {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ','|'},
          {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ','|'},
          {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ','|'},
          {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ','|'},
          {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ','|'},
          {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ','|'},
          {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ','|'},
          {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ','|'},
          {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ','|'},
          {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ','|'},
          {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ', ' ',' ','|'},
          {'-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-',}
        };
        public void Draw(Player player, Apple apple)
        {
            Console.CursorVisible = false;

            while (player.isAlive)
            {
                for (int i = 0; i < Map.GetLength(0); i++)
                {
                    for (int j = 0; j < Map.GetLength(1); j++)
                    {
                        Console.Write(Map[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Счётчик яблок: " + player.appleCounter);
                DrawApple(apple);
                DrawSnake(player);
                EatApple(player, apple);
                player.Move(Map);
                Console.Clear();
            }
        }
        private void DrawSnake(Player player)
        {
            foreach (var position in player.playerPosition)
            {
                Console.SetCursorPosition(position.X, position.Y);
                Console.Write(player.symbol);
            }
        }
        private void DrawApple(Apple apple)
        {
            Console.SetCursorPosition(apple.applePosition.X, apple.applePosition.Y);
            Console.Write(apple.symbol);
        }
        private void EatApple(Player player, Apple apple)
        {
            if (player.playerPosition.Last().X == apple.applePosition.X && player.playerPosition.Last().Y == apple.applePosition.Y)
            {
                player.isAppleEaten = true;
                player.appleCounter++;
                apple.SpawnNewApple(Map);
            }
        }
    }
}
