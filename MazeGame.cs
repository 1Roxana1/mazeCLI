using System;
using System.Threading;

public class MazeGame
{
    private Maze maze;
    private MazeRenderer renderer;
    private bool isPlaying;

    public MazeGame()
    {
        maze = new Maze();
        renderer = new MazeRenderer();
        isPlaying = true;
    }

    public void Play()
    {
        maze.GenerateMaze();
        renderer.Display(maze);

        while (isPlaying)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isPlaying = false;
                    renderer.DisplayExitMessage();
                    break;
                }

                bool reachedExit = maze.MovePlayer(keyInfo.Key);

                if (reachedExit)
                {
                    renderer.Display(maze);
                    renderer.DisplayWinMessage();
                    isPlaying = false;
                    break;
                }

                renderer.Display(maze);
            }

            Thread.Sleep(50);
        }
    }

    public void ShowWelcome()
    {
        renderer.DisplayWelcomeMessage();
    }
}