namespace POC_Architecture_CQRS.Shared.Domain.Models;

public partial class Address
{
    public Guid Id { get; set; }
    public string State { get; set; }
    public int PostalCode { get; set; }

    public virtual ICollection<Users> AddressUsers { get; set; }
}