using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.ObjectModel;

namespace LifeSharp.Model.Tests
{
    [TestClass()]
    public class UtilsTests
    {
        [TestMethod()]
        [DeploymentItem(@"TestFiles\glider.txt")]
        public void GetArrayFromFileTest()
        {
            TextReader reader = File.OpenText(@"glider.txt");

            int[,] array = Utils.GetArrayFromFile(reader, " ");

            int[,] expected =
            {
                { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };

            CollectionAssert.AreEqual(expected, array);
        }
        
        [TestMethod()]
        public void ConvertArrayToCollectionTest()
        {
            int[,] array =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            var expected = new ObservableCollection<ObservableCollection<int>>();
            expected.Add(new ObservableCollection<int>(new int[] { 1, 2, 3 }));
            expected.Add(new ObservableCollection<int>(new int[] { 4, 5, 6 }));
            expected.Add(new ObservableCollection<int>(new int[] { 7, 8, 9 }));

            var actual = Utils.ConvertArrayToCollection(array);

            bool elemsEqual = true;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (expected[row][col] != actual[row][col])
                    {
                        elemsEqual = false;
                        break;
                    }

                }
            }

            Assert.IsTrue(elemsEqual);
        }
    }
}