using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivum.Tabular;
using Archivum.Nucleus;

namespace Archivum.Tabular.Tests
{
    [TestClass]
    public class RecordTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var builder = new RecordBuilder { Name = "TestRecord", Value = "TestValue" };

            // Act
            var record = new Record(builder);

            // Assert
            Assert.AreEqual("TestRecord", record.Name);
            Assert.AreEqual("TestValue", record.Value);
        }

        [TestMethod]
        public void Value_ShouldReturnNullWhenDataIdIsNull()
        {
            // Arrange
            var builder = new RecordBuilder { Name = "TestRecord" };
            var record = new Record(builder);

            // Act
            var value = record.Value;

            // Assert
            Assert.IsNull(value);
        }

        [TestMethod]
        public void Value_ShouldReturnStoredValue()
        {
            // Arrange
            var builder = new RecordBuilder { Name = "TestRecord", Value = "TestValue" };
            var record = new Record(builder);

            // Act
            var value = record.Value;

            // Assert
            Assert.AreEqual("TestValue", value);
        }

        [TestMethod]
        public void IsNull_ShouldReturnTrueWhenValueIsNull()
        {
            // Arrange
            var builder = new RecordBuilder { Name = "TestRecord" };
            var record = new Record(builder);

            // Act
            var isNull = record.IsNull;

            // Assert
            Assert.IsTrue(isNull);
        }

        [TestMethod]
        public void IsNull_ShouldReturnFalseWhenValueIsNotNull()
        {
            // Arrange
            var builder = new RecordBuilder { Name = "TestRecord", Value = "TestValue" };
            var record = new Record(builder);

            // Act
            var isNull = record.IsNull;

            // Assert
            Assert.IsFalse(isNull);
        }

        [TestMethod]
        public void GetValue_ShouldReturnCorrectValue()
        {
            // Arrange
            var builder = new RecordBuilder { Name = "TestRecord", Value = "TestValue" };
            var record = new Record(builder);

            // Act
            var value = record.GetValue();

            // Assert
            Assert.AreEqual("TestValue", value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetValue_ShouldThrowExceptionWhenValueIsNull()
        {
            // Arrange
            var builder = new RecordBuilder { Name = "TestRecord" };
            var record = new Record(builder);

            // Act
            record.GetValue();
        }

        [TestMethod]
        public void GetValueT_ShouldReturnCorrectValue()
        {
            // Arrange
            var builder = new RecordBuilder { Name = "TestRecord", Value = 123 };
            var record = new Record(builder);

            // Act
            var value = record.GetValue<int>();

            // Assert
            Assert.AreEqual(123, value);
        }

        [TestMethod]
        public void Dispose_ShouldReleaseResources()
        {
            // Arrange
            var builder = new RecordBuilder { Name = "TestRecord", Value = "TestValue" };
            var record = new Record(builder);

            // Act
            record.Dispose();

            // Assert
            Assert.IsTrue(record.IsNull);
        }
    }
}
