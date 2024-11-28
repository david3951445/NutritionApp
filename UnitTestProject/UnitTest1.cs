using Microsoft.EntityFrameworkCore;

namespace UnitTestProject;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        using var context = new SamplesContext();
        Assert.True(context.Samples.Any());
    }
}
