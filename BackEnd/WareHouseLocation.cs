using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    [Serializable]
    public class WareHouseLocation : IEnumerable<I3DObject>
    {
        internal SortedSet<I3DObject> wareHouseStorage;
        internal bool ContaintsFragile { get; set; }
        internal long MaxVolume { get; set; }
        internal decimal MaxWeight { get; set; }
        public long Height { get; }
        public long Width { get; }
        public long Depth { get; }

        internal WareHouseLocation()
        {
            wareHouseStorage = new SortedSet<I3DObject>(new UtilitySort());
            ContaintsFragile = false;
            MaxWeight = 1000;
            Height = 100;
            Width = 100;
            Depth = 100;
            MaxVolume = Height * Width * Depth;
        }
        internal bool TryAdd(I3DObject box)
        {            
            if(box.IsFragile && this.MaxWeight < 1000)
            {
                return false;
            }
            else if(box.MaxDimension < this.Width && box.Weight <= this.MaxWeight && box.Volume < this.MaxVolume && this.ContaintsFragile == false)
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
        internal WareHouseLocation Content()
        {
            var storageSpace = new SortedSet<I3DObject>(new UtilitySort());

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

        internal bool RemoveBox(int id)
        {
            foreach (var box in wareHouseStorage)
            {
                if(box.Id == id)
                {
                    I3DObject boxToRemove = box;
                    this.wareHouseStorage.Remove(boxToRemove);
                    return true;
                }
            }
            return false;
        }

        internal bool ContainsId(int id)
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
            return this.wareHouseStorage.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return this.wareHouseStorage.GetEnumerator();
        }

        public override string ToString()
        {
            if(this.wareHouseStorage.Count == 0)
            {
                return "No boxes in this storage space";
            }

            string storageContent = "Remaining Weight " + this.MaxWeight + " Remaining Volume " + this.MaxVolume + "\nContent:\n";
            foreach (var box in this.wareHouseStorage)
            {
                storageContent += "Id: " + box.Id.ToString();
                storageContent += " Fragile: " + box.IsFragile.ToString();
                storageContent += " Weight: " + box.Weight.ToString();
                storageContent += " Shape: " + box.Description.ToString();
                storageContent += "Insurance Value: " + box.InsuranceValue.ToString();
                storageContent += "\n";
            }

            return storageContent;
        }
    }
}
