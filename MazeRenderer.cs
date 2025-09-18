using System;

public class MazeRenderer
{
    public void Display(Maze maze)
    {
        Console.Clear();
        Console.WriteLine("Лабиринт! Используйте стрелки для движения. Цель: дойти до 'X'");
        Console.WriteLine();

        char[,] grid = maze.Grid;

        for (int y = 0; y < maze.Height; y++)
        {
            for (int x = 0; x < maze.Width; x++)
            {
                Console.Write(grid[y, x]);
            }
            Console.WriteLine();
        }
    }

    public void DisplayWinMessage()
    {
        Console.WriteLine("\nПоздравляем! Вы нашли выход из лабиринта!");
    }

    public void DisplayExitMessage()
    {
        Console.WriteLine("\nИгра прервана!");
    }

    public void DisplayWelcomeMessage()
    {
        Console.WriteLine("Добро пожаловать в игру 'Лабиринт'!");
        Console.WriteLine("Управление: стрелки для движения, ESC для выхода");
        Console.WriteLine("Нажмите любую клавишу для начала...");
    }
}