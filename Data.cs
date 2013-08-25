namespace TableTennis
{
    using System;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// Responsible for saving and loading data to/from file.
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Save data to file.
        /// </summary>
        public static void SaveData()
        {
            StreamWriter writer = new StreamWriter(@"../../score.ttn");
            using (writer)
            {
                writer.WriteLine("gameType " + MenuSettings.gameType);
                writer.WriteLine("gameSpeed " + MenuSettings.gameSpeed);
                writer.WriteLine("padSize " + MenuSettings.racketLength);
                writer.WriteLine("probability " + MenuSettings.probability);
                writer.WriteLine("ballPositionX " + Ball.ballPositionX);
                writer.WriteLine("ballPositionY " + Ball.ballPositionY);
                writer.WriteLine("ballCurrentDirectionX " + Ball.ballCurrentDirectionX);
                writer.WriteLine("ballCurrentDirectionY " + Ball.ballCurrentDirectionY);
                writer.WriteLine("ballDirection " + Ball.ballDirection);
                writer.WriteLine("firstRacketY " + Rackets.firtsRacketY);
                writer.WriteLine("secondRacketY " + Rackets.secondRacketY);
                writer.WriteLine("PL1Points " + Table.firstPlayerPoints);
                writer.WriteLine("PL1SetsWon " + Table.firstPlayerSetsWon);
                writer.WriteLine("PL2Points " + Table.secondPlayerPoints);
                writer.WriteLine("PL2SetsWon " + Table.secondPlayerSetsWon);
                writer.WriteLine("firstPlayerService " + Rackets.firstPlayerService);
            }
        }

        /// <summary>
        /// Loads data from file.
        /// </summary>
        public static void LoadData()
        {
            try
            {
                StreamReader reader = new StreamReader(@"../../score.ttn");

                using (reader)
                {
                    // load type of game (PL1vsPL2 or PL1vsPC)
                    string[] line = reader.ReadLine().Split(' ');
                    MenuSettings.gameType = line[1];

                    line = reader.ReadLine().Split(' ');
                    MenuSettings.gameSpeed = int.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    MenuSettings.racketLength = int.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    MenuSettings.probability = int.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    Ball.ballPositionX = int.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    Ball.ballPositionY = int.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    Ball.ballCurrentDirectionX = int.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    Ball.ballCurrentDirectionY = int.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    Ball.ballDirection = line[1];

                    line = reader.ReadLine().Split(' ');
                    Rackets.firtsRacketY = int.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    Rackets.secondRacketY = int.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    Table.firstPlayerPoints = int.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    Table.firstPlayerSetsWon = byte.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    Table.secondPlayerPoints = int.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    Table.secondPlayerSetsWon = byte.Parse(line[1]);

                    line = reader.ReadLine().Split(' ');
                    Rackets.firstPlayerService = bool.Parse(line[1]);
                }
            }
            catch (Exception)
            {
                // if file is missing
                FileNotFound();
            }

            // Rackets.NewService();
            Table.DrawTable();
            Table.PrintResult();
            MainProgram.Engine();
        }

        /// <summary>
        /// Handles the case when new file is not found
        /// </summary>
        private static void FileNotFound()
        {
            Console.Clear();
            Table.firstPass = true;
            Table.DrawTable();
            Console.SetCursorPosition(Console.WindowWidth / 2, (Console.WindowHeight / 2) - 1);
            Console.WriteLine(' ');
            Console.SetCursorPosition(Console.WindowWidth / 2, (Console.WindowHeight / 2) + 1);
            Console.WriteLine(' ');
            Console.SetCursorPosition(Console.WindowWidth / 2, (Console.WindowHeight / 2) + 3);
            Console.WriteLine(' ');
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((Console.WindowWidth / 2) - 7, Console.WindowHeight / 2);
            Console.Write("File Not Found!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition((Console.WindowWidth / 2) - 19, (Console.WindowHeight / 2) + 2);
            Console.Write("Do you want to start new game (y/n)? : ");

            string choise = Console.ReadLine();
            switch (choise)
            {
                case "y":
                    Console.Clear();
                    MainProgram.Main();
                    break;

                case "n":
                    Environment.Exit(0);
                    break;

                default:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void ExitGame()
        {
            Console.Clear();
            Table.firstPass = true;
            Table.DrawTable();
            Console.SetCursorPosition(Console.WindowWidth / 2, (Console.WindowHeight / 2) - 1);
            Console.WriteLine(' ');
            Console.SetCursorPosition(Console.WindowWidth / 2, (Console.WindowHeight / 2) + 1);
            Console.WriteLine(' ');
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition((Console.WindowWidth / 2) - 20, Console.WindowHeight / 2);
            Console.Write("Do you want to save current GAME (y/n)? : ");
            string saveGame = Console.ReadLine();
            if (saveGame == "y")
            {
                Data.SaveData();
            }

            Environment.Exit(0);
        }
    }
}
