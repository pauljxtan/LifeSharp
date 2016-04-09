using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model
{
    /// <summary>
    /// 2-dimensional convolution.
    /// </summary>
    public class Convolution2D
    {
        /// <summary>
        /// Performs slow brute-force 2-D convolution with zero-padding.
        /// (TODO: Add other padding options, e.g. periodic boundary conditions)
        /// </summary>
        /// <param name="image">The image to convolve.</param>
        /// <param name="kernel">The convolution kernel.</param>
        /// <returns>The convolved image.</returns>
        public static int[,] Convolve(int[,] image, int[,] kernel)
        {
            int imageHeight = image.GetLength(0);
            int imageWidth = image.GetLength(1);
            int kernelHeight = kernel.GetLength(0);
            int kernelWidth = kernel.GetLength(1);

            // Pad image with zeros
            int numRowsToPad = kernelHeight / 2;
            int numColsToPad = kernelWidth / 2;
            int[,] imagePadded = PadImageWithZeros(image, numRowsToPad, numColsToPad);

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
        /// Pads an image with a given number of rows and columns comprised of zeros.
        /// </summary>
        /// <param name="image">The image to pad.</param>
        /// <param name="numRowsToPad">The number of rows to add.</param>
        /// <param name="numColsToPad">The number of columns to add.</param>
        /// <returns>The padded image.</returns>
        public static int[,] PadImageWithZeros(int[,] image, int numRowsToPad, int numColsToPad)
        {
            int imageHeight = image.GetLength(0);
            int imageWidth = image.GetLength(1);

            int[,] imagePadded = new int[imageHeight + 2 * numRowsToPad, imageWidth + 2 * numColsToPad];
            for (int i = 0; i < imageHeight; i++)
            {
                for (int j = 0; j < imageWidth; j++)
                {
                    imagePadded[i + numRowsToPad, j + numColsToPad] = image[i, j];
                }
            }
            return imagePadded;
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
