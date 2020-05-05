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
        public static Bitmap CreateImage(NotationObject notation, Rectangle rect, int strokeThickness)
        {
            //Determine the center of the notation rectangle relative to the rect argument
            int offsetX = rect.Width / 2 - notation.Rectangle.Width / 2;
            int offsetY = rect.Height / 2 - notation.Rectangle.Height / 2;

            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);

            Graphics graphics = Graphics.FromImage(bitmap);

            foreach (List<Vector2D> coordinates in notation.CoordinateSets)
            {
                //Draw line from x -> x + 1
                for (int i = 0; i < coordinates.Count - 1; i++)
                {
                    Vector2D start = new Vector2D(coordinates[i].X, coordinates[i].Y);
                    Vector2D end = new Vector2D(coordinates[i + 1].X, coordinates[i + 1].Y);

                    using (Pen pen = new Pen(Brushes.Black, strokeThickness))
                    {
                        graphics.DrawLine(pen, start.X + offsetX, start.Y + offsetY,
                                               end.X + offsetX, end.Y + offsetY);
                    }
                }
            }

            return bitmap;
        }

        public static Bitmap CreateImage(NotationObject notation, int strokeThickness)
        {
            Rectangle rect = notation.Rectangle;

            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);

            Graphics graphics = Graphics.FromImage(bitmap);

            foreach (List<Vector2D> coordinates in notation.CoordinateSets)
            {
                //Draw line from x -> x + 1
                for (int i = 0; i < coordinates.Count - 1; i++)
                {
                    Vector2D start = new Vector2D(coordinates[i].X, coordinates[i].Y);
                    Vector2D end = new Vector2D(coordinates[i + 1].X, coordinates[i + 1].Y);

                    using (Pen pen = new Pen(Brushes.Black, strokeThickness))
                    {
                        graphics.DrawLine(pen, start.X, start.Y, end.X, end.Y);
                    }
                }
            }

            return bitmap;
        }
    }
}
