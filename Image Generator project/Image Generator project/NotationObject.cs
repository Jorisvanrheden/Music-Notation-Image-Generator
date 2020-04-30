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
        public string Name;

        private List<List<Vector2D>> coordinateSets;

        public NotationObject(string name, List<List<Vector2D>> coordinateSets) 
        {
            this.Name = name;
            this.coordinateSets = coordinateSets;
        }

        public Bitmap ToBitmap()
        {
            //get width
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

            int range_x = x_max - x_min + 1;
            int range_y = y_max - y_min + 1;
            
            Bitmap bitmap = new Bitmap(range_x, range_y);

            Graphics graphics = Graphics.FromImage(bitmap);

            foreach (List<Vector2D> coordinates in coordinateSets)
            {
                //Draw line from x -> x + 1
                for (int i = 0; i < coordinates.Count - 1; i++) 
                {
                    Vector2D start = new Vector2D(coordinates[i].X - x_min, coordinates[i].Y - y_min);
                    Vector2D end = new Vector2D(coordinates[i + 1].X - x_min, coordinates[i + 1].Y - y_min);

                    Pen pen = new Pen(Brushes.Black, 2);
                    graphics.DrawLine(pen, start.X, start.Y, end.X, end.Y);
                }
            }

            return bitmap;
        } 
    }
}
