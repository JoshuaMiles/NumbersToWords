using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersToWords;
using NumbersToWords.Controllers;


namespace NumbersToWords.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void NumbersToWordsDoubleDigitTest()
        {
            //Arrange 
            decimal test = 22.03m;
            //Assert
            Assert.AreEqual("TWENTY-TWO DOLLARS AND THREE CENTS",Helper.NumbersToWords(test));
        }

        [TestMethod]

        public void NumbersToWordsDoubleDigitTest2()
        {
            //Arrange 
            decimal test = 20.03m;
            //Assert
            Assert.AreEqual("TWENTY DOLLARS AND THREE CENTS", Helper.NumbersToWords(test));
        }

        [TestMethod]

        public void NumbersToWordsDoubleDigitTest3()
        {
            //Arrange 
            decimal test = 15.03m;
            //Assert
            Assert.AreEqual("FIFTEEN DOLLARS AND THREE CENTS", Helper.NumbersToWords(test));
        }

        [TestMethod]

        public void NumbersToWordsDoubleDigitTest4()
        {
            //Arrange 
            decimal test = 11.03m;
            //Assert
            Assert.AreEqual("ELEVEN DOLLARS AND THREE CENTS", Helper.NumbersToWords(test));
        }
        [TestMethod]

        public void NumbersToWordsSingleDigit()
        {
            //Arrange 
            decimal test = 9.03m;
            //Assert
            Assert.AreEqual("NINE DOLLARS AND THREE CENTS", Helper.NumbersToWords(test));
        }

        [TestMethod]

        public void NumbersToWordsSingleDigit2()
        {
            //Arrange 
            decimal test = 10.03m;
            //Assert
            Assert.AreEqual("TEN DOLLARS AND THREE CENTS", Helper.NumbersToWords(test));
        }

        [TestMethod]
        public void NumbersToWordsHundreds()
        {
            //Arrange 
            decimal test = 125.03m;
            //Assert
            Assert.AreEqual("ONE HUNDRED AND TWENTY-FIVE DOLLARS AND THREE CENTS", Helper.NumbersToWords(test));
        }

        [TestMethod]
        public void NumbersToWordsHundreds2()
        {
            //Arrange 
            decimal test = 111.03m;
            //Assert
            Assert.AreEqual("ONE HUNDRED AND ELEVEN DOLLARS AND THREE CENTS", Helper.NumbersToWords(test));
        }

        [TestMethod]
        public void NumbersToWordsHundreds3()
        {
            //Arrange 
            decimal test = 999.03m;
            //Assert
            Assert.AreEqual("NINE HUNDRED AND NINETY-NINE DOLLARS AND THREE CENTS", Helper.NumbersToWords(test));
        }

        [TestMethod]
        public void NumbersToWordsThousands()
        {
            //Arrange 
            decimal test = 1999.03m;
            //Assert
            Assert.AreEqual("ONE THOUSAND AND NINE HUNDRED AND NINETY-NINE DOLLARS AND THREE CENTS", Helper.NumbersToWords(test));
        }
        [TestMethod]
        public void NumbersToWordsMillions()
        {
            //Arrange 
            decimal test = 1999936.03m;
            //Assert
            Assert.AreEqual("ONE MILLION AND NINE HUNDRED AND NINETY-NINE THOUSAND AND NINE HUNDRED AND THIRTY-SIX DOLLARS AND THREE CENTS", Helper.NumbersToWords(test));
        }


        [TestMethod]
        public void NumbersToWordsMillions2()
        {
            //Arrange 
            decimal test = 1099036.03m;
            //Assert
            Assert.AreEqual("ONE MILLION AND NINETY-NINE THOUSAND AND THIRTY-SIX DOLLARS AND THREE CENTS", Helper.NumbersToWords(test));
        }


        [TestMethod]
        public void NumbersToWordsBillions()
        {
            //Arrange 
            decimal test = 1111099036.03m;
            //Assert
            Assert.AreEqual("ONE BILLION AND ONE HUNDRED AND ELEVEN MILLION AND NINETY-NINE THOUSAND AND THIRTY-SIX DOLLARS AND THREE CENTS", Helper.NumbersToWords(test));
        }


        [TestMethod]
        public void NumbersToWordsBillions2()
        {
            //Arrange 
            decimal test = 1001001001.03m;
            //Assert
            Assert.AreEqual("ONE BILLION AND ONE MILLION AND ONE THOUSAND AND ONE DOLLARS AND THREE CENTS", Helper.NumbersToWords(test));
        }

       
        [TestMethod]
        public void NumbersToWordsDecimal()
        {
            //Arrange 
            decimal test = 12.5m;
            //Assert
            Assert.AreEqual("TWELVE DOLLARS AND FIFTY CENTS", Helper.NumbersToWords(test));
        }

        [TestMethod]
        public void NumbersToWordsDecimal2()
        {
            //Arrange 
            decimal test = 12.50m;
            //Assert
            Assert.AreEqual("TWELVE DOLLARS AND FIFTY CENTS", Helper.NumbersToWords(test));
        }

        [TestMethod]
        public void NumbersToWordsDecimal3()
        {
            //Arrange 
            decimal test = 10.07m;
            //Assert
            Assert.AreEqual("TEN DOLLARS AND SEVEN CENTS", Helper.NumbersToWords(test));
        }

        [TestMethod]
        public void NumbersToWordsDecimal4()
        {
            //Arrange 
            decimal test = 10.22m;
            //Assert
            Assert.AreEqual("TEN DOLLARS AND TWENTY-TWO CENTS", Helper.NumbersToWords(test));
        }

        [TestMethod]
        public void NumbersToWordsDecimal5()
        {
            //Arrange 
            decimal test = 10.62m;
            //Assert
            Assert.AreEqual("TEN DOLLARS AND SIXTY-TWO CENTS", Helper.NumbersToWords(test));
        }

        [TestMethod]
        public void NumbersToWordsZero()
        {
            //Arrange 
            decimal test = 100000000000000000m;
            //Assert
            Assert.AreEqual("ONE HUNDRED QUADRILLION DOLLARS", Helper.NumbersToWords(test));
        }

        [TestMethod]
        public void NumbersToWordsZero1()
        {
            //Arrange 
            decimal test = 100000000100000001m;
            //Assert
            Assert.AreEqual("ONE HUNDRED QUADRILLION AND ONE HUNDRED MILLION AND ONE DOLLARS", Helper.NumbersToWords(test));
        }


        [TestMethod]
        public void NumbersToWordsZero2()
        {
            //Arrange 
            decimal test = 200000;
            //Assert
            Assert.AreEqual("TWO HUNDRED THOUSAND DOLLARS", Helper.NumbersToWords(test));
        }

        [TestMethod]
        public void NumbersToWordsZero3()
        {
            //Arrange 
            decimal test = 200004;
            //Assert
            Assert.AreEqual("TWO HUNDRED THOUSAND AND FOUR DOLLARS", Helper.NumbersToWords(test));
        }



    }


}
