using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LifeSharp.Model.Tests
{
    [TestClass()]
    public class UtilsTests
    {
        [TestMethod()]
        [DeploymentItem("glider.txt")]
        public void getArrayFromFileTest()
        {
            TextReader reader = File.OpenText(@"glider.txt");

            int[,] array = Utils.getArrayFromFile(reader, 10, 10, " ");

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
    }
}