using System;
using BackEnd;

namespace TentamenOop
{
    class Program
    {
        //public static WareHouse facility = new WareHouse();

        static void Main(string[] args)
        {
            WareHouse facility = new WareHouse();

            //Test(facility);
            //Console.ReadKey();

            Start(facility);
        }

        private static void Start(WareHouse facility)
        {
            bool stayInMenu = true;

            while (stayInMenu)
            {
                Presenter.WareHouseMeny();
                int userInput = Convert.ToInt32(Console.ReadLine());

                switch(userInput)
                {
                    case 1:
                        {
                            //Lägg till ett paket
                            break;
                        }
                    case 2:
                        {
                            //Ta bort ett paket
                            break;
                        }
                    case 3:
                        {
                            //Flytta på ett paket
                            break;
                        }
                    case 4:
                        {
                            //Leta efter paket på ID
                            break;
                        }
                    case 5:
                        {
                            //Hämta ut plats och skriv ut
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
                }
                facility.StoreWareHouse();
            }
        }

       public static void Test(WareHouse facility)
       {
            int succes = facility.Add(new BoxSpecs(20,1.9M,"Cube",false));
            Console.WriteLine("Lades till med id: {0}",succes);
            Console.ReadKey();

            bool worked = facility.Move(1,2,20);
            Console.WriteLine("The move was: {0}",worked);
            Console.WriteLine(facility[2,20]);
            Console.ReadKey();

            int[] place = facility.Peek(1);
            Console.WriteLine("Låda med id 1 ligger på våning {0} på plats {1}",place[0],place[1]);
            Console.ReadKey();

            bool removed = facility.Remove(1);
            Console.WriteLine("Den togs bort {0}", removed);
            Console.ReadKey();

            facility.Add(new BoxSpecs(20, 1.6M, "Cube", false));
            WareHouseLocation storage = facility[1,1];
        }
    }
}
