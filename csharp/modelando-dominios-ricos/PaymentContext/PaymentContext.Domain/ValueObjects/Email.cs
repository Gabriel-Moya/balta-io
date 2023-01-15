using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;
using System.Net.Sockets;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject
{
	public Email(string address)
	{
		Address = address;

		AddNotifications(new Contract()
			.Requires()
			.IsEmail(Address, "Email.Address", "E-mail inválido"));
	}

	public string Address { get; private set; }
}
