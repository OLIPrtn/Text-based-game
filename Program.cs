using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace residentevil
{
    class Program
    {
        static void Main(string[] args)
        {
            // used to track if the player wants to play again
            char exit = 'n';

            //main program loop
            while (exit != 'e')
            {
                //create a new game and run it
                game g = new game();
                g.NewGame();

                //game is over, ask for another go
                Console.WriteLine("=====================================");
                Console.WriteLine("Press any key to reply or e to exit: ");
                exit = Console.ReadKey().KeyChar;
                // clear console
                Console.Clear();
            }

        }
    }
}
