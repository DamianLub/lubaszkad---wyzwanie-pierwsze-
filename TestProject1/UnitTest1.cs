namespace StringCalculator
{
    [TestClass]
    public class UnitTest1
    {
        public StringCalculator StringCalculator { get; set; }
        public UnitTest1()
        {
            StringCalculator = new StringCalculator();
        }

        [TestMethod]
        public void AnEmptyStringReturnsZero()
        {
            int result = StringCalculator.Calculate("");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void ASingleNumberReturnsTheValue()
        {
            int result = StringCalculator.Calculate("2");
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TwoNumbersCommaDelimitedReturnsTheSum()
        {
            int result = StringCalculator.Calculate("2,5");
            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        public void TwoNumbersNewLineDelimitedReturnsTheSum()
        {
            int result = StringCalculator.Calculate("2\n6");
            Assert.AreEqual(result, 8);
        }

        [TestMethod]
        public void ThreeNumbersCommaDelimitedReturnsTheSum1()
        {
            int result = StringCalculator.Calculate("2,5,7");
            Assert.AreEqual(result, 14);
        }

        [TestMethod]
        public void ThreeNumbersCommaDelimitedReturnsTheSum2()
        {
            int result = StringCalculator.Calculate("2,5\n7");
            Assert.AreEqual(result, 14);
        }

        [TestMethod]
        public void NegativeNumbersThrowAnExeption()
        {
            try
            {
                int result = StringCalculator.Calculate("2,-5,7");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Negative Number");
            }
        }

        [TestMethod]
        public void NumbersGreaterThanThousandAreIgnored()
        {
            int result = StringCalculator.Calculate("2,1001,3");
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void Newtoken()
        {
            int result = StringCalculator.Calculate("//$2$1001,3\n5");
            Assert.AreEqual(result, 10);
        }
    }
}