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

        public static void AddBox(WareHouse facility)
        {
            Console.WriteLine("Choose the shape of the packet: \n(1): Cube\n(2): CubeOid\n(3): Blob\n(4): Sphere");
            int menuInput = Convert.ToInt32(Console.ReadLine());
            BoxSpecs box = new BoxSpecs();
            switch (menuInput)
            {
                case 1:
                    {
                        box = BoxCreator("Cube");
                        //cube
                        break;
                    }
                case 2:
                    {
                        box = BoxCreator("CubeOid");
                        //cubeoid
                        break;
                    }
                case 3:
                    {
                        box = BoxCreator("Blob");
                        //blob
                        break;
                    }
                case 4:
                    {
                        box = BoxCreator("Sphere");
                        //sphere
                        break;
                    }
                default:
                    Console.WriteLine("Incorrec input");
                    return;
            }
            if(box == null)
            {
                Console.WriteLine("Couldnt add box");
            }
            else
            {
                Console.WriteLine("Box was added succesfully");
            }
        }

        private static BoxSpecs BoxCreator(string description)
        {

            switch(description)
            {
                case "Cube":
                    {
                        Console.Write("Input dimensions\nSide length:");
                        bool correctLength = int.TryParse(Console.ReadLine(), out int length);
                        Console.Write("Weight: ");
                        bool correctWeight = int.TryParse(Console.ReadLine(), out int weight);
                        Console.Write("Is the packet fragile?\n(1): Yes (2): No");
                        bool correctInput = int.TryParse(Console.ReadLine(), out int input);
                        if (correctInput && correctLength && correctWeight)
                        {
                            bool isFragile = input == 1 ? true : false;
                            BoxSpecs cube = new BoxSpecs(length, weight, "Cube", isFragile);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect measurements");
                        }
                        break;
                    }
                case "CubeOid":
                    {
                        break;
                    }
                case "Blob":
                    {
                        break;
                    }
                case "Sphere":
                    {
                        break;
                    }
            }
        }

        public static void RemoveBox(WareHouse facility)
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
        }

        public static void MoveBox(WareHouse facility)
        {
            Console.Write("Input box ID");
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
                Console.WriteLine("Incorrect input. Try again.");
            }

            if(succes)
            {
                Console.WriteLine("Box moved");
            }
            else
            {
                Console.WriteLine("Box didnt fit in storage unit");
            }
        }

        public static void FindBox(WareHouse facility)
        {
            Console.Write("Input box ID: ");
            bool correctId = int.TryParse(Console.ReadLine(), out int iD);

            if(correctId)
            {
               int[] storagePlace = facility.Peek(iD);
                if(storagePlace != null)
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
        }

        public static void RevealStorageContent(WareHouse facility)
        {
            Console.Write("Input Level: ");
            int level = Convert.ToInt32(Console.ReadLine()); 
            Console.Write("Input location: ");
            int location = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(facility[level,location]);
        }

        public static void PrintWareHouse(WareHouse warehouse)
        {
            warehouse.ShowContent();
        }

        public static bool Quit()
        {
            return false;
        }
    }
}
