using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void AdicionarAssinatura()
    {
        var subscription = new Subscription(null);
        var student = new Student("Gabriel", "Moya", "12345678912", "hello@gabrielmoya.dev");
        student.AddSubscription(subscription);
    }
}
