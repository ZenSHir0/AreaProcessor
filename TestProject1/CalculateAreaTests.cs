using AreaProcessor;

namespace TestProject1;

[TestClass]
public class CalculateAreaTests
{
    [TestMethod]
    [DataRow(1)]
    [DataRow(99.9)]
    [DataRow(150)]
    public void CalculateCircleArea_ValidRadiusValue_ReturnCorrectArea(double value)
    {
        double radius = value;

        double expectedArea = radius * radius * 3.1415926535897931;

        double testArea = GeometryProcessing.CircleArea(radius);

        Assert.AreEqual(expectedArea, testArea);
    }

    [TestMethod]
    [DataRow(-1)]
    [DataRow(-10)]
    [DataRow(-463.2)]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateCircleArea_NegativeRadiusValue_ReturnArgumentException(double value)
    {
        double radius = value;

        GeometryProcessing.CircleArea(radius);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateCircleArea_ZeroRadius_ReturnArgumentException()
    {
        double radius = 0;

        GeometryProcessing.CircleArea(radius);
    }

    [TestMethod]
    [DataRow(4, 3, 5)]
    [DataRow(19.2, 22, 26)]
    [DataRow(1, 1, 1)]
    public void CalculateTriangleArea_ValidSideValues_ReturnCorrectArea(double value1, double value2, double value3)
    {
        double a = value1;
        double b = value2;
        double c = value3;
        double semiperimeter = (a + b + c) / 2;
        double excepted = Math.Sqrt(semiperimeter * (semiperimeter - a)
            * (semiperimeter - b) * (semiperimeter - c));

        var actual = GeometryProcessing.TriangleArea(a, b, c);

        Assert.AreEqual(actual, excepted);
    }

    [TestMethod]
    [DataRow(0, 2, 3)]
    [DataRow(0, 0, 0)]
    [DataRow(9.22, 0, 3)]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateTriangleArea_ZeroSideValue_ReturnArgumentException(double value1, double value2, double value3)
    {
        GeometryProcessing.TriangleArea(value1, value2, value3);
    }

    [TestMethod]
    [DataRow(5, 2, 1)]
    [DataRow(1, 2, 1)]
    [DataRow(55, 0, 3)]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateTriangleArea_InvalidSideValue_ReturnArgumentException(double value1, double value2, double value3)
    {
        GeometryProcessing.TriangleArea(value1, value2, value3);
    }

    [TestMethod]
    [DataRow(3, 4, 5)]
    [DataRow(12, 13, 5)]
    [DataRow(25, 7, 24)]
    public void IsTriangleRight_ValidSideValues_ReturnTrue(double value1, double value2, double value3)
    {
        var actual = GeometryProcessing.IsTriangleRight(value1, value2, value3);

        Assert.AreEqual(actual, true);
    }

    [TestMethod]
    [DataRow(0, -3, 1)]
    [DataRow(10.2, 0, 2)]
    [DataRow(9, 1, 0)]
    [ExpectedException(typeof(ArgumentException))]
    public void IsTriangleRight_ZeroSideValues_ReturnArgumentException(double value1, double value2, double value3)
    {
        GeometryProcessing.IsTriangleRight(value1, value2, value3);
    }
}
