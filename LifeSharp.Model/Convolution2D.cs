using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSharp.Model
{
    public class Convolution2D
    {
        /* Slow brute-force 2D convolution with zero-padding.
         * TODO: Add other padding options */
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

        /* Flips an image in both dimensions. */
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
