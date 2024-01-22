using Coder;
using Coder.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System;

namespace CoderTest
{
    [TestClass]
    public class Base64Test
    {
        
        [TestMethod]
        public void test_base64code_1()
        {

            var loggerMock = new Mock<ILogger<Base64CodeController>>();
            Base64CodeController controller = new Base64CodeController(loggerMock.Object);

            String codedText = controller.Get("hello world");

            bool correctCoding = false;

            if (codedText.Equals("aGVsbG8gd29ybGQ=")) { correctCoding = true; }

            Assert.IsTrue(correctCoding);

        }

        [TestMethod]
        public void test_base64code_2()
        {

            var loggerMock = new Mock<ILogger<Base64CodeController>>();
            Base64CodeController controller = new Base64CodeController(loggerMock.Object);

            String codedText = controller.Get("this is a test");

            bool correctCoding = false;

            if (codedText.Equals("dGhpcyBpcyBhIHRlc3Q=")) { correctCoding = true; }

            Assert.IsTrue(correctCoding);

        }

        [TestMethod]
        public void test_base64decode_1()
        {

            var loggerMock = new Mock<ILogger<Base64DecodeController>>();
            Base64DecodeController controller = new Base64DecodeController(loggerMock.Object);

            String decodedText = controller.Get("aGVsbG8gd29ybGQ=");

            bool correctDecoding = false;

            if (decodedText.Equals("hello world")) { correctDecoding = true; }

            Assert.IsTrue(correctDecoding);

        }

        [TestMethod]
        public void test_base64decode_2()
        {

            var loggerMock = new Mock<ILogger<Base64DecodeController>>();
            Base64DecodeController controller = new Base64DecodeController(loggerMock.Object);

            String decodedText = controller.Get("dGhpcyBpcyBhIHRlc3Q=");

            bool correctDecoding = false;

            if (decodedText.Equals("this is a test")) { correctDecoding = true; }

            Assert.IsTrue(correctDecoding);

        }

    }
}