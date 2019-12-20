using System;
using BackEnd;

namespace TentamenOop
{
    class Program
    {
        static void Main(string[] args)
        {
            WareHouse facility = new WareHouse();
            Start(facility);
        }
        private static void Start(WareHouse facility)
        {
            bool stayInMenu = true;

            while (stayInMenu)
            {
                Presenter.WareHouseMeny();
                int.TryParse(Console.ReadLine(), out int userInput);

                switch(userInput)
                {
                    case 1:
                        {
                            Presenter.AddBox(facility);
                            break;
                        }
                    case 2:
                        {
                            Presenter.RemoveBox(facility);
                            break;
                        }
                    case 3:
                        {
                            Presenter.MoveBox(facility);
                            break;
                        }
                    case 4:
                        {
                            Presenter.FindBox(facility);
                            break;
                        }
                    case 5:
                        {
                            Presenter.RevealStorageContent(facility);
                            break;
                        }
                    case 6:
                        {
                            Presenter.PrintWareHouse(facility);
                            break;
                        }
                    case 7:
                        {
                            stayInMenu = Presenter.Quit();
                            break;
                        }
                    default:
                        Console.WriteLine("Incorrect Input");
                        Console.ReadKey();
                        break;
                }
                facility.StoreWareHouse();
                Console.Clear();
            }
        }
    }
}
