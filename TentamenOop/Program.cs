using System;
using BackEnd;

namespace TentamenOop
{
    class Program
    {
        public static WareHouse facility = new WareHouse();

        static void Main(string[] args)
        {
            var boxis = new BoxSpecs(10,1M,"Cube",false);
            int added = facility.Add(boxis);
            Console.WriteLine(added);
            Console.ReadKey();

            Console.WriteLine(facility[1,20]);

            Console.ReadKey();

            var box = new BoxSpecs(10,1M,"Cube",false);
            var boxes = new BoxSpecs(20,30,40, 999M, "CubeOid", false);
            var boxer = new BoxSpecs(10, 100M, "Cube", true);

            int detgick = facility.Add(box);
            Console.WriteLine(detgick);
            detgick = facility.Add(boxes);
            Console.WriteLine(detgick);
            detgick = facility.Add(boxer);
            Console.WriteLine(detgick);

            facility.Move(1,1,20);

            Console.WriteLine(facility[1,1]);

            facility.StoreWareHouse();

            Console.ReadKey();

            Console.WriteLine("______________________________");

            int[] location = facility.Peek(1);

            

            Console.WriteLine($"Våning: {location[0]} Plats: {location[1]}");
        }
    }
}
