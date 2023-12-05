using Trialogica;
using Xunit;

namespace Test
{
    public class TrialogerTests
    {
        [Theory]
        [InlineData(3,4,5, TriangleType.RightTriangle)]
        [InlineData(3,4,6, TriangleType.ObtuseTriangle)]
        [InlineData(3,3,3, TriangleType.AcuteTriangle)]
        [InlineData(3,4,4, TriangleType.AcuteTriangle)]
        [InlineData(3,4,4.5, TriangleType.AcuteTriangle)]

        public void GetTriangleType_ValidSides(double sideA, double sideB, double sideC, TriangleType expected)
        {
            var result = Trialoger.GetTriangleType(sideA, sideB, sideC);
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(3, 4, 0)]
        [InlineData(-1, -1, -1)]
        [InlineData(3, 4, -1)]
        [InlineData(3, 4, 100)]
        [InlineData(3, 4, 7)]
        public void GetTriangleType_NoValidSides_ThrowArgumentException(double sideA, double sideB, double sideC)
        {
            Assert.Throws<ArgumentException>(() => Trialoger.GetTriangleType(sideA, sideB, sideC));
        }

        [Theory]
        [InlineData(2, 4, 4.472, TriangleType.RightTriangle)]
        public void GetTriangleType_LowPrecision(double sideA, double sideB, double sideC, TriangleType expected)
        {
            //arrange
            Trialoger.Precision = 2;

            //act
            var result = Trialoger.GetTriangleType(sideA, sideB, sideC);

            //assert
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(2, 4, 4.472, TriangleType.RightTriangle)]
        public void GetTriangleType_HighPrecision(double sideA, double sideB, double sideC, TriangleType expected)
        {
            Trialoger.Precision = 4;
            var result = Trialoger.GetTriangleType(sideA, sideB, sideC);
            Assert.NotEqual(result, expected);
        }
    }
}