using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
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

        public Cube(int side, int id, decimal weight, string description, bool isFragile)
        {
            Side = side;
            Id = id;
            Volume = side * side * side;
            Weight = weight;
            MaxDimension = side;
            Area = 6 * (side * side);
            Description = description;
            IsFragile = isFragile;
            InsuranceValue = 0;
        }

        public object Clone()
        {

            Cube clone = new Cube
            (
                this.Side, this.Id, this.Weight, this.Description, this.IsFragile
            );
            clone.InsuranceValue = this.InsuranceValue;
            return clone;

        }
    }
}
