using PaymentContext.Shared.ValueObjects;
using System.Net.Sockets;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject
{
	public Email(string address)
	{
		Address = address;
	}

	public string Address { get; private set; }
}
