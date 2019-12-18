using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    class WareHouseLocation : IEnumerable<I3DObject>
    {
        private SortedSet<I3DObject> wareHouseStorage;
        public bool ContaintsFragile { get; set; }
        public long MaxVolume { get; set; }
        public decimal MaxWeight { get; set; }
        public long Height { get; }
        public long Width { get; }
        public long Depth { get; }

        public WareHouseLocation()
        {
            wareHouseStorage = new SortedSet<I3DObject>(new UtilitySort());
            ContaintsFragile = false;
            MaxWeight = 1000;
            Height = 100;
            Width = 100;
            Depth = 100;
            MaxVolume = Height * Width * Depth;
        }
        public bool TryAdd(I3DObject box)
        {            
            if(box.IsFragile && this.MaxWeight < 1000)
            {
                return false;
            }
            else if(box.MaxDimension < this.Width && box.Weight < this.MaxWeight && box.Volume < this.MaxVolume && this.ContaintsFragile == false)
            {
                this.wareHouseStorage.Add(box);
                ReCalc(box);
                return true;
            }

            return false;
        }
        private void ReCalc(I3DObject box)
        {
            this.MaxWeight -= box.Weight;
            this.MaxVolume -= box.Volume;
            this.ContaintsFragile = box.IsFragile ? true : false;
        }
        public WareHouseLocation Content()
        {
            var storageSpace = new SortedSet<I3DObject>();

            foreach (var box in this.wareHouseStorage)
            {
                I3DObject clone = box.Clone() as I3DObject;
                storageSpace.Add(clone);
            }

            var storage = new WareHouseLocation();
            storage.wareHouseStorage = storageSpace;
            storage.MaxVolume = this.MaxVolume;
            storage.MaxWeight = this.MaxWeight;
            return storage;
        }

        public bool ContainsId(int id)
        {
            foreach (var box in wareHouseStorage)
            {
                if(box.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        IEnumerator<I3DObject> IEnumerable<I3DObject>.GetEnumerator()
        {
            foreach (var storage in wareHouseStorage)
            {
                yield return storage;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }   
    }
}
