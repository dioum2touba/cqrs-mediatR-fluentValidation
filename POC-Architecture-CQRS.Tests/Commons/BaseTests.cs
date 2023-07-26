using AutoFixture;

namespace POC_Architecture_CQRS.Tests.Commons;

public class BaseTests
{
    protected BaseMocker _mock => new();
    protected Fixture _fixture => new();

    protected T MoqFakeDataType<T>()
        => _fixture.Create<T>();
}