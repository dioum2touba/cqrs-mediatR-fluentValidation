using POC_Architecture_CQRS.Shared.Application.DTOs;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateAddress;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateUser;
using POC_Architecture_CQRS.Shared.Domain.Models;

namespace POC_Architecture_CQRS.Shared.Application.Mappers;

public static class CustomMapper
{
    public static Address ToAddress(this CreateAddressCommandParam command)
        => new()
        {
            PostalCode = command.PostalCode,
            State = command.State,
        };

    public static AddressDto ToAddressDto(this Address address)
        => new(address.Id, address.State, address.PostalCode);

    public static AddressDto ToAddressDto(this AddressSmartSearchDto address)
        => new(Guid.Parse(address.AddressId), address.State, address.PostalCode);

    public static SmartSearchDto ToAddressSmartSearchDto(this AddressDto address)
        => new()
        {
            IndexId = address.Id.ToString(),
            AddressSmartSearch = new()
            {
                AddressId = address.Id.ToString(),
                State = address.State,
                PostalCode = address.PostalCode,
            }
        };

    public static Users ToUsers(this CreateUserCommandParam command)
        => new()
        {
            AddressId = command.AddressId,
            FirstName = command.FirstName,
            Gender = command.Gender,
            LastName = command.LastName,
            PhoneNumber = command.PhoneNumber,
        };

    public static UserDto ToUsersDto(this Users user)
        => new(user.Id, user.FirstName, user.LastName, user.PhoneNumber, user.Gender, user.AddressId, user.Address?.State, user.Address?.PostalCode, $"{user.Address?.PostalCode}, {user.Address?.State}");

    public static UserDto ToUsersDto(this SmartSearchDto smartSearch)
        => new(Guid.Parse(smartSearch.UserId), smartSearch.FirstName, smartSearch.LastName, smartSearch.PhoneNumber, smartSearch.Gender, Guid.Parse(smartSearch.AddressSmartSearch.AddressId), smartSearch.AddressSmartSearch.State, smartSearch.AddressSmartSearch.PostalCode, smartSearch.AddressString);

    public static SmartSearchDto ToSmartSearchDto(this UserDto user)
        => new()
        {
            AddressString = user.AddressString,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Gender = user.Gender,
            IndexId = $"{user.Id}-{user.AddressId}",
            UserId = user.Id.ToString(),
            AddressSmartSearch = new()
            {
                AddressId = user.Id.ToString(),
                PostalCode = (int)user.PostalCode,
                State = user.State
            }
        };
}