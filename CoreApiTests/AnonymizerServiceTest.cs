using CoreApiTests.Model;
using CoreService.Anonimyzer;

namespace CoreApiTests
{
    [TestClass]
    public class AnonymizerServiceTest
    {
        [TestMethod]
        public void TestAnonymizeComplexObject()
        {
            // Given
            var model = new TestAnonymizeComplexObjectModel()
            {
                StringProperty = "testUserName",
                DecimalProperty = 5.3M,
                DateTimeProperty = DateTime.Now
            };

            var anonymizer = new AnonymizerService();

            // When
            var result = anonymizer.AnonymizeEntity(model);

            // Then
            Assert.IsNotNull(result);
            Assert.AreEqual("XXXXXXXXXXXX", result.StringProperty);
            Assert.AreEqual(0M, result.DecimalProperty);
            Assert.AreEqual(new DateTime(2000, 1, 1), result.DateTimeProperty);
        }

        [TestMethod]
        public void TestAnonymizeDecimalObject()
        {
            // Given
            decimal decimalValue = 5.3M;

            var anonymizer = new AnonymizerService();

            // When
            var result = anonymizer.AnonymizeEntity(decimalValue);

            // Then
            Assert.AreEqual(0M, result);
        }

        [TestMethod]
        public void TestAnonymizeDateTimeObject()
        {
            // Given
            DateTime dateTimeValue = DateTime.Now;

            var anonymizer = new AnonymizerService();

            // When
            var result = anonymizer.AnonymizeEntity(dateTimeValue);

            // Then
            Assert.AreEqual(new DateTime(2000, 1, 1), result);
        }

        [TestMethod]
        public void TestAnonymizeStringObject()
        {
            // Given
            string stringValue = "arroz";

            var anonymizer = new AnonymizerService();

            // When
            var result = anonymizer.AnonymizeEntity(stringValue);

            // Then
            Assert.AreEqual("XXXXX", result);
        }
    }
}
