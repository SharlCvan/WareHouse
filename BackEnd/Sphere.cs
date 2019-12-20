using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    [Serializable]
    class Sphere : I3DObject
    {
        public int Radius { get; }
        public int Id { get; }

        public long Volume { get; }

        public decimal Weight { get; }

        public long MaxDimension { get; }

        public int Area { get; }

        public string Description { get; }

        public bool IsFragile { get; }

        public decimal InsuranceValue { get; set; }

        public Sphere(int radius, int id, decimal weight, string description, bool isFragile, decimal insuranceValue)
        {
            Radius = radius;
            Id = id;
            Volume = (radius * 2) * (radius * 2) * (radius * 2);
            Weight = weight;
            MaxDimension = radius * 2;
            Area = 6 * ((radius * 2) * (radius * 2));
            Description = description;
            IsFragile = isFragile;
            InsuranceValue = insuranceValue;
        }

        public object Clone()
        {

            Sphere clone = new Sphere
            (
                this.Radius, this.Id, this.Weight, this.Description, this.IsFragile, this.InsuranceValue
            );
            return clone;

        }

        public override string ToString()
        {
            return $"{this.Description} ID: {this.Id} Weight: {this.Weight}kg Longest Dimension: {this.MaxDimension} Volume: {this.Volume}";
        }
    }
}
