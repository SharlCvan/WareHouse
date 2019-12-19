using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    class Blob : I3DObject
    {
        public int Side { get; }
        public int Id { get; }

        public long Volume { get; }

        public decimal Weight { get; }

        public long MaxDimension { get; }

        public int Area { get; }

        public string Description { get; }

        public bool IsFragile { get; }

        public decimal InsuranceValue { get; set; }

        public Blob(int side, int id, decimal weight, string description)
        {
            Side = side;
            Id = id;
            Volume = side * side * side;
            Weight = weight;
            MaxDimension = side;
            Area = 6 * (side * side);
            Description = description;
            IsFragile = true;
            InsuranceValue = 0;
        }

        public object Clone()
        {
            Blob clone = new Blob
            (
                this.Side, this.Id, this.Weight, this.Description
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
