using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace residentevil
{
    class game
    {
        public List<string> Inventory;
        /// <summary> 
        /// Start new game
        /// </summary>
        public void NewGame()
        {
            Inventory = new List<string>();
            CastleEnterance();
        }

        

        public void CastleEnterance()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("================================================================");
            Console.WriteLine(" ResidentEvil VILLAGE [CASTLE DIMITRESCU] - TXT LINE");
            Console.WriteLine("================================================================");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("This takes place inside Castle Dimitrescu, solve the puzzles to move into different rooms");
            Console.WriteLine("");
            Console.WriteLine("======= CHARACTERS =======");
            Console.WriteLine("ETHAN WINITERS: You");
            Console.WriteLine("Lady Dimitrescu - main villian");
            Console.WriteLine("The three sisters - villians");
            Console.WriteLine("The duke - you can purchase items that could be useful from him");
            Console.WriteLine("================================================================");
            Console.WriteLine("");
            Console.WriteLine("======= areas =======");
            Console.WriteLine("Enterance");
            Console.WriteLine("Dining hall");
            Console.WriteLine("Armoury room");
            Console.WriteLine("Dukes saferoom");
            Console.WriteLine("Library");
            Console.WriteLine("dungeon");
            Console.WriteLine("castle, outside");
            Console.WriteLine("================================================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
          
            string Name = "castle Enterance";
            string Description = "You are currently at the enterance hall, the doors seemed to be locked\n" +
                                 "We will need to get into the armoury room to get better gear, search around for useful items!\n";



            List<string> actions = new List<string>
            {
                "Check shelves",
                "Search the chests ",
                "Open music box",
                "Look at painting ",
                "Check the main desk",
                "Inventory",
                "HINT"
            };

            DrawRoom(Name, Description, actions);
            int playerChoice = GetPlayerChoice(actions.Count);
            Console.Clear();

            switch (playerChoice)
            {
                case 1:
                    DrawAction("You checked the shelves and found nothing, but you did find an emerald!");
                    AddToInventory(EMERALD);
                    break;

                case 2:
                    DrawAction("You searched chests and found the key, you can now go to the dining hall!");
                    AddToInventory(Dimitrescu_KEY);
                    DiningArea();
                    break;

                case 3:
                    Death("You opened the music box and alerted The Dimitrescus, you died");
                    break;

                case 4:
                    DrawAction("You looked at the painting of L.Dimitrescu, it shows her weapon she loves to use, METALBLADES!");
                    break;

                case 5:
                    DrawAction("You checked the main desk and found a lock pick, that could be useful!");
                    AddToInventory(LOCKPICK);
                    break;

                case 6:
                    ShowInventory();
                    break;

                case 7:
                    DrawAction("Try checking an ovbious place like a ch-??");
                    break;

            }
        }



        public void DiningArea()
        {
            string Name = "Dining Area";
            string Description = "You are currently at the dining area, we currently need to find the password to enter the armoury room!\n";

            List<string> actions = new List<string>
            {
                "Search bookshelves",
                "UnlockdOOR",
                "Go back to hall "
            };


            DrawRoom(Name, Description, actions);
            int playerChoice = GetPlayerChoice(actions.Count);
            Console.Clear();

            switch (playerChoice)
            {
                case 1:
                    DrawAction("You searched the Bookshelves, you found a letter ");
                    Console.WriteLine("LETTER: Dear Lady Dimitrescu, " +
                        "I would like to inform you that I have placed the lockpick somewhere different!");
                    DrawAction("You also found 1 ruby!");
                    AddToInventory(RUBY);
                    DiningArea();
                    break;


                case 2:
                    if (Inventory.Contains(Dimitrescu_KEY))
                    {
                        DrawAction("You used the lockpick to open the armoury door");
                        ArmouryRoom();
                        
                    }
                      else
                    {
                        DrawAction("Locked!");
                        DiningArea();
                    }
                    break;



                case 4:
                    ShowInventory();
                    CastleEnterance();
                    break;


            }

        }



        public void ArmouryRoom()
        {
            string Name = "Armoury Room";
            string Description = "You are currently in the armoury room, gear up!\n" +
                                 "Choose wisley!\n";



            List<string> actions = new List<string>
            { 
                "Grab Pistol",
                "Grab Full armour ",
                "Continue"
            };

            DrawRoom(Name, Description, actions);
            int playerChoice = GetPlayerChoice(actions.Count);
            Console.Clear();

            switch (playerChoice)
            {
                case 1:
                    DrawAction("You picked up a pistol");
                    AddToInventory(PISTOL);
                    break;

                case 2:
                    DrawAction("You put on some armour");
                    AddToInventory(ARMOUR);
                    
                    break;

                case 3:
                    DrawAction("Going to saferoom!");
                    SafeRoom();
                    break;
             

            }
        }

        public void SafeRoom()
        {
            string Name = "Safe room";
            string Description = "Hello stranger, What can I get for you today? \n" +
                                 "yawn!\n";



            List<string> actions = new List<string>
            {
                "Browse Weapons",
                "Browse Armoury",
                "BrowseItems",
                "SELL"
            };

            DrawRoom(Name, Description, actions);
            int playerChoice = GetPlayerChoice(actions.Count);
            Console.Clear();

            switch (playerChoice)
            {
                case 1:
                    DrawAction("You opened weapons category");
                    SHOPRoom();
                    break;

                case 2:
                    DrawAction("You put on some armour");
                    AddToInventory(ARMOUR);

                    break;



            }
        }

        public void SHOPRoom()
        {
            string Name = "Safe room";
            string Description = "Exchange items you have for weapons!\n";



            List<string> actions = new List<string>
            {
              
                " BUY Sniper rifle - Ruby Gem required",
                " BUY SHOTGUN - Diamonds required",
                
                
            };

            DrawRoom(Name, Description, actions);
            int playerChoice = GetPlayerChoice(actions.Count);
            Console.Clear();

            switch (playerChoice)
            {
                case 1:
                    if (Inventory.Contains(RUBY))
                    DrawAction("You purchased a sniper rifle");  

                   

                  else
                    {
                        DrawAction("Whoops, looks like you do not have the item, perhaps wander around the main enterance");
                    }
                    break;

                case 2:
                    DrawAction("You purchased a shotgun!");
                    if (Inventory.Contains(EMERALD))
                    DrawAction("You purchased a shotgun");

                  else {
                        DrawAction("Whoops, looks like you do not have the item, perhaps wander around the main enterance");
                    }
                    break;


            }
        }


        public void DrawRoom(string name, string description, List<string> actions)
        {
            
            Console.WriteLine("Location: ");
            White();
            Console.WriteLine(name);
            Console.WriteLine(description);
            Console.WriteLine();
            Console.WriteLine("Actions:");
            for (int i = 1; i <= actions.Count; i++)
                Console.WriteLine(i + ") " + actions[i - 1]);
            Console.WriteLine();
        }

        //items
        public const string PISTOL = "Pistol";
        public const string SNIPER = "Sniper";
        public const string Dimitrescu_KEY = "Dimitrescu Key";
        public const string KNIFE = "knife";
        public const string MAP = "MAP";
        public const string LOCKPICK = "Lockpick";
        public const string HEISENS_LETTER = "Letter from Heisen";
        public const string ARMOUR = "ARMOUR";
        public const string RUBY = "RUBY";
        public const string EMERALD = "emerald";
        public const string SHOT_GUN = "Shot gun";




        /// check to see if item is already in inventory
        /// </summary>
        /// <parem name="item">Item to add</parem>
        public void AddToInventory(string item)
        {
            if (Inventory.Contains(item)) DrawAction("You search but do not find anything useful");
            else
            {
                Inventory.Add(item);
                DrawAction("You found: " + item);
            }
        }

        /// <summary>
        /// displays current inventory
        /// </summary>

            public void ShowInventory()
        {
            if (Inventory.Count < 1) DrawAlert("You do not have any items to use!");
            else
            {
                green();
                Console.WriteLine("==== Inventory ====");
                White();
                foreach (string item in Inventory)
                    Console.WriteLine(item);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// player choices
        /// </summary>
        /// <parem name="numberOfChoices"> the number of choices valid </parem>
        /// <return> int playyer choice </return>
         public int GetPlayerChoice(int numberOfChoices)
        {
              
            Console.WriteLine("==== what do you want to do? ====");
            Console.Write("Enter your choice (1-" + numberOfChoices + "): ");
           

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= numberOfChoices)
            {
                return choice;
            }
            else
            {
                DrawAlert("Not recognized");
                return GetPlayerChoice(numberOfChoices);
            }
        }


        /// <summary>
        /// Displays the death message
        /// </summary>
        /// <parem name="reason">Text to explain why player died </parem>
        public void Death(string reason)
        {
            red();
            Console.WriteLine("=====================");
            Console.WriteLine("========You Died======");
            White();
            Console.WriteLine();
            Console.WriteLine(reason);
            Console.WriteLine();
        }

        /// <summary>
        /// Displays the death message
        /// </summary>
        /// <parem name="reason">Text to explain why player died </parem>
        public void won(string reason)
        {
            red();
            Console.WriteLine("=====================");
            Console.WriteLine("========You won!======");
            White();
            Console.WriteLine();
            Console.WriteLine(reason);
            Console.WriteLine();
        }

        /// <summary>
        /// Draws alert feedback for the player
        /// </summary>
        /// <parem name="error">Text to display </parem>
        public void DrawAlert(string error)
        {
            red();
            Console.WriteLine("====" + error + "====");
            White();
            Console.WriteLine();
        }

        /// <summary>
        /// Draws alert feedback for the player
        /// </summary>
        /// <parem name="error">Text to display </parem>
        public void DrawAction(string action)
        {
            red();
            Console.WriteLine("====" + action + "====");
            White();
            Console.WriteLine();
        }




        /// <summary> 
        ///  Quick shortcut methods to allow changing foreground colour
        /// </summary>
        public void White()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void red()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public void green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
