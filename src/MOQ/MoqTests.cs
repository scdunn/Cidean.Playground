using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MocksWithMoq
{

    /// <summary>
    /// Quote Service Interface
    /// </summary>
    public interface IQuoteService
    {
        double GetQuote(int age, char gender, bool smoker);
    }

    /// <summary>
    /// Concrete implementation of IQuoteService
    /// </summary>
    public class QuoteService : IQuoteService
    {
        /// <summary>
        /// returns monthly rate quote given parameters of principal
        /// </summary>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="smoker"></param>
        /// <returns></returns>
        public double GetQuote(int age, char gender, bool smoker)
        {
            //base rate
            double quoteRate = 10;

            //rate modifiers
            if (age >= 40) quoteRate *= 1.1;
            if (gender == 'M') quoteRate *= 1.2;
            if (smoker) quoteRate *= 2;

            //return quote
            return quoteRate;
        }
    }

    /// <summary>
    /// Wrapper class that calls Quote Service
    /// </summary>
    public class QuoteManager
    {
        private IQuoteService _service;
        
        //injects quote service dependency
        public QuoteManager(IQuoteService service)
        {
            _service = service;
        }

        /// <summary>
        /// returns monthly rate quote given parameters of principal
        /// </summary>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="smoker"></param>
        /// <returns></returns>
        public double GetQuote(int age, char gender, bool smoker)
        {
            //calls Quote Service
            return _service.GetQuote(age, gender, smoker);

        }


    }

    /// <summary>
    /// Test Class for Mocks
    /// </summary>
    [TestClass]
    public class MoqTests
    {
               
        [DataTestMethod]
        [DataRow(30,'M',false,12)]
        public void GetQuote_ApprovedParams_ValidQuote(int age, char gender, bool smoker, int result)
        {
                //arrange
                var mock = new Mock<IQuoteService>();
                mock.Setup(m => m.GetQuote(30, 'M', false)).Returns(12);

                IQuoteService service = mock.Object;

            //act
                QuoteManager quoteManager = new QuoteManager(service);
                var quote = quoteManager.GetQuote(age, gender, smoker);

                //assert
                Assert.AreEqual(result, quote);

        }


    }
}
