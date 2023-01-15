using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    private readonly Subscription _subscription;
    private readonly Name _name;
    private readonly Email _email;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Student _student;

    public StudentTests()
    {
        _name = new Name("Bruce", "Wayne");
        _document = new Document("35111507795", EDocumentType.CPF);
        _email = new Email("batmand@dc.com");
        _address = new Address("Rua 1", "1234", "Bairro legal", "Gotham", "SP", "BR", "1340000");
        _student = new Student(_name, _document, _email);
        _subscription = new Subscription(null);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
        _subscription.AddPayment(payment);

        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(_student.Invalid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        var subscription = new Subscription(null);
        _student.AddSubscription(subscription);
        Assert.IsTrue(_student.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
        var subscription = new Subscription(null);
        var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
        subscription.AddPayment(payment);
        _student.AddSubscription(subscription);
        Assert.IsTrue(_student.Valid);
    }
}
