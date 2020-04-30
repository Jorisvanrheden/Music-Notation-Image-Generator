using System;
using System.Collections.Generic;
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

        static void Main(string[] args)
        {
            List<string> folders = new List<string>();

            string[] directories = Directory.GetDirectories(INPUT_FOLDER_BASE);
            for (int i = 0; i < directories.Length; i++) 
            {
                //Get files per directory

                string[] files = Directory.GetFiles(directories[i]);
                for (int j = 0; j< files.Length; j++)
                {
                    NotationObject obj = Parser.Read(files[j]);

                    string folder = OUTPUT_FOLDER_BASE + obj.Name;
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }


                    System.Drawing.Bitmap bitmap = obj.ToBitmap();

                    bitmap.Save(folder + "\\" + "image" + i.ToString() + ".jpg");
                }

                Console.WriteLine("Completed: " + ((float)i / (float)directories.Length) * 100 + "%");
            }           
        }
    }
}
