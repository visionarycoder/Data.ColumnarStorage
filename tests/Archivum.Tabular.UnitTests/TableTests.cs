[TestClass]
public class TableTests
{
    [TestMethod]
    public void AddColumn_ShouldAddColumn()
    {
        // Arrange
        var table = new Table("TestTable");
        var column = new Column("Column1");

        // Act
        table.AddColumn(column);

        // Assert
        Assert.AreEqual(1, table.Columns.Count);
        Assert.AreEqual(column, table.Columns[0]);
    }

    [TestMethod]
    public void NewRow_ShouldReturnNewRow()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"));

        // Act
        var row = table.NewRow();

        // Assert
        Assert.IsNotNull(row);
        Assert.AreEqual(table, row.GetType().GetField("table", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(row));
    }

    [TestMethod]
    public void AddRow_ShouldAddRowToTable()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"));
        var row = table.NewRow();

        // Act
        table.AddRow(row);

        // Assert
        Assert.AreEqual(1, table.Rows.Count);
        Assert.AreEqual(row, table.Rows[0]);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AddRow_ShouldThrowExceptionWhenRowBelongsToAnotherTable()
    {
        // Arrange
        var table1 = new Table("TestTable1", new Column("Column1"));
        var table2 = new Table("TestTable2", new Column("Column1"));
        var row = table1.NewRow();

        // Act
        table2.AddRow(row);
    }

    [TestMethod]
    public void GetColumnIndex_ShouldReturnCorrectIndex()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"), new Column("Column2"));

        // Act
        var index = table.GetColumnIndex("Column2");

        // Assert
        Assert.AreEqual(1, index);
    }

    [TestMethod]
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
        Assert.AreEqual("TestValue", value);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Get_ShouldThrowExceptionWhenValueIsNotSet()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"));
        var row = table.NewRow();
        table.AddRow(row);

        // Act
        table.Get(0, 0);
    }

    [TestMethod]
    public void Set_ShouldSetCorrectValue()
    {
        // Arrange
        var table = new Table("TestTable", new Column("Column1"));
        var row = table.NewRow();
        table.AddRow(row);

        // Act
        table.Set(0, 0, "TestValue");

        // Assert
        Assert.AreEqual("TestValue", row[0]);
    }
}
