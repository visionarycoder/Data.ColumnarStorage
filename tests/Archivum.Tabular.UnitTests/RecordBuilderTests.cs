using Xunit;

namespace Archivum.Tabular.UnitTests;

public class RecordBuilderTests
{
    [Fact]
    public void SetName_ShouldSetName()
    {
        // Arrange
        var builder = new RecordBuilder();

        // Act
        builder.SetName("TestName");

        // Assert
        Assert.Equal("TestName", builder.Name);
    }

    [Fact]
    public void SetType_ShouldSetType()
    {
        // Arrange
        var builder = new RecordBuilder();
        var type = typeof(string);

        // Act
        builder.SetType(type);

        // Assert
        Assert.Equal(type, builder.Type);
    }

    [Fact]
    public void SetValue_ShouldSetValue()
    {
        // Arrange
        var builder = new RecordBuilder();
        var value = "TestValue";

        // Act
        builder.SetValue(value);

        // Assert
        Assert.Equal(value, builder.Value);
    }

    [Fact]
    public void Build_ShouldReturnRecordWithSetProperties()
    {
        // Arrange
        var builder = new RecordBuilder()
            .SetName("TestName")
            .SetType(typeof(string))
            .SetValue("TestValue");

        // Act
        var record = builder.Build();

        // Assert
        Assert.Equal("TestName", record.Name);
        Assert.Equal("TestValue", record.Value);
        Assert.Equal(typeof(string), record.Type);
    }
}
