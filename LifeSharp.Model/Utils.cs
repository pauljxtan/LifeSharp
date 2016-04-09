using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model
{
    /// <summary>
    /// Miscellaneous utility methods.
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Reads a delimited array of integers from a text file.
        /// </summary>
        /// <param name="textReader">A TextReader constructed from the text file.</param>
        /// <param name="height">The height of the array, i.e. the number of rows.</param>
        /// <param name="width">The width of the array, i.e. the number of rows.</param>
        /// <param name="delimiter">The string used to delimit array elements.</param>
        /// <returns></returns>
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
