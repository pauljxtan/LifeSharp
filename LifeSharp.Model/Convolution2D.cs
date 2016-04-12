using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model
{
    public enum BoundaryConditions { Zeros, Ones, Periodic };

    /// <summary>
    /// 2-dimensional convolution.
    /// </summary>
    public class Convolution2D
    {
        /// <summary>
        /// Performs slow brute-force 2-D convolution with the given boundary conditions.
        /// </summary>
        /// <param name="image">The image to convolve.</param>
        /// <param name="kernel">The convolution kernel.</param>
        /// <param name="boundaryConditions">The boundary conditions for the convolution</param>
        /// <returns>The convolved image.</returns>
        public static int[,] Convolve(int[,] image, int[,] kernel, BoundaryConditions boundaryConditions = BoundaryConditions.Zeros)
        {
            int imageHeight = image.GetLength(0);
            int imageWidth = image.GetLength(1);
            int kernelHeight = kernel.GetLength(0);
            int kernelWidth = kernel.GetLength(1);

            // Pad image according to boundary conditions
            int numRowsToPad = kernelHeight / 2;
            int numColsToPad = kernelWidth / 2;
            int[,] imagePadded;
            switch (boundaryConditions)
            {
                case BoundaryConditions.Zeros:
                    imagePadded = PadImageConstant(image, 0, numRowsToPad, numColsToPad);
                    break;
                case BoundaryConditions.Ones:
                    imagePadded = PadImageConstant(image, 1, numRowsToPad, numColsToPad);
                    break;
                case BoundaryConditions.Periodic:
                    imagePadded = PadImagePeriodic(image, numRowsToPad, numColsToPad);
                    break;
                default:
                    throw new ArgumentException();
            }

            // Flip kernel
            int[,] kernelFlipped = FlipImageBothDims(kernel);

            int[,] result = new int[imageHeight, imageWidth];

            for (int imageRow = 0; imageRow < imageHeight; imageRow++)
            {
                for (int imageCol = 0; imageCol < imageWidth; imageCol++)
                {
                    for (int kernelRow = 0; kernelRow < kernelHeight; kernelRow++)
                    {
                        for (int kernelCol = 0; kernelCol < kernelWidth; kernelCol++)
                        {
                            result[imageRow, imageCol] += imagePadded[imageRow + kernelRow, imageCol + kernelCol] * kernelFlipped[kernelRow, kernelCol];
                        }
                    }
                }
            }
            
            return result;
        }

        /// <summary>
        /// Pads an image with a given number of rows and columns comprised of a constant value.
        /// </summary>
        /// <param name="image">The image to pad.</param>
        /// <param name="numRowsToPad">The number of rows to add.</param>
        /// <param name="numColsToPad">The number of columns to add.</param>
        /// <returns>The padded image.</returns>
        public static int[,] PadImageConstant(int[,] image, int padValue, int numRowsToPad, int numColsToPad)
        {
            int imageHeight = image.GetLength(0);
            int imageWidth = image.GetLength(1);
            int imagePaddedHeight = imageHeight + 2 * numRowsToPad;
            int imagePaddedWidth = imageWidth + 2 * numColsToPad;

            int[,] imagePadded = new int[imagePaddedHeight, imagePaddedWidth];

            for (int row = 0; row < imagePaddedHeight; row++)
            {
                for (int col = 0; col < imagePaddedWidth; col++)
                {
                    imagePadded[row, col] = padValue;
                }
            }

            for (int row = 0; row < imageHeight; row++)
            {
                for (int col = 0; col < imageWidth; col++)
                {
                    imagePadded[row + numRowsToPad, col + numColsToPad] = image[row, col];
                }
            }
            return imagePadded;
        }

        public static int[,] PadImagePeriodic(int[,] image, int numRowsToPad, int numColsToPad)
        {
            throw new NotImplementedException();

            /*
            int imageHeight = image.GetLength(0);
            int imageWidth = image.GetLength(1);

            int[,] imagePadded = new int[imageHeight + 2 * numRowsToPad, imageWidth + 2 * numColsToPad];

            return imagePadded;
            */
        }

        /// <summary>
        /// Flips an image in both dimensions, i.e. horizontally and vertically.
        /// </summary>
        /// <param name="image">The image to flip.</param>
        /// <returns>The flipped image.</returns>
        public static int[,] FlipImageBothDims(int[,] image)
        {
            int imageHeight = image.GetLength(0);
            int imageWidth = image.GetLength(1);

            int[,] imageFlipped = new int[imageHeight, imageWidth];

            for (int row = 0; row < imageHeight; row++)
            {
                for (int col = 0; col < imageWidth; col++)
                {
                    imageFlipped[row, col] = image[imageHeight - row - 1, imageWidth - col - 1];
                }
            }
            return imageFlipped;
        }
    }
}
