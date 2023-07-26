using FluentValidation.TestHelper;
using POC_Architecture_CQRS.Shared.Application.Features.Commands.CreateAddress;
using POC_Architecture_CQRS.Tests.Commons;
using POC_Architecture_CQRS.Validators;

namespace POC_Architecture_CQRS.Tests.Validators;

public class CreateAddressCommandValidatorTest : BaseTests
{
    private readonly CreateAddressCommandValidator _sut;

    public CreateAddressCommandValidatorTest() => this._sut = new CreateAddressCommandValidator();

    [Fact]
    public void Should_have_error_when_PostalCode_and_State_is_null()
    {
        var model = new CreateAddressCommandParam(string.Empty, default);
        var result = _sut.TestValidate(model);
        result.ShouldHaveValidationErrorFor(commandParam => commandParam.State);
        result.ShouldHaveValidationErrorFor(commandParam => commandParam.PostalCode);
    }

    [Fact]
    public void Should_not_have_error_when_PostalCode_and_State_is_specified()
    {
        var state = this.MoqFakeDataType<string>();
        var postalCode = this.MoqFakeDataType<int>();

        var model = new CreateAddressCommandParam(state, postalCode);
        var result = _sut.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(commandParam => commandParam.State);
        result.ShouldNotHaveValidationErrorFor(commandParam => commandParam.PostalCode);
    }
}