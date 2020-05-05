using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Generator_project
{
    class Program
    {
        private static string GLOBAL_FOLDER 
        {
            get
            {
                string workingDirectory = Directory.GetCurrentDirectory();
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                return Path.GetFullPath(Path.Combine(projectDirectory, @"..\..\"));
            }
        }

        private static string INPUT_FOLDER_BASE
        {
            get
            {
                return GLOBAL_FOLDER + @"input\";
            }
        }

        private static string OUTPUT_FOLDER_BASE
        {
            get
            {
                return GLOBAL_FOLDER + @"output\";
            }
        }

        private static Rectangle GetLargestRectangle(List<NotationObject> objects)
        {
            Rectangle rectangle = new Rectangle(0, 0, 0, 0);

            foreach (NotationObject obj in objects)
            {
                if (obj.Rectangle.Width > rectangle.Width) rectangle.Width = obj.Rectangle.Width;
                if (obj.Rectangle.Height > rectangle.Height) rectangle.Height = obj.Rectangle.Height;
            }

            return rectangle;
        }

        private static void CreateImages(List<NotationObject> objects, Rectangle rectangle)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                string folder = OUTPUT_FOLDER_BASE + objects[i].Name;
                string output = folder + "\\" + "image" + i.ToString() + ".jpg";
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                Bitmap bitmap = Drawer.CreateImage(objects[i], rectangle, 2);
                bitmap.Save(output);

                //Console.WriteLine("Completed: " + ((float)i / (float)objects.Count) * 100 + "%");
            }
        }

        static void Main(string[] args)
        {
            List<string> folders = new List<string>();

            List<NotationObject> notationObjects = new List<NotationObject>();

            string[] directories = Directory.GetDirectories(INPUT_FOLDER_BASE);
            for (int i = 0; i < directories.Length; i++) 
            {
                //Get files per directory
                string[] files = Directory.GetFiles(directories[i]);
                for (int j = 0; j< files.Length; j++)
                {
                    NotationObject obj = Parser.Read(files[j]);
                    notationObjects.Add(obj);                             
                }

                Console.WriteLine("Completed: " + ((float)i / (float)directories.Length) * 100 + "%");
            }

            Rectangle rectangle = GetLargestRectangle(notationObjects);
            CreateImages(notationObjects, rectangle);
        }
    }
}
