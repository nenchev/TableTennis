namespace Sounds
{
    using System;
    using System.Linq;
    using System.Media;
    using System.IO;

    public class Sounds
    {
        public static string path = @"..\..\";

        public static void PadHit()
        {
            string ballPath = @"Sounds\Ball.wav";
            using (SoundPlayer padHit = new SoundPlayer(Path.Combine(path,ballPath)))
            {
                padHit.Play();
            }
        }

        public static void MakePoints()
        {
            string pointsPath = @"Sounds\MakePoint3.wav";
            using (SoundPlayer makePoint3 = new SoundPlayer(Path.Combine(path,pointsPath)))
                {
                    makePoint3.Play();
                }                       
        }

        public static void WallHit()
        {
            string wallPath = @"Sounds\Wall.wav";
            using (SoundPlayer wallHit = new SoundPlayer(Path.Combine(path,wallPath)))
            {
                wallHit.Play();
            }
        }

        public static void Clapping()
        {
            string clapPath = @"Sounds\Clapping.wav";
            using (SoundPlayer clapSound = new SoundPlayer(Path.Combine(path, clapPath)))
            {
                clapSound.Play();
            }
        }

        public static void HitCenter()
        {
            string hitPath = @"Sounds\CenterHit.wav";
            using (SoundPlayer centerHit = new SoundPlayer(Path.Combine(path, hitPath)))
            {
                centerHit.Play();
            }
        }

        public static void WinThreeSets()
        {
            string hitPath = @"Sounds\WinWholeGame.wav";
            using (SoundPlayer winThreeSets = new SoundPlayer(Path.Combine(path, hitPath)))
            {
                winThreeSets.Play();
            }
        }
    }
}