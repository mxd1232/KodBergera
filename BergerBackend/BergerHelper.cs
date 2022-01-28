using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BergerBackend
{
    public static class BergerHelper
    {
        public static int[] ConvertShortToBinary(short number)
        {
            List<int> binaryList = new List<int>();

            int remainder;
            while (number > 0)
            {
                remainder = number % 2;
                binaryList.Add(remainder);
                number /= 2;
            }

            return binaryList.ToArray();
        }

        public static string GetBergerString(int[] bergersArray)
        {
            if (bergersArray.Length != 20)
            {
                throw new ArgumentOutOfRangeException();
            }

            string bergerString ="";

            foreach (var i in bergersArray)
            {
                bergerString += i;
            }

            return bergerString;
        }

        private static int[] FillBinaryTable(int[] binaryList)
        {
            if (binaryList.Length > 16)
            {
                throw new ArgumentOutOfRangeException();
            }

            int[] binaryFinal = new int[16] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            for (int i = 0; i < binaryList.Length; i++)
            {
                binaryFinal[15 - i] = binaryList[i];
            }

            return binaryFinal;
        }
        private static int[] FillCheckTable(int[] binaryList)
        {
            if (binaryList.Length > 4)
            {
                throw new ArgumentOutOfRangeException();
            }

            int[] binaryFinal = new int[4] { 0, 0, 0, 0 };

            for (int i = 0; i < binaryList.Length; i++)
            {
                binaryFinal[3 - i] = binaryList[i];
            }

            return binaryFinal;
        }

        public static int[] ConvertStringToBinary(string message)
        {
            int[] bytes = new int[20];

            if (message.Length != 20)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < message.Length; i++)
            {
                bytes[i] = Int32.Parse(message[i].ToString());
            }

            return bytes;
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
                    numberOfOnesInControl += (uint) Math.Pow(2, 3 - i);
                }
            }


            return (numberOfOnes == numberOfOnesInControl) || (numberOfOnes == 16 & numberOfOnesInControl == 0);
        }
        public static int[] CodeBerger(short number)
        {
            int[] numberInBinary = FillBinaryTable(ConvertShortToBinary(number));

            int[] codedData = new int[20];

            short numberOfOnes = 0;

            for (int i = 0; i < 16; i++)
            {
                codedData[i] = numberInBinary[i];
                if (codedData[i] == 1)
                {
                    numberOfOnes++;
                }
            }

            int[] controlBytes =FillCheckTable(ConvertShortToBinary(numberOfOnes));

            for (int i = 0; i < 4; i++)
            {
                codedData[i + 16] = controlBytes[i];
            }

            return codedData;
        }
        //public static int[] CodeBerger(int[] bytes)
        //{
        //    if (bytes.Length != 16)
        //    {
        //        throw new ArgumentException();
        //    }

        //    int[] codedData = new int[20];
        //    short numberOfOnes = 0;

        //    for (int i = 0; i < 16; i++)
        //    {
        //        codedData[i] = bytes[i];
        //        if (codedData[i] == 1)
        //        {
        //            numberOfOnes++;
        //        }
        //    }

        //    int[] controlBytes = convertToBinary(numberOfOnes);

        //    for (int i = 0; i < 4; i++)
        //    {
        //        codedData[i + 16] = controlBytes[3-i];
        //    }

        //    return codedData;
        //}

        //private static int[] convertToBinary(short n)
        //{
        //    if (n == 16)
        //    {
        //        n = 0;
        //    }

        //    if (n > 15 || n < 0)
        //    {
        //        throw new ArgumentException();
        //    }

        //    Stack<short> stack = new Stack<short>();
        //    stack.Push(n);
        //    int[] bytes = new int[4];
        //    // step 1 : Push the element on the stack
        //    while (n > 1)
        //    {
        //        n = (short)(n / 2);
        //        stack.Push(n);
        //    }

        //    int i = 0;
        //    // step 2 : Pop the element and print the value
        //    foreach (var val in stack)
        //    {
        //        bytes[i] = val % 2;
        //        i++;
        //    }

        //    return bytes;
        //}
    }
}
