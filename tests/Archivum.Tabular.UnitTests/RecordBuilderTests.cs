[TestClass]
public class RecordBuilderTests
{
    [TestMethod]
    public void SetName_ShouldSetName()
    {
        // Arrange
        var builder = new RecordBuilder();

        // Act
        builder.SetName("TestName");

        // Assert
        Assert.AreEqual("TestName", builder.Name);
    }

    [TestMethod]
    public void SetType_ShouldSetType()
    {
        // Arrange
        var builder = new RecordBuilder();
        var type = typeof(string);

        // Act
        builder.SetType(type);

        // Assert
        Assert.AreEqual(type, builder.Type);
    }

    [TestMethod]
    public void SetValue_ShouldSetValue()
    {
        // Arrange
        var builder = new RecordBuilder();
        var value = "TestValue";

        // Act
        builder.SetValue(value);

        // Assert
        Assert.AreEqual(value, builder.Value);
    }

    [TestMethod]
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
        Assert.AreEqual("TestName", record.Name);
        Assert.AreEqual("TestValue", record.Value);
        Assert.AreEqual(typeof(string), record.Type);
    }
}
