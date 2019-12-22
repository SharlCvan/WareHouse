using System;
using System.Collections.Generic;
using System.Text;
using BackEnd;

namespace TentamenOop
{
    public static class Presenter
    {
        public static void WareHouseMeny()
        {
            Console.WriteLine("Welcome to the WareHouse menu system\nChoose an option below\n" +
                "(1): Add a packet\n(2): Pick up a packet\n(3): Move a packets location" +
                "\n(4): Search for packet\n(5): Retreave storage unit\n(6): Show all storage units\n(7): Quit");
        }

        public static WareHouse AddBox(WareHouse facility)
        {
            Console.WriteLine("Do you want to add the box to a specific location?\n(1): Yes\n(2): No\n");
            bool addToLocation = int.TryParse(Console.ReadLine(),out int input);
            int[] location = new int[2];
            if (addToLocation && input == 1)
            {
                location = GetLocation();
            }
            else if(!addToLocation)
            {
                Console.WriteLine("Incorrect input");
                return facility;
            }

            Console.WriteLine("Choose the shape of the packet: \n(1): Cube\n(2): CubeOid\n(3): Blob\n(4): Sphere");
            bool menuInput = int.TryParse(Console.ReadLine(), out int shapeInput);
            BoxSpecs box = new BoxSpecs();
            switch (shapeInput)
            {
                case 1:
                    {
                        box = BoxCreator("Cube");
                        break;
                    }
                case 2:
                    {
                        box = BoxCreator("CubeOid");
                        break;
                    }
                case 3:
                    {
                        box = BoxCreator("Blob");
                        break;
                    }
                case 4:
                    {
                        box = BoxCreator("Sphere");
                        break;
                    }
                default:
                    Console.WriteLine("Incorrec input");
                    return facility;
            }
            if(box == null)
            {
                Console.WriteLine("Couldnt add box due to error in user input");
            }
            else
            {
                int boxId = facility.Add(box,location[0],location[1]);

                if(boxId == -1)
                {
                    Console.WriteLine("Box could not be added, storage space is full or contains fragile box");
                }
                else
                {
                    Console.WriteLine("Box was added succesfully. Box Id: {0}", boxId);
                }
            }
            Console.ReadKey();
            return facility;
        }

        private static int[] GetLocation()
        {
            while (true)
            {
                Console.Write("Input which level to add the box to: ");
                bool correctLevel = int.TryParse(Console.ReadLine(), out int level);
                Console.Write("Input which storage unit to add the box to: ");
                bool correctLocation = int.TryParse(Console.ReadLine(), out int location);

                if (correctLevel && correctLocation)
                {
                    int[] levelAndLocation = { level, location };
                    return levelAndLocation;
                }
                else
                {
                    Console.WriteLine("Incorrect input of level or location. Try Again");
                }
            }
        }

        private static BoxSpecs BoxCreator(string description)
        {
            BoxSpecs box = new BoxSpecs();
            switch(description)
            {
                case "Cube":
                    {
                        Console.Write("Input dimensions\nSide length(cm):");
                        bool correctLength = int.TryParse(Console.ReadLine(), out int length);
                        Console.Write("Weight(kg): ");
                        bool correctWeight = decimal.TryParse(Console.ReadLine(), out decimal weight);
                        Console.Write("Is the packet fragile?\n(1): Yes (2): No\n");
                        bool correctInput = int.TryParse(Console.ReadLine(), out int input);

                        if (correctInput && correctLength && correctWeight)
                        {
                            bool isFragile = input == 1 ? true : false;
                            box = new BoxSpecs(length, (decimal)weight, description, isFragile, 0);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect measurements");
                            return box;
                        }
                        break;
                    }
                case "CubeOid":
                    {
                        Console.Write("Input dimensions\nSide X length(cm):");
                        bool correctXLength = int.TryParse(Console.ReadLine(), out int xlength);
                        Console.Write("Input dimensions\nSide Y length(cm):");
                        bool correctYLength = int.TryParse(Console.ReadLine(), out int ylength);
                        Console.Write("Input dimensions\nSide Z length(cm):");
                        bool correctZLength = int.TryParse(Console.ReadLine(), out int zlength);
                        Console.Write("Weight(kg): ");
                        bool correctWeight = decimal.TryParse(Console.ReadLine(), out decimal weight);
                        Console.Write("Is the packet fragile?\n(1): Yes (2): No");
                        bool correctInput = int.TryParse(Console.ReadLine(), out int input);

                        if (correctInput && correctXLength && correctYLength && correctZLength && correctWeight)
                        {
                            bool isFragile = input == 1 ? true : false;
                            box = new BoxSpecs(xlength,ylength,zlength, weight, description, isFragile, 0);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect measurements");
                            return box;
                        }
                        break;
                    }
                case "Blob":
                    {
                        Console.Write("Input dimensions\nSide length(cm):");
                        bool correctLength = int.TryParse(Console.ReadLine(), out int length);
                        Console.Write("Weight(kg): ");
                        bool correctWeight = decimal.TryParse(Console.ReadLine(), out decimal weight);

                        if (correctLength && correctWeight)
                        {
                            box = new BoxSpecs(length, weight, description, true, 0);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect measurements");
                            return box;
                        }
                        break;
                    }
                case "Sphere":
                    {
                        Console.Write("Input dimensions\nRadius length(cm):");
                        bool correctLength = int.TryParse(Console.ReadLine(), out int length);
                        Console.Write("Weight(kg): ");
                        bool correctWeight = decimal.TryParse(Console.ReadLine(), out decimal weight);
                        Console.Write("Is the packet fragile?\n(1): Yes (2): No");
                        bool correctInput = int.TryParse(Console.ReadLine(), out int input);

                        if (correctInput && correctLength && correctWeight)
                        {
                            bool isFragile = input == 1 ? true : false;
                            box = new BoxSpecs(length, weight, description, isFragile, 0);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect measurements");
                            return box;
                        }
                        break;
                    }
            }
            return box;
        }

