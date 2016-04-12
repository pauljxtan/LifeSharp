using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model.Tests
{
    [TestClass()]
    public class Convolution2DTests
    {
        [TestMethod()]
        public void ConvolveTest()
        {
            int[,] image =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            int[,] kernel =
            {
                { 1, 3, 5 },
                { 7, 9, 11 },
                { 13, 15, 17 },
            };

            int[,] expected =
            {
                { 40,   91,  92 },
                { 141, 285, 255 },
                { 244, 433, 344 }
            };

            int[,] result = Convolution2D.Convolve(image, kernel, BoundaryConditions.Zeros);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PadImageConstantTest()
        {
            int[,] image =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            int padValue = 1;
            int numRowsToPad = 1;
            int numColsToPad = 2;

            int[,] expected =
            {
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 2, 3, 1, 1 },
                { 1, 1, 4, 5, 6, 1, 1 },
                { 1, 1, 7, 8, 9, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1 }
            };

            int[,] imagePadded = Convolution2D.PadImageConstant(image, padValue, numRowsToPad, numColsToPad);

            CollectionAssert.AreEqual(expected, imagePadded);
        }

        [TestMethod()]
        public void FlipImageBothDimsTest()
        {
            int[,] image =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
            };

            int[,] expected =
            {
                { 9, 8, 7 },
                { 6, 5, 4 },
                { 3, 2, 1 }
            };

            int[,] imageFlipped = Convolution2D.FlipImageBothDims(image);

            CollectionAssert.AreEqual(expected, imageFlipped);
        }
    }
}