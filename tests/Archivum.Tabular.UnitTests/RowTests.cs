[TestClass]
public class RowTests
{
    [TestMethod]
    public void Indexer_ShouldGetAndSetValues()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"));
        var row = new Row(table, table.Columns);
        table.AddRow(row);

        // Act
        row[0] = "TestValue";

        // Assert
        Assert.AreEqual("TestValue", row[0]);
    }

    [TestMethod]
    public void IndexerByName_ShouldGetAndSetValues()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"));
        var row = new Row(table, table.Columns);
        table.AddRow(row);

        // Act
        row["Column1"] = "TestValue";

        // Assert
        Assert.AreEqual("TestValue", row["Column1"]);
    }
}
