using Xunit;

namespace Archivum.Tabular.UnitTests
{

    public class RecordTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var builder = new RecordBuilder()
                .SetName("TestRecord")
                .SetValue("TestValue");

            // Act
            var record = builder.Build();

            // Assert
            Assert.Equal("TestRecord", record.Name);
            Assert.Equal("TestValue", record.Value);
        }

        [Fact]
        public void Value_ShouldReturnNullWhenDataIdIsNull()
        {
            // Arrange
            var builder = new RecordBuilder()
                .SetName("TestRecord");
            var record = builder.Build();

            // Act
            var value = record.Value;

            // Assert
            Assert.Null(value);
        }

        [Fact]
        public void Value_ShouldReturnStoredValue()
        {
            // Arrange
            var builder = new RecordBuilder()
                .SetName("TestRecord")
                .SetValue("TestValue");
            var record = builder.Build();

            // Act
            var value = record.Value;

            // Assert
            Assert.Equal("TestValue", value);
        }

        [Fact]
        public void IsNull_ShouldReturnTrueWhenValueIsNull()
        {
            // Arrange
            var builder = new RecordBuilder();
            var record = builder.Build();

            // Act
            var isNull = record.IsNull;

            // Assert
            Assert.True(isNull);
        }

        [Fact]
        public void IsNull_ShouldReturnFalseWhenValueIsNotNull()
        {
            // Arrange
            var builder = new RecordBuilder()
                .SetName("TestRecord")
                .SetValue("TestValue");
            var record = builder.Build();

            // Act
            var isNull = record.IsNull;

            // Assert
            Assert.False(isNull);
        }

        [Fact]
        public void GetValue_ShouldReturnCorrectValue()
        {
            // Arrange
            var builder = new RecordBuilder()
                .SetName("TestRecord")
                .SetValue("TestValue");
            var record = builder.Build();
            // Act
            var value = record.GetValue();

            // Assert
            Assert.Equal("TestValue", value);
        }

        [Fact]
        public void GetValue_ShouldThrowExceptionWhenValueIsNull()
        {
            // Arrange
            var builder = new RecordBuilder()
                .SetName("TestRecord");
            var record = builder.Build();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => record.GetValue());
        }

        [Fact]
        public void GetValueT_ShouldReturnCorrectValue()
        {
            // Arrange
            var builder = new RecordBuilder()
                .SetName("TestRecord")
                .SetValue(123);
            var record = builder.Build();
            // Act
            var value = record.GetValue<int>();

            // Assert
            Assert.Equal(123, value);
        }

        [Fact]
        public void Dispose_ShouldReleaseResources()
        {
            // Arrange
            var builder = new RecordBuilder()
                .SetName("TestRecord")
                .SetValue("TestValue");
            var record = builder.Build();
            // Act
            record.Dispose();

            // Assert
            Assert.True(record.IsNull);
        }
    }
}
