using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class UrlTests
{
    [TestMethod]
    [ExpectedException(typeof(InvalidUrlException))]
    public void ShouldReturnExceptionWhenUrlIsInvalid()
    {
        new Url("banana");
    }
    
    [TestMethod]
    public void ShouldNotReturnExceptionWhenUrlIsInvalid()
    {
        new Url("https://balta.io");
        Assert.IsTrue(true);
    }
}