using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ArrayGenerator.UnitTests
{
	public static class Utils
	{
		/// <summary>
		/// Asserts the Array is Sorted From the Minimum Number to the Maximum Number
		/// </summary>
		/// <param name="minimumNumber">The smallest number in the array</param>
		/// <param name="maximumNumber">The largest number in the array</param>
		/// <param name="array">The array to verify</param>
		public static void VerifyArrayIsSortedFromMinimumNumberToMaximumNumber(int minimumNumber, int maximumNumber, IEnumerable<int> array)
		{
			var index = 0;
			for (var i = minimumNumber; i <= maximumNumber; i++)
			{
				Assert.AreEqual(array.ElementAt(index), i);
				index++;
			}
		}

		/// <summary>
		/// Verifies array is equal to array2
		/// </summary>
		/// <param name="array">An array</param>
		/// <param name="array2">Another array</param>
		public static void VerifyArraysAreEqual(IEnumerable<int> array, IEnumerable<int> array2)
		{
			Assert.IsTrue(array.SequenceEqual(array2));
		}

		/// <summary>
		/// Verifies array is not equal to array2
		/// </summary>
		/// <param name="array">An array</param>
		/// <param name="array2">Another array</param>
		public static void VerifyArraysAreNotEqual(IEnumerable<int> array, IEnumerable<int> array2)
		{
			Assert.IsFalse(array.SequenceEqual(array2));
		}

		/// <summary>
		/// Verifies array is not sorted
		/// </summary>
		/// <param name="array">An array</param>
		/// <param name="array2">Another array</param>
		public static void VerifyArraysIsNotSorted(IEnumerable<int> array)
		{
			var isSorted = true;
			for (var i = 1; i < array.Count(); i++)
			{
				if (array.ElementAt(i) < array.ElementAt(i-1))
				{
					isSorted = false;
					break;
				}
			}
			Assert.IsFalse(isSorted);
		}
	}
}
