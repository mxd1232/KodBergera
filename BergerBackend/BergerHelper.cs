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
        public static string NegateBit(string bits)
        {
            int bitPlace = FindRandomBitPlace();

            char bitToNegate = bits[bitPlace];

            StringBuilder bitsModifiable = new StringBuilder(bits);

            if (bitToNegate == '0')
            {

                bitsModifiable[bitPlace] = '1';
            }
            else if (bitToNegate == '1')
            {

                bitsModifiable[bitPlace] = '0';
            }
            else
            {
                throw new ArgumentException();
            }

            return bitsModifiable.ToString();
        }
        public static bool IsProperBinaryNumber(string bits)
        {
            if (bits.Length != 20)
            {
                return false;
            }

            foreach (var bit in bits)
            {
                if (bit != '0' && bit != '1')
                {
                    return false;
                }
            }

            return true;
        }
        public static string SwapBits(string bits, bool includeControlSum)
        {
            int zeroBitPlace;
            int oneBitPlace;
            try
            {
                zeroBitPlace = FindRandomSpecificBitPlace(bits, '0', includeControlSum);
                oneBitPlace = FindRandomSpecificBitPlace(bits, '1', includeControlSum);

            }
            catch (ArgumentNullException exception)
            {
                return String.Empty;
            }

            return SwapCharsInString(bits, zeroBitPlace, oneBitPlace);
        }
        private static string SwapCharsInString(string bits, int zeroBitPlace, int oneBitPlace)
        {
            char zeroBit = bits[zeroBitPlace];
            char oneBit = bits[oneBitPlace];

            StringBuilder bitsModifiable = new StringBuilder(bits);
            bitsModifiable[zeroBitPlace] = oneBit;
            bitsModifiable[oneBitPlace] = zeroBit;

            return bitsModifiable.ToString();
        }

        private static int FindRandomSpecificBitPlace(string bits, char wantedBit,bool includeControlSum)
        {
            int maxValue;
            if (includeControlSum)
            {
                maxValue = 20;
            }
            else
            {
                maxValue = 16;
            }
            Random rnd = new Random();

            if (bits.Contains(wantedBit))
            {
                while (true)
                {
                    int bitPlace = rnd.Next(0, maxValue);
                    char properBit = bits[bitPlace];
                    if (properBit == wantedBit)
                    {
                        return bitPlace;
                    }
                }

            }

            throw new ArgumentNullException("not able to properly swap bits because there is only one bit type");
        }

        private static int FindRandomBitPlace()
        {
            Random rnd = new Random();
            return rnd.Next(0, 20);
        }
    }
}
