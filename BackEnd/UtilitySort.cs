using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    [Serializable]
    class UtilitySort : I3DObject,IComparer<I3DObject>
    {
        public int Id => throw new NotImplementedException();

        public long Volume => throw new NotImplementedException();

        public decimal Weight => throw new NotImplementedException();

        public long MaxDimension => throw new NotImplementedException();

        public int Area => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public bool IsFragile => throw new NotImplementedException();

        public decimal InsuranceValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public int Compare(I3DObject x, I3DObject y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
}
