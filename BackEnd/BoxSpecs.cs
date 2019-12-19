using System.Collections.Generic;
using System;

namespace BackEnd
{
    [Serializable]
    public class BoxSpecs
    {
        public int XLength { get; }
        public int YLength { get; }
        public int ZLength { get; }
        public decimal Weight { get;}
        public string Description { get; }
        public bool IsFragile { get; }


        public BoxSpecs()
        {

        }
        public BoxSpecs(int xLength, int yLength, int zLength, decimal weight, string description, bool isFragile)
        {
            XLength = xLength;
            YLength = yLength;
            ZLength = zLength;
            Weight = weight;
            Description = description;
            IsFragile = isFragile;
        }

        public BoxSpecs(int xLength, decimal weight, string description, bool isFragile)
        {
            XLength = xLength;
            Weight = weight;
            Description = description;
            IsFragile = isFragile;
        }

       
    }
}