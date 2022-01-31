using System;
using BergerBackend;
using Xunit;

namespace BergerTests
{
    public class BergerHelperTests
    {
        [Fact]
        public void CorrectCheckBergersCodeReturnsTrue()
        {
            int[] input = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0 };

            bool result = BergerHelper.CheckBergersCode(input);
     
            Assert.True(result);
        }
        [Fact]
        public void NotCorrectCheckBergersCodeReturnsTrue()
        {
            int[] input = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0 };

            bool result = BergerHelper.CheckBergersCode(input);

            Assert.False(result);
        }
        [Fact]
        public void WrongLengthCheckBergersThrowsArgumentException()
        {
            int[] input = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1};

            Assert.Throws<ArgumentException>(()=>BergerHelper.CheckBergersCode(input));
        }
        [Fact]
        public void WrongValuesCheckBergersThrowsArgumentException()
        {
            int[] input = { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0 };

            Assert.Throws<ArgumentException>(() => BergerHelper.CheckBergersCode(input));
        }  
        [Fact]
        public void ConvertNumberToBinaryReturnsProperArray()
        {
           
            int[] tenInBinary = {0,1,0,1};

            int[] result = BergerHelper.ConvertShortToBinary(10);

            Assert.Equal(tenInBinary,result);
        }
        [Fact]
        public void CodeBinaryToBergerReturnsProperArray()
        {
            int[] expectedResult = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0 };

            int[] result = BergerHelper.CodeBerger(10);

            Assert.Equal(expectedResult, result);
        }
    }
}
