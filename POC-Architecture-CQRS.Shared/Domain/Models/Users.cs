namespace POC_Architecture_CQRS.Shared.Domain.Models;

public class Users
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Gender { get; set; }
    public Guid AddressId { get; set; }
    public virtual Address Address { get; set; }
}