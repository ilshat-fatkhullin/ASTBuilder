using ASTBuilder.AST;
using ASTBuilder.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASTBuilderTest
{
    [TestClass]
    public class Test
    {
        string GetResult(string content)
        {
            Parser parser = new Parser(content);
            Expression e = parser.Parse();
            return e.GetResult().ToString();
        }

        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("3", GetResult("1+2"));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("-1", GetResult("1-2"));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("7", GetResult("1+2*3"));
        }

        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual("1", GetResult("1<2"));
        }

        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual("1", GetResult("1=1"));
        }

        [TestMethod]
        public void Test6()
        {
            Assert.AreEqual("1", GetResult("2>1"));
        }

        [TestMethod]
        public void Test7()
        {
            Assert.AreEqual("0", GetResult("2<1"));
        }

        [TestMethod]
        public void Test8()
        {
            Assert.AreEqual("0", GetResult("1=2"));
        }

        [TestMethod]
        public void Test9()
        {
            Assert.AreEqual("0", GetResult("1>2"));
        }

        [TestMethod]
        public void Test10()
        {
            Assert.AreEqual("1", GetResult("6*(3+2)=30"));
        }

        [TestMethod]
        public void Test11()
        {
            Assert.AreEqual("1", GetResult("(3+2)=5"));
        }

        [TestMethod]
        public void Test12()
        {
            Assert.AreEqual("1", GetResult("(3+2)-2=3"));
        }

        [TestMethod]
        public void Test13()
        {
            Assert.AreEqual("1", GetResult("((3)+2)-2=3"));
        }

        [TestMethod]
        public void Test14()
        {
            Assert.AreEqual("5", GetResult("(3)+(2)"));
        }

        [TestMethod]
        public void Test15()
        {
            Assert.AreEqual("2", GetResult("(3>2)+(2<3)"));
        }
    }
}
