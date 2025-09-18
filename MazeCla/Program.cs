using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;

        MazeGame game = new MazeGame();
        game.ShowWelcome();
        Console.ReadKey();

        game.Play();

        Console.WriteLine("                  Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}