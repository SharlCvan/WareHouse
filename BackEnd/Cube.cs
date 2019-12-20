using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    [Serializable]
    class Cube : I3DObject
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

        public Cube(int side, int id, decimal weight, string description, bool isFragile, decimal insuranceValue)
        {
            Side = side;
            Id = id;
            Volume = side * side * side;
            Weight = weight;
            MaxDimension = side;
            Area = 6 * (side * side);
            Description = description;
            IsFragile = isFragile;
            InsuranceValue = insuranceValue;
        }

        public object Clone()
        {

            Cube clone = new Cube
            (
                this.Side, this.Id, this.Weight, this.Description, this.IsFragile,this.InsuranceValue
            );
            return clone;

        }

        public override string ToString()
        {
            return $"{this.Description} ID: {this.Id} Weight: {this.Weight}kg Longest Dimension: {this.MaxDimension} Volume: {this.Volume}";
        }
    }
}
