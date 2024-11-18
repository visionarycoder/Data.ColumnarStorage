namespace Archivum.Nucleus.UnitTests;

public class DataTests
{
    [Fact]
    public void SingletonInstance_ShouldReturnSameInstance()
    {
        // Arrange & Act
        var instance1 = Data.Instance;
        var instance2 = Data.Instance;

        // Assert
        Assert.Same(instance1, instance2);
    }

    [Fact]
    public void AddOrGetId_ShouldAddNewValueAndReturnId()
    {
        // Arrange
        var data = Data.Instance;
        var value = "testValue";

        // Act
        var id = data.AddOrGetId(value);

        // Assert
        Assert.NotEqual(Guid.Empty, id);
    }

    [Fact]
    public void GetValue_ShouldReturnCorrectValue()
    {
        // Arrange
        var data = Data.Instance;
        var value = "testValue";
        var id = data.AddOrGetId(value);

        // Act
        var retrievedValue = data.GetValue(id);

        // Assert
        Assert.Equal(value, retrievedValue);
    }

    [Fact]
    public void TryRemove_ShouldRemoveValueAndReturnTrue()
    {
        // Arrange
        var data = Data.Instance;
        var value = "testValue";
        var id = data.AddOrGetId(value);

        // Act
        var result = data.TryRemove(id);

        // Assert
        Assert.True(result);
        Assert.Null(data.GetValue(id));
    }

    [Fact]
    public void AddOrGetId_ShouldReturnExistingIdForDuplicateValue()
    {
        // Arrange
        var data = Data.Instance;
        var value = "testValue";
        var id1 = data.AddOrGetId(value);

        // Act
        var id2 = data.AddOrGetId(value);

        // Assert
        Assert.Equal(id1, id2);
    }
}