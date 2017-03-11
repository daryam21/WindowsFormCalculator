using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApplicationWithTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplicationWithTests.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void btnResult_ClickTest1()
        {
            //Assign
            var result = 50;
            Form1 test = new Form1();  
            char operand = '+';
            List<String> testlist = new List<String>();

            testlist.Add("25");
            testlist.Add("15");

            string testlist2 = "10";
            
            //Act
            var tester4 = test.tester(operand, testlist, testlist2);
           
            
            //Assert
            Assert.AreEqual(tester4, result);
        }
    }
}