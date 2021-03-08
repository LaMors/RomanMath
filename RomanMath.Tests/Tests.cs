using NUnit.Framework;
using RomanMath.Impl;

namespace RomanMath.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void ValidationTestInvalidCharacter1()
		{
			var result = Service.Evaluate("IV+II/V");
			Assert.AreEqual(0, result);
		}

		[Test]
		public void ValidationTestInvalidCharacter2()
		{
			var result = Service.Evaluate("x+I");
			Assert.AreEqual(0, result);
		}

		[Test]
		public void ValidationTestNonMathematicalExpression1()
		{
			var result = Service.Evaluate("*M+XL");
			Assert.AreEqual(0, result);
		}

		[Test]
		public void ValidationTestNonMathematicalExpression2()
		{
			var result = Service.Evaluate("+");
			Assert.AreEqual(0, result);
		}

		[Test]
		public void ValidationTestEmptyLine()
		{
			var result = Service.Evaluate("");
			Assert.AreEqual(0, result);
		}


		[Test]
		public void EvaluateTestSoloNumber()
		{
			var result = Service.Evaluate("C");
			Assert.AreEqual(100, result);
		}

		[Test]
		public void EvaluateTest()
		{
			var result = Service.Evaluate("XXX+L");
			Assert.AreEqual(80, result);
		}

		[Test]
		public void EvaluateTestComplexAction1()
		{
			var result = Service.Evaluate("IV+II-X");
			Assert.AreEqual(-4, result);
		}

		[Test]
		public void EvaluateTestComplexAction2()
		{
			var result = Service.Evaluate("I+XXXI*X");
			Assert.AreEqual(311, result);
		}

		[Test]
		public void EvaluateTestSpacesBetweenCharacters()
		{
			var result = Service.Evaluate("XX+ L - II");
			Assert.AreEqual(68, result);
		}

		[Test]
		public void EvaluateTestNegativeNumber()
		{
			var result = Service.Evaluate("-C+L");
			Assert.AreEqual(-50, result);
		}

	}
}