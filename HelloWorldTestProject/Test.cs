using NUnit.Framework;
using System;
using HelloWorldClassLibrary; 

namespace HelloWorldTestProject
{
    [TestFixture]
    public class Test
    {

        FileDataModel model = new FileDataModel();
        FileDataService service = new FileDataService();
		
        #region Tests

        /// <summary>
        /// Test to determine if the data returned as output matches the expected output
        /// </summary>

        [TestCase]
        public void HelloWorldEqualTest()
        {
            service.ReadData();
            string data = service.DisplayData();
            Assert.AreEqual(data, "Hello World");
        }


        /// <summary>
        /// Test to determine that data returned is not null
        /// </summary>

        [TestCase]
        public void NotNullTest()
        {
            service.ReadData();
            string data = service.DisplayData();
            Assert.NotNull(data);
        }
        #endregion


    }
}
