using System;
using System.Collections.Generic;

namespace BergerAlgorithm
{
    public static class BergerHelper
    {
        public static int[] ConvertShortToBinary(short number)
        {
            List<int> binaryList = new List<int>();

            int remainder;
            while (number>0)
            {
               remainder =  number % 2;
               binaryList.Add(remainder);
               number /= 2;
            }

            return FillBinaryTable(binaryList);
        }

        private static int[] FillBinaryTable(List<int> binaryList)
        {
            if (binaryList.Count > 16)
            {
                throw new ArgumentOutOfRangeException();
            }

            int[] binaryFinal = new int[16] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            for (int i = 0; i < binaryList.Count; i++)
            {
                binaryFinal[15 - i] = binaryList[i];
            }

            return binaryFinal;
        }
        public static bool CheckBergersCode(int[] bytes)
        {
            if (bytes.Length != 20)
            {
                throw new ArgumentException();
            }
            foreach (var item in bytes)
            {
                if (item > 1 || item < 0)
                {
                    throw new ArgumentException();
                }
            }
            int[] data = new int[16];
            int[] control = new int[4];
            uint numberOfOnes = 0;
            uint numberOfOnesInControl = 0;

            for (uint i = 0; i < 16; i++)
            {
                data[i] = bytes[i];
                if (bytes[i] == 1)
                {
                    numberOfOnes++;
                }
            }
            for (uint i = 0; i < 4; i++)
            {
                control[i] = bytes[(i + 16)];
                if (control[i] == 1)
                {
                    numberOfOnesInControl += (uint)Math.Pow(2, 3 - i);
                }
            }


            return (numberOfOnes == numberOfOnesInControl) || (numberOfOnes == 16 & numberOfOnesInControl == 0);
        }
        public static int[] CodeBerger(int[] bytes)
        {
            if (bytes.Length != 16)
            {
                throw new ArgumentException();
            }
            int[] codedData = new int[20];
            int numberOfOnes = 0;

            for (int i = 0; i < 16; i++)
            {
                codedData[i] = bytes[i];
                if (codedData[i] == 1)
                {
                    numberOfOnes++;
                }
            }
            int[] controlBytes = convertToBinary(numberOfOnes);

            for (int i = 0; i < 4; i++)
            {
                codedData[i + 16] = controlBytes[i];
            }

            return new int[20];
        }

        private static int[] convertToBinary(int n)
        {
            if (n == 16)
            {
                n = 0;
            }
            if (n > 15 || n < 0)
            {
                throw new ArgumentException();
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(n);
            int[] bytes = new int[4];
            // step 1 : Push the element on the stack
            while (n > 1)
            {
                n = n / 2;
                stack.Push(n);
            }
            int i = 0;
            // step 2 : Pop the element and print the value
            foreach (var val in stack)
            {
                bytes[i] = val % 2;
                i++;
            }
            return bytes;
        }

        /*static void Main(string[] args)
        {
            //10  
            int[] bytesTenTrue = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0 };

            int[] bytesTenChangedOneByte = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0 };

            int[] bytesTenChangedTwoBytes = { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0 };

            int[] bytesTenWrongSwap = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0 };

            int[] bytesTenChangedControl = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0 };

            int[] allOnes = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 };
            /////////////

            int[] bytesTenNoControl = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };

            int[] allOnesNoControl = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            int[] tenAfterBerger = CodeBerger(bytesTenNoControl);
            int[] allOnesAfterBerger = CodeBerger(allOnesNoControl);

            Console.WriteLine(CheckBergersCode(bytesTenTrue));
            Console.WriteLine(CheckBergersCode(bytesTenChangedOneByte));
            Console.WriteLine(CheckBergersCode(bytesTenChangedTwoBytes));
            Console.WriteLine(CheckBergersCode(bytesTenWrongSwap));
            Console.WriteLine(CheckBergersCode(bytesTenChangedControl));
            Console.WriteLine(CheckBergersCode(allOnes));
            Console.WriteLine(CheckBergersCode(tenAfterBerger));
            Console.WriteLine(CheckBergersCode(allOnesAfterBerger));

            Console.ReadKey();
        }*/
    }
}
