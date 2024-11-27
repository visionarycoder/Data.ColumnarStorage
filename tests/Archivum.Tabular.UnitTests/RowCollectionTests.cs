using Xunit;

namespace Archivum.Tabular.UnitTests;

public class RowCollectionTests
{
    [Fact]
    public void Add_ShouldAddRow()
    {
        // Arrange
        var collection = new RowCollection();
        var table = new Table("TestTable");
        var row = new Row(table, new ColumnCollection());

        // Act
        collection.Add(row);

        // Assert
        Assert.Equal(1, collection.Count);
        Assert.Equal(row, collection[0]);
    }

    [Fact]
    public void Add_ShouldThrowExceptionWhenRowAlreadyExists()
    {
        // Arrange
        var collection = new RowCollection();
        var table = new Table("TestTable");
        var row = new Row(table, new ColumnCollection());

        // Act
        collection.Add(row);

        // Assert
        Assert.Throws<InvalidOperationException>(() => collection.Add(row));
    }

    [Fact]
    public void IndexOf_ShouldReturnCorrectIndex()
    {
        // Arrange
        var collection = new RowCollection();
        var table = new Table("TestTable");
        var row1 = new Row(table, new ColumnCollection());
        var row2 = new Row(table, new ColumnCollection());

        collection.Add(row1);
        collection.Add(row2);

        // Act
        var index = collection.IndexOf(row2);

        // Assert
        Assert.Equal(1, index);
    }
}
