namespace TableTennis
{
    using System;

    public class Table
    {
        public static int offset = 3;
        public static int positionX = 0;
        public static int positionY = 0;
        public static bool firstPass = true;
        public static int winPoints = 3;
        public static int firstPlayerPoints;
        public static byte firstPlayerSetsWon;
        public static int secondPlayerPoints;
        public static byte secondPlayerSetsWon;

        public static void DrawTable()
        {
            positionX = 1;
            positionY = offset;

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            // draw this part of the table only once (it does not change during the game)
            if (firstPass)
            {
                // draw first horizontal line
                while (positionX < Console.WindowWidth - 1)
                {
                    Console.SetCursorPosition(positionX, positionY);
                    if ((positionX == 1) || (positionX == Console.WindowWidth - 2))
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write('-');
                    }

                    positionX++;
                }

                // draw second horizontal line 
                positionX = 1;
                positionY = Console.WindowHeight - 1;
                while (positionX < Console.WindowWidth - 1)
                {
                    Console.SetCursorPosition(positionX, positionY);
                    if ((positionX == 1) || (positionX == Console.WindowWidth - 2))
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write('-');
                    }

                    positionX++;
                }

                // draw left vertical line
                positionX = 1;
                positionY = offset + 1;
                while (positionY < Console.WindowHeight - 1)
                {
                    Console.SetCursorPosition(positionX, positionY);
                    Console.Write('|');
                    positionY++;
                }

                // draw right vertical line
                positionX = Console.WindowWidth - 2;
                positionY = offset + 1;
                while (positionY < Console.WindowHeight - 1)
                {
                    Console.SetCursorPosition(positionX, positionY);
                    Console.Write('|');
                    positionY++;
                }
            }

            // miiddle line must be redraw during the game, because ball moves over it
            // draw middle vertical line
            positionX = Console.WindowWidth / 2;
            positionY = offset + 1;
            while (positionY < Console.WindowHeight - 1)
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write("|");
                positionY++;
            }

            firstPass = false;
            Console.ResetColor();
        }

        public static void PrintResult()
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            // prints sets won by second player
            positionX = 2;
            positionY = 1;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write("   "); //// clear previos data
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(Table.secondPlayerSetsWon);

            // prints current set result
            positionX = (Console.WindowWidth / 2) - 4;
            positionY = 1;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write("        "); //// clear previos data
            Console.SetCursorPosition(positionX, positionY);
            Console.Write("{0,3} : {1}", Table.secondPlayerPoints, Table.firstPlayerPoints);

            // prints sets won by first player
            positionX = Console.WindowWidth - 3;
            positionY = 1;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write("   "); //// clear previos data
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(Table.firstPlayerSetsWon);
        }

        public static bool CheckSetWon(int pointsA, int pointsB)
        {
            bool check = false;
            if ((pointsA >= winPoints) && ((pointsA - pointsB) >= 2))
            {
                check = true;
                Console.Clear();
                PrintResult();
                firstPass = true;
                DrawTable();
            }

            return check;
        }

        public static bool CheckGameOver(int sets)
        {
            bool check = false;
            if (sets >= 3)
            {
                check = true;
                Console.Clear();
                PrintResult();
                firstPass = true;
                DrawTable();
            }

            return check;
        }

        public static void InitPoints()
        {
            firstPlayerPoints = 0;
            secondPlayerPoints = 0;
        }

        public static void InitSets()
        {
            firstPlayerSetsWon = 0;
            secondPlayerSetsWon = 0;
        }
    }
}
