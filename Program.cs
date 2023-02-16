namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(1, 1);
            Drawer drawer = new Drawer();
            Apple apple = new Apple(drawer.Map);
            drawer.Draw(player,apple);
        }
    }
}