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
        [DeploymentItem("glider.txt")]
        public void GetArrayFromFileTest()
        {
            TextReader reader = File.OpenText(@"glider.txt");

            int[,] array = Utils.GetArrayFromFile(reader, 10, 10, " ");

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

            Console.WriteLine(expected[0][0] + " " + expected[0][1] + " " + expected[0][2] + " " +
                              expected[1][0] + " " + expected[1][1] + " " + expected[1][2] + " " +
                              expected[2][0] + " " + expected[2][1] + " " + expected[2][2]);
            Console.WriteLine(actual[0][0] + " " + actual[0][1] + " " + actual[0][2] + " " +
                              actual[1][0] + " " + actual[1][1] + " " + actual[1][2] + " " +
                              actual[2][0] + " " + actual[2][1] + " " + actual[2][2]);

            // TODO: Why is this failing?
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}