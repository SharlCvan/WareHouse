using System;
using BackEnd;

namespace TentamenOop
{
    class Program
    {
        static void Main(string[] args)
        {
            WareHouse facility = new WareHouse();

            var box = new BoxSpecs(10,1M,"Cube",false);
            var boxes = new BoxSpecs(20,30,40, 999M, "CubeOid", false);
            var boxer = new BoxSpecs(10, 100M, "Cube", true);

            int detgick = facility.Add(box,2,20);
            Console.WriteLine(detgick);
            detgick = facility.Add(boxes);
            Console.WriteLine(detgick);
            detgick = facility.Add(boxer);
            Console.WriteLine(detgick);

            Console.WriteLine("______________________________");

            int[] location = facility.Peek(1);

            Console.WriteLine($"Våning: {location[0]} Plats: {location[1]}");
        }
    }
}
