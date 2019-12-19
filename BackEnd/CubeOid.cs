using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    [Serializable]
    class CubeOid : I3DObject
    {
        public int Xside { get; }
        public int Yside { get; }
        public int Zside { get; }
        public int Id { get; }
        public long Volume { get; }

        public decimal Weight { get; }

        public long MaxDimension { get; }

        public int Area { get; }

        public string Description { get; }

        public bool IsFragile { get; }

        public decimal InsuranceValue { get; set; }

        public CubeOid(int xSide, int ySide, int zSide, int id,decimal weight, string description, bool isFragile)
        {
            Xside = xSide;
            Yside = ySide;
            Zside = zSide;
            Id = id;
            Volume = xSide * ySide * zSide;
            Weight = weight;
            MaxDimension = Math.Max(xSide, Math.Max(ySide, zSide));
            Area = 2 * ((xSide * ySide) + (ySide * zSide) + (zSide * xSide));
            Description = description;
            IsFragile = isFragile;
            InsuranceValue = 0;
        }

        public object Clone()
        {
            CubeOid clone = new CubeOid
            (
                this.Xside, this.Yside, this.Zside, this.Id, this.Weight, this.Description, this.IsFragile
            );
            clone.InsuranceValue = this.InsuranceValue;
            return clone;
        }

        public override string ToString()
        {
            return $"{this.Description} ID: {this.Id} Weight: {this.Weight}kg Longest Dimension: {this.MaxDimension} Volume: {this.Volume}";
        }
    }
}
