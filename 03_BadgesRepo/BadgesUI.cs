using _03_BadgesRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesUI
{
    public class UI
    {
        private readonly BadgesRepository _repo = new BadgesRepository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("1) All Badges");
                Console.WriteLine("2) Add Badge");
                Console.WriteLine("3) Edit Badge");
                Console.WriteLine("4) Exit Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowBadges();
                        break;
                    case "2":
                        AddBadge();
                        break;
                    case "3":
                        EditBadge();
                        break;
                    case "4":
                        continueToRun = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter Number of Choice or Exit...");
                        Console.ReadKey();
                     
                        break;
                }
            }
        }

        public void Badges()
        {
            Dictionary<int, List<string>> badges = _repo.ShowAllBadges();

            foreach (KeyValuePair<int, List<string>> valuePair in badges)
            {
                string s = string.Format("{0, -5} {1, -10}\n\n", "ID", "Door");
                string ConvertID = Convert.ToString(valuePair.Key);
                string doors = string.Join(",", valuePair.Value);
                s += string.Format("{0,-5} {1,-10}\n", ConvertID, doors);
                Console.WriteLine($"\n{s}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void AddBadge()
        {
            Dictionary<int, List<string>> badges = _repo.ShowAllBadges();
            Badges1.Badges badge = new Badges1.Badges();
            Console.WriteLine("Enter Badge ID");
            badge.BadgeID = int.Parse(Console.ReadLine());

            foreach (KeyValuePair<int, List<string>> keyValuePair in badges)
            {
                if (badges.ContainsKey(badge.BadgeID))
                {
                    Console.WriteLine("This key already exists.");
                    Console.WriteLine("Please try again...");
                    Console.ReadKey();
                    AddBadge();
                }
            }

            Console.WriteLine("Enter doors for your badge");
            Console.WriteLine("Separate each door with a comma and do not put a space between them.");
            string doors = Console.ReadLine();
            badge.BadgeDoors = doors.Split(',').ToList();
            _repo.AddBadge(badge);
            Console.WriteLine($"Badge {badge.BadgeID} was added.");
            Console.WriteLine($"Badge {badge.BadgeID} now has access to the requested doors.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do? Select a choice from below?");
            Console.WriteLine("1) Add door access to badge");
            Console.WriteLine("2) Remove door access from badge");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    ShowBadges();
                    Console.WriteLine("Enter ID");
                    string addId = Console.ReadLine();
                    int addIdAsInt = int.Parse(addId);

                    bool addDoors = true;
                    while (addDoors)
                    {
                        Console.WriteLine("Enter the name of the door you would like to add:");
                        string newDoor = Console.ReadLine();

                        _repo.AddBadgeDoors(addIdAsInt, newDoor);
                        Console.WriteLine("Add another door? Y or N");
                        string keepAddingDoors = Console.ReadLine();


                        switch (keepAddingDoors)
                        {
                            case "Y":
                                break;
                            case "N":
                                addDoors = false;
                                break;
                            default:
                                Console.WriteLine("Enter Valid Option.");
                                Console.ReadKey();
                                addDoors = false;
                                break;
                        }
                    }
                    break;
                case "2":
                    Console.Clear();
                    ShowBadges();
                    Console.WriteLine("Please enter the Badge ID you would like to remove.");
                    string removeId = Console.ReadLine();
                    int RemoveIdAsInt = Int32.Parse(removeId);
                    Dictionary<int, List<string>> badges = _repo.ShowAllBadges();

                    bool continueToDelete = true;

                    while (continueToDelete)
                    {
                        string currentDoors = string.Join(", ", badges[RemoveIdAsInt]);
                        Console.WriteLine($"{RemoveIdAsInt} has access to these doors: {currentDoors}\n");
                        string removeDoor = Console.ReadLine();
                        _repo.RemoveBadgeDoors(RemoveIdAsInt, removeDoor);
                        Console.WriteLine("Do you want to keep removing? Y or N");

                        string userInput = Console.ReadLine();

                        switch (userInput)
                        {
                            case "Y":
                                break;
                            case "N":
                                continueToDelete = false;
                                break;
                            default:                              
                                Console.WriteLine("Enter valid option.");
                                Console.WriteLine("Press any key to continue.....");
                                Console.ResetColor();
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                default:                    
                    Console.WriteLine("Enter valid option.");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
            }
        }

        public void SeedContent()
        {
            List<string> doors = new List<string>() { "A7" };
            Badges badge12345 = new Badges(12345, doors);

            List<string> doors2 = new List<string>() { "A1", "A4", "B1", "B2" };
            Badges badge22345 = new Badges(22345, doors2);

            List<string> door3 = new List<string>() { "A4", "A5" };
            Badges badge32345 = new Badges(32345, door3);

            _repo.AddBadge(badge12345);
            _repo.AddBadge(badge22345);
            _repo.AddBadge(badge32345);
        }
    }
}