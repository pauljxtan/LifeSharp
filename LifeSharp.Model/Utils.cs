using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model
{
    public class Utils
    {
        public static int[,] GetArrayFromFile(TextReader textReader, int height, int width, String delimiter)
        {
            int[,] array = new int[height, width];

            using (var parser = new TextFieldParser(textReader))
            {
                parser.SetDelimiters(delimiter);
                int row = 0;
                while (!parser.EndOfData)
                {
                    String[] elems = parser.ReadFields();
                    for (int col = 0; col < width; col++)
                    {
                        array[row, col] = int.Parse(elems[col]);
                    }
                    row++;
                }
            }
            return array;
        }
    }
}
