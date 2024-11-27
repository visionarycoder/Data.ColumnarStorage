using Xunit;

namespace Archivum.Tabular.UnitTests
{
    
public class ColumnTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var columnName = "TestColumn";
            var dataType = typeof(string);
            var isReadOnly = IsReadOnlyValue.Yes;
            var isUnique = IsUniqueValue.Yes;
            var allowDbNull = AllowDbNullValue.No;

            // Act
            var column = new Column(columnName, dataType, isReadOnly, isUnique, allowDbNull);

            // Assert
            Assert.Equal(columnName, column.ColumnName);
            Assert.Equal(dataType, column.DataType);
            Assert.True(column.ReadOnly);
            Assert.True(column.Unique);
            Assert.False(column.AllowDbNull);
        }

        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            // Act
            var column = new Column();

            // Assert
            Assert.Equal(string.Empty, column.ColumnName);
            Assert.Equal(typeof(object), column.DataType);
            Assert.False(column.ReadOnly);
            Assert.False(column.Unique);
            Assert.True(column.AllowDbNull);
            Assert.Equal(-1, column.MaxLength);
            Assert.Equal(string.Empty, column.DefaultValue);
        }

        [Fact]
        public void Constructor_WithColumnName_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            var columnName = "TestColumn";

            // Act
            var column = new Column(columnName);

            // Assert
            Assert.Equal(columnName, column.ColumnName);
            Assert.Equal(typeof(object), column.DataType);
            Assert.False(column.ReadOnly);
            Assert.False(column.Unique);
            Assert.True(column.AllowDbNull);
            Assert.Equal(-1, column.MaxLength);
            Assert.Equal(string.Empty, column.DefaultValue);
        }

        [Fact]
        public void Constructor_WithColumnNameAndDataType_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            var columnName = "TestColumn";
            var dataType = typeof(int);

            // Act
            var column = new Column(columnName, dataType);

            // Assert
            Assert.Equal(columnName, column.ColumnName);
            Assert.Equal(dataType, column.DataType);
            Assert.False(column.ReadOnly);
            Assert.False(column.Unique);
            Assert.True(column.AllowDbNull);
            Assert.Equal(-1, column.MaxLength);
            Assert.Equal(string.Empty, column.DefaultValue);
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Arrange
            var columnName = "TestColumn";
            var dataType = typeof(int);
            var column = new Column(columnName, dataType);

            // Act
            var result = column.ToString();

            // Assert
            Assert.Equal("TestColumn (Int32)", result);
        }
    }
}
