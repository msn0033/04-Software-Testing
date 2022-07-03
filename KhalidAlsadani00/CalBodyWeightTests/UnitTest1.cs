namespace CalBodyWeightTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void CalWeight_height_is_176_and_sex_m_return_70()
    {
        //Arrang
        var x = new CalBodyWeight.CalWeight
        {
            Height = 180,
            Sex = "m"
        };
        //Act
        double ex = x.GetBodyWeight();
        double ac = 73;
        //Assert
        Assert.AreEqual(expected: ex, actual: ac);

    }

    [TestMethod]
    public void CalWeight_height_is_160_and_sex_w_return_55()
    {
        //Arrang
        var x = new CalBodyWeight.CalWeight
        {
            Height = 160,
            Sex = "w"
        };
        //Act
        double ex = x.GetBodyWeight();
        double ac = 55;
        //Assert
        Assert.AreEqual(expected: ex, actual: ac);

    }
    [TestMethod]
    public void CalWeight_sex_any_return_0()
    {
        //Arrang
        var x = new CalBodyWeight.CalWeight
        {
            Height = 176,
            Sex = "e"
        };
        //Act
        double ex = x.GetBodyWeight();
        double ac = 0;
        //Assert
        Assert.AreEqual(expected: ex, actual: ac);

    }

}