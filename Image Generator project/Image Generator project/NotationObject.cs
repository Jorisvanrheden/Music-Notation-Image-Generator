using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Generator_project
{
    public class NotationObject
    {
        public string Name
        {
            get { return name; }
        }
        private string name;

        public Rectangle Rectangle
        {
            get { return minimumRect; }
        }
        private Rectangle minimumRect;

        public List<List<Vector2D>> CoordinateSets
        {
            get { return coordinateSets; }
        }
        private List<List<Vector2D>> coordinateSets;


        public NotationObject(string name, List<List<Vector2D>> coordinateSets) 
        {
            this.name = name;
            this.coordinateSets = coordinateSets;

            minimumRect = GetMininumRect();
        }

        //Find the smallest rectangle that is necessary to contain all the points
        private Rectangle GetMininumRect()
        {
            int x_min = int.MaxValue;
            int x_max = int.MinValue;
            int y_min = int.MaxValue;
            int y_max = int.MinValue;

            foreach (List<Vector2D> coordinates in coordinateSets)
            {
                foreach (Vector2D coordinate in coordinates)
                {
                    if (coordinate.X < x_min) x_min = coordinate.X;
                    if (coordinate.X > x_max) x_max = coordinate.X;
                    if (coordinate.Y < y_min) y_min = coordinate.Y;
                    if (coordinate.Y > y_max) y_max = coordinate.Y;
                }
            }

            foreach (List<Vector2D> coordinates in coordinateSets)
            {
                foreach (Vector2D coordinate in coordinates)
                {
                    coordinate.X -= x_min;
                    coordinate.Y -= y_min;
                }
            }

            int x_range = x_max - x_min + 1;
            int y_range = y_max - y_min + 1;

            return new Rectangle(0, 0, x_range, y_range);
        } 
    }
}
