using System;

namespace BackEnd
{
    public class WareHouse 
    {
        private WareHouseLocation[,] facility;
        private const int Levels = 3;
        private const int Locations = 101;
        private int Id;

        public WareHouse()
        {
            facility = new WareHouseLocation[Levels, Locations];
            Id = 0;
            for(int level = 1; level < facility.GetLength(0); level++)
            {
                for(int locations = 1; locations < facility.GetLength(1); locations++)
                {
                    facility[level, locations] = new WareHouseLocation(); 
                }
            }
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

        //ShowContent(int index);
        public void ShowContent(int level, int location)
        {
            WareHouseLocation content = new WareHouseLocation();
            content = facility[level, location].Content();

            Console.WriteLine();
        }

        //Använder sig av metoden content i WareHouseStorage

        // public I3DObject Remove(int id)

        // public bool Move()
     
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
    }
}
