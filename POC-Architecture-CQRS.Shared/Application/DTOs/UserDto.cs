namespace POC_Architecture_CQRS.Shared.Application.DTOs;

public record UserDto(Guid Id, string FirstName, string LastName, string PhoneNumber, string Gender, Guid AddressId, string State, int? PostalCode, string AddressString);