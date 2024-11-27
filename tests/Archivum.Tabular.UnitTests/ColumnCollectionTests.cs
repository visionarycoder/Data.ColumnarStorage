using Xunit;

namespace Archivum.Tabular.UnitTests
{
    
public class ColumnCollectionTests
    {
        [Fact]
        public void Constructor_ShouldInitializeWithGivenColumns()
        {
            // Arrange
            var column1 = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var column2 = new Column("Column2", typeof(int), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);

            // Act
            var columnCollection = new ColumnCollection(column1, column2);

            // Assert
            Assert.Equal(2, columnCollection.Count);
            Assert.Equal(column1, columnCollection[0]);
            Assert.Equal(column2, columnCollection[1]);
        }

        [Fact]
        public void Add_ShouldAddColumn()
        {
            // Arrange
            var columnCollection = new ColumnCollection();
            var column = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);

            // Act
            columnCollection.Add(column);

            // Assert
            Assert.Equal(1, columnCollection.Count);
            Assert.Equal(column, columnCollection[0]);
        }

        [Fact]
        public void Add_ShouldThrowExceptionWhenColumnAlreadyExists()
        {
            // Arrange
            var column = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var columnCollection = new ColumnCollection(column);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => columnCollection.Add(column));
        }

        [Fact]
        public void AddRange_ShouldAddMultipleColumns()
        {
            // Arrange
            var columnCollection = new ColumnCollection();
            var column1 = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var column2 = new Column("Column2", typeof(int), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);

            // Act
            columnCollection.AddRange(new[] { column1, column2 });

            // Assert
            Assert.Equal(2, columnCollection.Count);
            Assert.Equal(column1, columnCollection[0]);
            Assert.Equal(column2, columnCollection[1]);
        }

        [Fact]
        public void Remove_ShouldRemoveColumnByName()
        {
            // Arrange
            var column = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var columnCollection = new ColumnCollection(column);

            // Act
            var result = columnCollection.Remove("Column1");

            // Assert
            Assert.True(result);
            Assert.Equal(0, columnCollection.Count);
        }

        [Fact]
        public void Remove_ShouldReturnFalseWhenColumnDoesNotExist()
        {
            // Arrange
            var columnCollection = new ColumnCollection();

            // Act
            var result = columnCollection.Remove("NonExistentColumn");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Contains_ShouldReturnTrueWhenColumnExists()
        {
            // Arrange
            var column = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var columnCollection = new ColumnCollection(column);

            // Act
            var result = columnCollection.Contains("Column1");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Contains_ShouldReturnFalseWhenColumnDoesNotExist()
        {
            // Arrange
            var columnCollection = new ColumnCollection();

            // Act
            var result = columnCollection.Contains("NonExistentColumn");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Clear_ShouldRemoveAllColumns()
        {
            // Arrange
            var column1 = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var column2 = new Column("Column2", typeof(int), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var columnCollection = new ColumnCollection(column1, column2);

            // Act
            columnCollection.Clear();

            // Assert
            Assert.Equal(0, columnCollection.Count);
        }

        [Fact]
        public void IndexOf_ShouldReturnCorrectIndex()
        {
            // Arrange
            var column1 = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var column2 = new Column("Column2", typeof(int), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var columnCollection = new ColumnCollection(column1, column2);

            // Act
            var index = columnCollection.IndexOf(column2);

            // Assert
            Assert.Equal(1, index);
        }

        [Fact]
        public void Clone_ShouldReturnExactCopy()
        {
            // Arrange
            var column1 = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var column2 = new Column("Column2", typeof(int), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var columnCollection = new ColumnCollection(column1, column2);

            // Act
            var clonedCollection = columnCollection.Clone();

            // Assert
            Assert.Equal(columnCollection.Count, clonedCollection.Count);
            Assert.Equal(columnCollection[0], clonedCollection[0]);
            Assert.Equal(columnCollection[1], clonedCollection[1]);
        }
    }
}
