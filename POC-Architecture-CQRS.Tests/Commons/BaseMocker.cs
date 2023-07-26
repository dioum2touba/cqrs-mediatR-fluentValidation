using Moq;

namespace POC_Architecture_CQRS.Tests.Commons;

public class BaseMocker
{
    public Mock<T> Initialize<T>() where T : class
    {
        return new Mock<T>();
    }

    public T MakeFake<T>() where T : class
    {
        return new Mock<T>().Object;
    }
}