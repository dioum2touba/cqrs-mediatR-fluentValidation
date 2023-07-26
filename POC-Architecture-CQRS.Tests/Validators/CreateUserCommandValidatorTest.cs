using FluentValidation.TestHelper;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateUser;
using POC_Architecture_CQRS.Tests.Commons;
using POC_Architecture_CQRS.Validators;

namespace POC_Architecture_CQRS.Tests.Validators;

public class CreateUserCommandValidatorTest : BaseTests
{
    private readonly CreateUserCommandValidator _sut;

    public CreateUserCommandValidatorTest() => this._sut = new CreateUserCommandValidator();

    [Fact]
    public void Should_have_error_when_Fields_is_null()
    {
        var model = new CreateUserCommandParam(string.Empty, string.Empty, string.Empty, string.Empty, Guid.Empty);
        var result = _sut.TestValidate(model);
        result.ShouldHaveValidationErrorFor(commandParam => commandParam.AddressId);
        result.ShouldHaveValidationErrorFor(commandParam => commandParam.PhoneNumber);
        result.ShouldHaveValidationErrorFor(commandParam => commandParam.FirstName);
        result.ShouldHaveValidationErrorFor(commandParam => commandParam.FirstName);
        result.ShouldHaveValidationErrorFor(commandParam => commandParam.LastName);
    }

    [Fact]
    public void Should_not_have_error_when_Fields_is_specified()
    {
        var firstName = this.MoqFakeDataType<string>();
        var lastName = this.MoqFakeDataType<string>();
        var phoneNumber = this.MoqFakeDataType<string>();
        var gender = this.MoqFakeDataType<string>();
        var addressId = this.MoqFakeDataType<Guid>();

        var model = new CreateUserCommandParam(firstName, lastName, phoneNumber, gender, addressId);
        var result = _sut.TestValidate(model);

        result.ShouldNotHaveValidationErrorFor(commandParam => commandParam.AddressId);
        result.ShouldNotHaveValidationErrorFor(commandParam => commandParam.PhoneNumber);
        result.ShouldNotHaveValidationErrorFor(commandParam => commandParam.FirstName);
        result.ShouldNotHaveValidationErrorFor(commandParam => commandParam.FirstName);
        result.ShouldNotHaveValidationErrorFor(commandParam => commandParam.LastName);
    }
}