using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ArrayGenerator.UnitTests
{
	[TestFixture]
	public class GlobalsFixture
	{
		[Test]
		public void GlobalsTenThousandItemArraySorted_IsCorrectLength()
		{
			Assert.IsTrue(Globals.TenThousandItemArraySorted.Length == Globals.ArrayLength);
		}

		[Test]
		public void GlobalsTenThousandItemArraySorted_SmallestNumberIsCorrect()
		{
			Assert.IsTrue(Globals.TenThousandItemArraySorted[0] == Globals.SmallestNumber);
		}

		[Test]
		public void GlobalsTenThousandItemArraySorted_LargestNumberIsCorrect()
		{
			Assert.IsTrue(Globals.TenThousandItemArraySorted.Last() == Globals.LargestNumber);
		}

		[Test]
		public void GlobalsTenThousandItemArraySorted_IsCorrectlySorted()
		{
			Utils.VerifyArrayIsSortedFromMinimumNumberToMaximumNumber(Globals.SmallestNumber, Globals.LargestNumber, Globals.TenThousandItemArraySorted);
		}

		[Test]
		public void GlobalsSmallestNumber_IsSmallerThanGlobalsLargestNumber()
		{
			Assert.IsTrue(Globals.SmallestNumber < Globals.LargestNumber);
		}
	}
}
