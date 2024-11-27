using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivum.Tabular;

namespace Archivum.Tabular.Tests
{
    [TestClass]
    public class ColumnCollectionTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeWithGivenColumns()
        {
            // Arrange
            var column1 = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var column2 = new Column("Column2", typeof(int), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);

            // Act
            var columnCollection = new ColumnCollection(column1, column2);

            // Assert
            Assert.AreEqual(2, columnCollection.Count);
            Assert.AreEqual(column1, columnCollection[0]);
            Assert.AreEqual(column2, columnCollection[1]);
        }

        [TestMethod]
        public void Add_ShouldAddColumn()
        {
            // Arrange
            var columnCollection = new ColumnCollection();
            var column = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);

            // Act
            columnCollection.Add(column);

            // Assert
            Assert.AreEqual(1, columnCollection.Count);
            Assert.AreEqual(column, columnCollection[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_ShouldThrowExceptionWhenColumnAlreadyExists()
        {
            // Arrange
            var column = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var columnCollection = new ColumnCollection(column);

            // Act
            columnCollection.Add(column);
        }

        [TestMethod]
        public void AddRange_ShouldAddMultipleColumns()
        {
            // Arrange
            var columnCollection = new ColumnCollection();
            var column1 = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var column2 = new Column("Column2", typeof(int), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);

            // Act
            columnCollection.AddRange(new[] { column1, column2 });

            // Assert
            Assert.AreEqual(2, columnCollection.Count);
            Assert.AreEqual(column1, columnCollection[0]);
            Assert.AreEqual(column2, columnCollection[1]);
        }

        [TestMethod]
        public void Remove_ShouldRemoveColumnByName()
        {
            // Arrange
            var column = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var columnCollection = new ColumnCollection(column);

            // Act
            var result = columnCollection.Remove("Column1");

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, columnCollection.Count);
        }

        [TestMethod]
        public void Remove_ShouldReturnFalseWhenColumnDoesNotExist()
        {
            // Arrange
            var columnCollection = new ColumnCollection();

            // Act
            var result = columnCollection.Remove("NonExistentColumn");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_ShouldReturnTrueWhenColumnExists()
        {
            // Arrange
            var column = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var columnCollection = new ColumnCollection(column);

            // Act
            var result = columnCollection.Contains("Column1");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Contains_ShouldReturnFalseWhenColumnDoesNotExist()
        {
            // Arrange
            var columnCollection = new ColumnCollection();

            // Act
            var result = columnCollection.Contains("NonExistentColumn");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Clear_ShouldRemoveAllColumns()
        {
            // Arrange
            var column1 = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var column2 = new Column("Column2", typeof(int), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var columnCollection = new ColumnCollection(column1, column2);

            // Act
            columnCollection.Clear();

            // Assert
            Assert.AreEqual(0, columnCollection.Count);
        }

        [TestMethod]
        public void IndexOf_ShouldReturnCorrectIndex()
        {
            // Arrange
            var column1 = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var column2 = new Column("Column2", typeof(int), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var columnCollection = new ColumnCollection(column1, column2);

            // Act
            var index = columnCollection.IndexOf(column2);

            // Assert
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void Clone_ShouldReturnExactCopy()
        {
            // Arrange
            var column1 = new Column("Column1", typeof(string), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var column2 = new Column("Column2", typeof(int), IsReadOnlyValue.No, IsUniqueValue.No, AllowDbNullValue.Yes);
            var columnCollection = new ColumnCollection(column1, column2);

            // Act
            var clonedCollection = columnCollection.Clone();

            // Assert
            Assert.AreEqual(columnCollection.Count, clonedCollection.Count);
            Assert.AreEqual(columnCollection[0], clonedCollection[0]);
            Assert.AreEqual(columnCollection[1], clonedCollection[1]);
        }
    }
}
