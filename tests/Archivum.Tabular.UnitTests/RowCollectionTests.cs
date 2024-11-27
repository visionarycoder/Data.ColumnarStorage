[TestClass]
public class RowCollectionTests
{
    [TestMethod]
    public void Add_ShouldAddRow()
    {
        // Arrange
        var collection = new RowCollection();
        var table = new Table("TestTable");
        var row = new Row(table, new ColumnCollection());

        // Act
        collection.Add(row);

        // Assert
        Assert.AreEqual(1, collection.Count);
        Assert.AreEqual(row, collection[0]);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Add_ShouldThrowExceptionWhenRowAlreadyExists()
    {
        // Arrange
        var collection = new RowCollection();
        var table = new Table("TestTable");
        var row = new Row(table, new ColumnCollection());

        // Act
        collection.Add(row);
        collection.Add(row);
    }

    [TestMethod]
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
        Assert.AreEqual(1, index);
    }
}
