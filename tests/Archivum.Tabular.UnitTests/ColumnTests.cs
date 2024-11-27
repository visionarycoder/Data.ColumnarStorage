using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivum.Tabular;

namespace Archivum.Tabular.Tests
{
    [TestClass]
    public class ColumnTests
    {
        [TestMethod]
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
            Assert.AreEqual(columnName, column.ColumnName);
            Assert.AreEqual(dataType, column.DataType);
            Assert.IsTrue(column.ReadOnly);
            Assert.IsTrue(column.Unique);
            Assert.IsFalse(column.AllowDbNull);
        }

        [TestMethod]
        public void DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            // Act
            var column = new Column();

            // Assert
            Assert.AreEqual(string.Empty, column.ColumnName);
            Assert.AreEqual(typeof(object), column.DataType);
            Assert.IsFalse(column.ReadOnly);
            Assert.IsFalse(column.Unique);
            Assert.IsTrue(column.AllowDbNull);
            Assert.AreEqual(-1, column.MaxLength);
            Assert.AreEqual(string.Empty, column.DefaultValue);
        }

        [TestMethod]
        public void Constructor_WithColumnName_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            var columnName = "TestColumn";

            // Act
            var column = new Column(columnName);

            // Assert
            Assert.AreEqual(columnName, column.ColumnName);
            Assert.AreEqual(typeof(object), column.DataType);
            Assert.IsFalse(column.ReadOnly);
            Assert.IsFalse(column.Unique);
            Assert.IsTrue(column.AllowDbNull);
            Assert.AreEqual(-1, column.MaxLength);
            Assert.AreEqual(string.Empty, column.DefaultValue);
        }

        [TestMethod]
        public void Constructor_WithColumnNameAndDataType_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            var columnName = "TestColumn";
            var dataType = typeof(int);

            // Act
            var column = new Column(columnName, dataType);

            // Assert
            Assert.AreEqual(columnName, column.ColumnName);
            Assert.AreEqual(dataType, column.DataType);
            Assert.IsFalse(column.ReadOnly);
            Assert.IsFalse(column.Unique);
            Assert.IsTrue(column.AllowDbNull);
            Assert.AreEqual(-1, column.MaxLength);
            Assert.AreEqual(string.Empty, column.DefaultValue);
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Arrange
            var columnName = "TestColumn";
            var dataType = typeof(int);
            var column = new Column(columnName, dataType);

            // Act
            var result = column.ToString();

            // Assert
            Assert.AreEqual("TestColumn (Int32)", result);
        }
    }
}
