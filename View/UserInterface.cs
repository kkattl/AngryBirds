using AngryBirds.Birds;
using AngryBirds.Lvls;
using System;

namespace AngryBirds.View
{
    public class UserInterface
    {
        private int _lvl;
        private int _birdsBand;
        Game game;

        public void startGame()
        {
            game = new Game();

            chooseLvl();
            chooseBirds();

            makeLvl();
            makeBirdsBand();

            LogFly();
        }

        private void chooseLvl()
        {
            Console.Write("Angry Birds\n\nChoose levl:\n1) 1 Level\n2) 2 Level\n3) 3 Level\n>> ");
            while (!int.TryParse(Console.ReadLine(), out _lvl) || _lvl < 1 || _lvl > 3)
            {
                Console.Write(">> ");
            }
        }

        private void makeLvl()
        {
            switch (_lvl)
            {
                case 1:
                    game.loadObtancles(new Glass(3), new Wood(5), new Wood(7), new Pig(9));
                    break;
                case 2:
                    game.loadObtancles(new Glass(3), new Glass(5), new Glass(7), new Wood(10), new Glass(12), new Pig(17));
                    break;
                case 3:
                    game.loadObtancles(new Wood(2), new Wood(4), new Wood(6), new Stone(8), new Pig(12));
                    break;
            }
        }

        private void chooseBirds()
        {
            Console.Write("Choose birds:\n1) Default\n2) 2 Default, Default\n3) Default, Strong\n4) Strong, Master\n>> ");
            while (!int.TryParse(Console.ReadLine(), out _birdsBand) || _birdsBand < 1 || _birdsBand > 4)
            {
                Console.Write(">> ");
            }
        }

        private void makeBirdsBand()
        {
            switch (_birdsBand)
            {
                case 1:
                    game.loadBirds(new Bird());
                    break;
                case 2:
                    game.loadBirds(new Bird(), new Bird());
                    break;
                case 3:
                    game.loadBirds(new Bird(), new StrongBird());
                    break;
                case 4:
                    game.loadBirds(new StrongBird(), new MasterBird());
                    break;
            }

        }

        private void LogFly()
        {
            foreach (string line in game.game())
            {
                Console.WriteLine(line);
            }
        }
    }
}