        public static WareHouse RemoveBox(WareHouse facility)
        {
            Console.Write("Input id of box to remove: ");
            bool correctId = int.TryParse(Console.ReadLine(), out int iD);
            bool succes = false;

            if (correctId)
            {
               succes = facility.Remove(iD);
            }
            else
            {
                Console.WriteLine("Wrong format of ID");
            }

            if(succes)
            {
                Console.WriteLine("Box removed");
            }
            else
            {
                Console.WriteLine("Box not found");
            }
            Console.ReadKey();
            return facility;
        }

        public static WareHouse MoveBox(WareHouse facility)
        {
            Console.Write("Input box ID: ");
            bool correctId = int.TryParse(Console.ReadLine(), out int iD);
            Console.Write("Input which level the box should be moved to: ");
            bool correctLevel = int.TryParse(Console.ReadLine(), out int level);
            Console.Write("Input which storage unit the box should be moved to: ");
            bool correctLocation = int.TryParse(Console.ReadLine(), out int location);
            bool succes = false;

            if (correctId && correctLevel && correctLocation)
            {
               succes = facility.Move(iD,level,location);
            }
            else
            {
                Console.WriteLine("Incorrect input.");
                return facility;
            }

            if(succes)
            {
                Console.WriteLine("Box moved");
            }
            else
            {
                Console.WriteLine("Box didnt fit in storage unit or wasnt found");
            }
            Console.ReadKey();
            return facility;
        }

        public static void FindBox(WareHouse facility)
        {
            Console.Write("Input box ID: ");
            bool correctId = int.TryParse(Console.ReadLine(), out int iD);

            if(correctId)
            {
               int[] storagePlace = facility.Peek(iD);

                if(storagePlace[0] != 0 || storagePlace[1] != 0)
                {
                    Console.WriteLine("Box found on level: {0} in storage unit: {1}",storagePlace[0],storagePlace[1]);
                }
                else
                {
                    Console.WriteLine("Box not found");
                }
            }
            else
            {
                Console.WriteLine("Box ID was in incorrext format");
            }
            Console.ReadKey();
        }

        public static void RevealStorageContent(WareHouse facility)
        {
            Console.Write("Input Level: ");
            bool correctLevel = int.TryParse(Console.ReadLine(), out int level); 
            Console.Write("Input location: ");
            bool correctLocation = int.TryParse(Console.ReadLine(), out int location);

            if(correctLevel && correctLocation)
            {
                if(level > 0 && level < 4 && location > 0 && location < 101)
                {
                    WareHouseLocation storageUnit = facility[level, location];
                    PrintStorageUnit(storageUnit);
                }
                else
                {
                    Console.WriteLine("Wrong input.\nWarehouse contains 3 levels and 100 storage units on each level.");
                }
            }
            else
            {
                Console.WriteLine("Incorrect level and location");
            }
            Console.ReadKey();
        }

        private static void PrintStorageUnit(WareHouseLocation storageUnit)
        {
            Console.WriteLine(storageUnit);
        }

        public static void PrintWareHouse(WareHouse warehouse)
        {
            Console.Clear();
            warehouse.ShowContent();
        }

        public static bool Quit()
        {
            Console.WriteLine("Quiting simulation");
            return false;
        }
    }
}
