using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
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

        public Sphere(int radius, int id, decimal weight, string description, bool isFragile)
        {
            Radius = radius;
            Id = id;
            Volume = (radius * 2) * (radius * 2) * (radius * 2);
            Weight = weight;
            MaxDimension = radius * 2;
            Area = 6 * ((radius * 2) * (radius * 2));
            Description = description;
            IsFragile = isFragile;
            InsuranceValue = 0;
        }

        public object Clone()
        {

            Sphere clone = new Sphere
            (
                this.Radius, this.Id, this.Weight, this.Description, this.IsFragile
            );
            clone.InsuranceValue = this.InsuranceValue;
            return clone;

        }
    }
}
