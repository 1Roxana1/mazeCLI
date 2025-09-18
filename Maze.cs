using System;
using System.Collections.Generic;

public class Maze
{
    private const int WIDTH = 21;
    private const int HEIGHT = 21;
    private const char WALL = '█';
    private const char PATH = ' ';
    private const char PLAYER = '☺';
    private const char EXIT = 'X';

    private char[,] maze;
    private int playerX, playerY;
    private int exitX, exitY;
    private Random random;

    public int Width => WIDTH;
    public int Height => HEIGHT;
    public char[,] Grid => maze;

    public Maze()
    {
        maze = new char[HEIGHT, WIDTH];
        random = new Random();
    }

    public void GenerateMaze()
    {
        // Инициализация лабиринта стенами
        for (int y = 0; y < HEIGHT; y++)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                maze[y, x] = WALL;
            }
        }

        // Начальная точка для генерации
        int startX = 1;
        int startY = 1;
        maze[startY, startX] = PATH;

        // Рекурсивное создание лабиринта
        CreatePath(startX, startY);

        // Установка игрока
        playerX = 1;
        playerY = 1;
        maze[playerY, playerX] = PLAYER;

        // Установка выхода в правом нижнем углу
        exitX = WIDTH - 2;
        exitY = HEIGHT - 2;
        maze[exitY, exitX] = EXIT;
    }

    private void CreatePath(int x, int y)
    {
        // Возможные направления: вверх, вправо, вниз, влево
        int[] dx = { 0, 2, 0, -2 };
        int[] dy = { -2, 0, 2, 0 };

        // Перемешиваем направления
        List<int> directions = new List<int> { 0, 1, 2, 3 };
        Shuffle(directions);

        foreach (int direction in directions)
        {
            int newX = x + dx[direction];
            int newY = y + dy[direction];

            if (IsInBounds(newX, newY) && maze[newY, newX] == WALL)
            {
                // Убираем стену между текущей и новой клеткой
                maze[y + dy[direction] / 2, x + dx[direction] / 2] = PATH;
                maze[newY, newX] = PATH;

                CreatePath(newX, newY);
            }
        }
    }

    private void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    private bool IsInBounds(int x, int y)
    {
        return x > 0 && x < WIDTH - 1 && y > 0 && y < HEIGHT - 1;
    }

    public bool MovePlayer(ConsoleKey key)
    {
        int newX = playerX;
        int newY = playerY;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                newY--;
                break;
            case ConsoleKey.DownArrow:
                newY++;
                break;
            case ConsoleKey.LeftArrow:
                newX--;
                break;
            case ConsoleKey.RightArrow:
                newX++;
                break;
            default:
                return false;
        }

        if (IsInBounds(newX, newY) && maze[newY, newX] != WALL)
        {
            // Проверяем, не достигли ли выхода
            if (maze[newY, newX] == EXIT)
            {
                return true;
            }

            // Обновляем позицию игрока
            maze[playerY, playerX] = PATH;
            playerX = newX;
            playerY = newY;
            maze[playerY, playerX] = PLAYER;
        }

        return false;
    }

    public (int x, int y) GetPlayerPosition()
    {
        return (playerX, playerY);
    }

    public (int x, int y) GetExitPosition()
    {
        return (exitX, exitY);
    }
}