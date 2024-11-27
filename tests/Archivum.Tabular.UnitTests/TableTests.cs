using Xunit;
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Archivum.Tabular.UnitTests;


public class TableTests
{
    [Fact]
    public void AddColumn_ShouldAddColumn()
    {
        // Arrange
        var table = new Table("TestTable");
        var column = new Column("Column1");

        // Act
        table.AddColumn(column);

        // Assert
        Assert.Equal(1, table.Columns.Count);
        Assert.Equal(column, table.Columns[0]);
    }

    [Fact]
    public void NewRow_ShouldReturnNewRow()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"));

        // Act
        var row = table.NewRow();

        // Assert
        Assert.NotNull(row);
        Assert.Equal(table, row.GetType().GetField("table", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(row));
    }

    [Fact]
    public void AddRow_ShouldAddRowToTable()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"));
        var row = table.NewRow();

        // Act
        table.AddRow(row);

        // Assert
        Assert.Equal(1, table.Rows.Count);
        Assert.Equal(row, table.Rows[0]);
    }

    [Fact]
    public void AddRow_ShouldThrowExceptionWhenRowBelongsToAnotherTable()
    {
        // Arrange
        var table1 = new Table("TestTable1", new Column("Column1"));
        var table2 = new Table("TestTable2", new Column("Column1"));
        var row = table1.NewRow();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => table2.AddRow(row));
    }

    [Fact]
    public void GetColumnIndex_ShouldReturnCorrectIndex()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"), new Column("Column2"));

        // Act
        var index = table.GetColumnIndex("Column2");

        // Assert
        Assert.Equal(1, index);
    }

    [Fact]
    public void Get_ShouldReturnCorrectValue()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"));
        var row = table.NewRow();
        table.AddRow(row);
        row[0] = "TestValue";

        // Act
        var value = table.Get(0, 0);

        // Assert
        Assert.Equal("TestValue", value);
    }

    [Fact]
    public void Get_ShouldThrowExceptionWhenValueIsNotSet()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"));
        var row = table.NewRow();
        table.AddRow(row);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => table.Get(0, 0));
    }

    [Fact]
    public void Set_ShouldSetCorrectValue()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"));
        var row = table.NewRow();
        table.AddRow(row);

        // Act
        table.Set(0, 0, "TestValue");

        // Assert
        Assert.Equal("TestValue", row[0]);
    }
}
