using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridster
{
    public class Grid
    {
        static private int SizeX;
        static private int SizeY;
        public Grid (int X, int Y)
        {
            SizeX = X;
            SizeY = Y; 
        }
        private dynamic[,] GridRaw = new dynamic[SizeX, SizeY];
        private int x = 0;
        private int y = 0;
        private int count = 0;
        private dynamic[] Around;
        private dynamic[] Line;
        private dynamic[] OneDimensional;

        //Set the index for the grid to get and set to and from.
        public void Set(int valueX, int valueY)
        {
            x = valueX;
            y = valueY;
        }
        public void Move(int valueX, int valueY)
        {
            x += valueX;
            y += valueY;
        }

        public dynamic GetValueByIndex()
        {
            return GridRaw[x, y];
        }
        public dynamic[] GetValuesAroundIndex()
        {
            //Returns values in a one-dimensional array, starting from the top right corner and going clockwise.
            Around[0] = GridRaw[x - 1, y + 1];
            Around[1] = GridRaw[x, y + 1];
            Around[2] = GridRaw[x + 1, y + 1];
            Around[3] = GridRaw[x + 1, y];
            Around[4] = GridRaw[x + 1, y - 1];
            Around[5] = GridRaw[x, y - 1];
            Around[6] = GridRaw[x - 1, y - 1];
            Around[7] = GridRaw[x - 1, y];
            return Around;
        }
        public dynamic[] GetValuesByHorizontalLine(int distance)
        {
            //Returns an array of all values on a line originating from the index. Array is in order of closest to furthest from origin.
            for (int i = 0; i <= distance; i++)
            {
                Line[i] = GridRaw[x + i, y];
            }
            return Line;
        }
        public void SetValueByIndex(dynamic value)
        {
            GridRaw[x, y] = value;
        }
        public dynamic[] ToOneDimension()
        {
            foreach (var item in GridRaw)
            {
                OneDimensional[count] = item;
                count++;
            }
            count = 0;
            return OneDimensional;
        } 
    }
}
