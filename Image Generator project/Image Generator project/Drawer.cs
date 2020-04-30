using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Generator_project
{
    public static class Drawer
    {
        public static Bitmap CreateImage(NotationObject notation)
        {
            Rectangle rect = notation.Rectangle;

            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);

            Graphics graphics = Graphics.FromImage(bitmap);

            foreach (List<Vector2D> coordinates in notation.CoordinateSets)
            {
                //Draw line from x -> x + 1
                for (int i = 0; i < coordinates.Count - 1; i++)
                {
                    Vector2D start = new Vector2D(coordinates[i].X - rect.X, coordinates[i].Y - rect.Y);
                    Vector2D end = new Vector2D(coordinates[i + 1].X - rect.X, coordinates[i + 1].Y - rect.Y);

                    using (Pen pen = new Pen(Brushes.Black, 2))
                    {
                        graphics.DrawLine(pen, start.X, start.Y, end.X, end.Y);
                    }
                }
            }

            return bitmap;
        }
    }
}
