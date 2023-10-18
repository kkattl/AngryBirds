using AngryBirds.View;
using System;
using System.Text;

namespace AngryBirds
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            UserInterface userInterface = new UserInterface();

            userInterface.startGame();

            Console.ReadKey();
        }
    }
}
