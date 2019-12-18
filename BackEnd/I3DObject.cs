using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    interface I3DObject :  ICloneable
    {
        int Id { get; }
        long Volume { get; }
        decimal Weight { get; }
        long MaxDimension { get; }
        int Area { get; }
        string Description { get; }
        bool IsFragile { get; }
        decimal InsuranceValue { get; set; }
    }
}
