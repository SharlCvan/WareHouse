using System;
using BackEnd;

namespace TentamenOop
{
    class Program
    {
        static void Main(string[] args)
        {
            WareHouse facility = new WareHouse();

            // testMove(facility);
            //facility = testAdd(facility);
            //Console.ReadKey();
            //facility = testMove(facility);

            Start(facility);
        }

        private static WareHouse testAdd(WareHouse facility)
        {
            BoxSpecs box = new BoxSpecs(3,2.2M,"Cube",false);
            BoxSpecs box1 = new BoxSpecs(5, 1.2M, "Cube", false);
            BoxSpecs box2 = new BoxSpecs(2, 2.2M, "Cube", false);
            BoxSpecs box3 = new BoxSpecs(3, 3.2M, "Cube", false);

            facility.Add(box);
            facility.Add(box1);
            facility.Add(box2);
            facility.Add(box3);

            return facility;

        }

        private static WareHouse testMove(WareHouse facility)
        {
            facility.Move(1,2,3);
            return facility;
        }

        private static void Start(WareHouse facility)
        {
            bool stayInMenu = true;

            while (stayInMenu)
            {
                Presenter.WareHouseMeny();
                bool correctInput = int.TryParse(Console.ReadLine(), out int userInput);

                switch(userInput)
                {
                    case 1:
                        {
                            //Lägg till ett paket
                            Presenter.AddBox(facility);
                            break;
                        }
                    case 2:
                        {
                            //Ta bort ett paket
                            Presenter.RemoveBox(facility);
                            break;
                        }
                    case 3:
                        {
                            //Flytta på ett paket
                            Presenter.MoveBox(facility);
                            break;
                        }
                    case 4:
                        {
                            //Leta efter paket på ID
                            Presenter.FindBox(facility);
                            break;
                        }
                    case 5:
                        {
                            //Hämta ut plats och skriv ut
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
