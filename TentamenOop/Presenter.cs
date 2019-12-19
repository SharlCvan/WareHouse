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

        public static void AddBox()
        {
            Console.WriteLine("Choose the shape of");
        }

        public static void RemoveBox()
        {

        }

        public static void MoveBox()
        {

        }

        public static void FindBox()
        {

        }

        public static void RevealStorageContent()
        {

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
