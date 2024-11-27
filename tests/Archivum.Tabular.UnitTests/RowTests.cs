using Xunit;

namespace Archivum.Tabular.UnitTests;


public class RowTests
{
    [Fact]
    public void Indexer_ShouldGetAndSetValues()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"));
        var row = new Row(table, table.Columns);
        table.AddRow(row);

        // Act
        row[0] = "TestValue";

        // Assert
        Assert.Equal("TestValue", row[0]);
    }

    [Fact]
    public void IndexerByName_ShouldGetAndSetValues()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"));
        var row = new Row(table, table.Columns);
        table.AddRow(row);

        // Act
        row["Column1"] = "TestValue";

        // Assert
        Assert.Equal("TestValue", row["Column1"]);
    }
}