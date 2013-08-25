namespace TableTennis
{
    using System;
    using System.Text;
    using System.Threading;

    public class MainProgram
    {
        public static void Engine()
        {
            while (true)
            {
                Ball.HitFirstRacket();
                Ball.HitSecondRacket();
                Ball.HitWall(); // check if the ball is in on the table
                Ball.MoveBall(); // move the ball in specific direction

                if ((Ball.ballDirection == "Left") && (MenuSettings.gameType == "PL1vsPL2"))
                {
                    Rackets.MoveSecondPlayer();
                }
                else if (Ball.ballDirection == "Right")
                {
                    Rackets.MoveFirstPlayer();
                }
                else
                {
                    Rackets.ComputerMoveSecondRacket();
                }

                Rackets.DrawFirstRacket();
                Rackets.DrawSecondRacket();
                Table.DrawTable();

                Thread.Sleep(MenuSettings.gameSpeed);
            }
        }

        public static void Main()
        {
            MenuSettings.Settings();
            MenuSettings.IntroScreen();
            Rackets.NewService();
            Engine();
        }
    }
}