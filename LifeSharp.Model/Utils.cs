using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

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

        public static ObservableCollection<ObservableCollection<int>> ConvertArrayToCollection(int[,] array)
        {
            var list = new ObservableCollection<ObservableCollection<int>>();

            for (int row = 0; row < array.GetLength(0); row++)
            {
                list.Add(new ObservableCollection<int>());
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    list.Last().Add(array[row, col]);
                }
            }

            return list;
        }

        public static int[,] GetArrayDeepCopy(int[,] array)
        {
            int height = array.GetLength(0);
            int width = array.GetLength(1);
            var arrayCopy = new int[height, width];

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    arrayCopy[row, col] = array[row, col];
                }
            }

            return arrayCopy;
        }
    }
}
