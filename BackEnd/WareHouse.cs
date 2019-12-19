using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BackEnd
{
    [Serializable]
    public class WareHouse 
    {
        private WareHouseLocation[,] facility;
        private const int Levels = 4;
        private const int Locations = 101;
        private int Id;

        public WareHouse()
        {
            try
            {
               facility = RetreaveWareHouse();
               Id = GetCurrentId();
            }
            catch
            {
                facility = new WareHouseLocation[Levels, Locations];
                this.Id = 0;
                for (int level = 1; level < facility.GetLength(0); level++)
                {
                    for (int locations = 1; locations < facility.GetLength(1); locations++)
                    {
                        facility[level, locations] = new WareHouseLocation();
                    }
                }
            }
        }

        internal int GetCurrentId()
        {
            int currentId = 0;

            for (int levels = 1; levels < facility.GetLength(0); levels++)
            {
                for (int locations = 1; locations < facility.GetLength(1); locations++)
                {
                    foreach (I3DObject box in facility[levels,locations])
                    {
                        currentId = currentId > box.Id ? currentId : box.Id;
                    }
                }
            }

            return currentId;
        }

        public int Add(BoxSpecs box, int level = 0, int location = 0)
        {
            I3DObject shape = CreateBox(box);

            if(level > 0 && location > 0)
            {
               bool succesfullAdd = facility[level, location].TryAdd(shape);
                if(succesfullAdd)
                {
                    return shape.Id;
                }
                return -1;
            }

            for (int levels = 1; level < facility.GetLength(0); level++)
            {
                for (int locations = 1; locations < facility.GetLength(1); locations++)
                {
                    if(facility[levels, locations].TryAdd(shape))
                    {
                        return shape.Id;
                    }
                }
            }
            return -1;
        }

        public int[] Peek(int id)
        {
            int[] index = new int[2];

            for (int levels = 1; levels < facility.GetLength(0); levels++)
            {
                for(int location = 1; location < facility.GetLength(1); location++)
                {
                    if(facility[levels,location].ContainsId(id))
                    {
                        index[0] = levels;
                        index[1] = location;
                        return index;
                    }
                }
            }
            return index;
        }

        public void ShowContent()
        {
            for (int levels = 1; levels < this.facility.GetLength(0); levels++)
            {
                for (int locations = 1; locations < this.facility.GetLength(1); locations++)
                {
                    Console.WriteLine($"Level: {levels} Storage Unit: {locations}");
                    Console.WriteLine(facility[levels, locations]);
                }
            }
        }

        public WareHouseLocation this[int level, int location]
        {

            get
            {
                return this.facility[level, location].Content();
            }
            
        }
        public bool Remove(int id)
        {
            int[] storageLocation = Peek(id);
            int boxLevel = storageLocation[0];
            int location = storageLocation[1];

            if(this.facility[boxLevel, location].RemoveBox(id))
            {
                return true;
            }
            return false;
        }

        public bool Move(int id, int level, int location)
        {
            //Hitta lådans nuvarande plats och ta ut allt innehåll på platsen
            int[] oldLocation = Peek(id);
            WareHouseLocation storage = facility[oldLocation[0],oldLocation[1]];

            //Ta ut lådan ur nuvarande plats
            object newBox = -1;
            I3DObject boxToAdd;
            bool success = false;
            foreach (var box in storage.wareHouseStorage)
            {
                if(box.Id == id)
                {
                    newBox = box.Clone();
                    boxToAdd = newBox as I3DObject;
                    //Försök lägga till lådan på ny plats
                    success = facility[level, location].TryAdd(boxToAdd);

                    if(success)
                    {
                        //Ta bort den gamla lådan
                        var oldBox = box;
                        storage.wareHouseStorage.Remove(oldBox);
                        return success;
                    }
                }
            }

            return success;
        }
     
        private I3DObject CreateBox(BoxSpecs box)
        {
            this.Id++;
            I3DObject shape;
            if (box.Description == "CubeOid")
            {
                shape = new CubeOid(box.XLength, box.YLength, box.ZLength, Id, box.Weight, box.Description, box.IsFragile);
            }
            else if (box.Description == "Blob")
            {
                shape = new Blob(box.XLength, Id, box.Weight, box.Description);
            }
            else if (box.Description == "Cube")
            {
                shape = new Cube(box.XLength, Id, box.Weight, box.Description, box.IsFragile);
            }
            else
            {
                shape = new Sphere(box.XLength, Id, box.Weight, box.Description, box.IsFragile);
            }

            return shape;
        }

        public void StoreWareHouse()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("WareHouse.txt", FileMode.Create,FileAccess.Write);

            formatter.Serialize(stream,facility);
            stream.Close();
        }

        internal WareHouseLocation[,] RetreaveWareHouse()
        {
            Stream stream = new FileStream("WareHouse.txt", FileMode.Open, FileAccess.Read);
            IFormatter formatter = new BinaryFormatter();
            WareHouseLocation[,] newFacility = (WareHouseLocation[,])formatter.Deserialize(stream);
            stream.Close();

            return newFacility;
        }
    }
}
