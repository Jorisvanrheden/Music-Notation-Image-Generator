using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Image_Generator_project
{
    public static class Parser
    {
        public static NotationObject Read(string filePath) 
        {
            //first line is always the name
            string name = "";
            List<List<Vector2D>> coordinateSets = new List<List<Vector2D>>();

            string[] lines = File.ReadAllLines(filePath);

            name = lines[0];
            for (int i = 1; i < lines.Length; i++) 
            {
                List<Vector2D> coordinates = new List<Vector2D>();

                string[] parts = lines[i].Split(';');

                for (int j = 0; j < parts.Length; j++)
                {
                    string[] coord = parts[j].Split(',');

                    if (coord.Length != 2) continue;

                    int x = int.Parse(coord[0]);
                    int y = int.Parse(coord[1]);

                    coordinates.Add(new Vector2D(x, y));
                }

                coordinateSets.Add(coordinates);
            }

            return new NotationObject(name, coordinateSets);
        }
    }
}
