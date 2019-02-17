using System;
using System.Collections.Generic;
using System.Linq;
using ArrayGenerator.Services;
using ArrayGenerator.Services.Interfaces;
using NUnit.Framework;

namespace ArrayGenerator.UnitTests.Services
{
	[TestFixture]
	public class SortedArrayServiceFixture
	{
		private ISortedArrayService _sortedArrayService;

		[SetUp]
		public void SetUp()
		{
			_sortedArrayService = new SortedArrayService();
		}

		[Test]
		public void GetArray_ShouldThrowAnError_WhenMaximumNumberSmallerThanMinimumNumber()
		{
			Assert.Throws<Exception>(() => _sortedArrayService.GetArray(2,1));
		}

		[Test]
		public void GetArray_ShouldThrowAnError_WhenMaximumNegativeNumberSmallerThanMinimumNumber()
		{
			Assert.Throws<Exception>(() => _sortedArrayService.GetArray(-13, -52));
		}

		[Test]
		public void GetArray_ReturnsArrayWithOneNumber_WhenCalledWithOneNumber()
		{
			// Arrange/Act
			var array = _sortedArrayService.GetArray(254, 254);

			// Assert
			Assert.IsTrue(array.ToList().Count == 1);
			Assert.IsTrue(array.ElementAt(0) == 254);
		}

		[Test]
		public void GetArray_ReturnsCorrectSortedArray_WhenCalledWithSmallRange()
		{
			// Arrange/Act
			var array = _sortedArrayService.GetArray(8, 15);

			// Assert
			Assert.AreEqual(array.ElementAt(0), 8);
			Assert.AreEqual(array.ElementAt(1), 9);
			Assert.AreEqual(array.ElementAt(2), 10);
			Assert.AreEqual(array.ElementAt(3), 11);
			Assert.AreEqual(array.ElementAt(4), 12);
			Assert.AreEqual(array.ElementAt(5), 13);
			Assert.AreEqual(array.ElementAt(6), 14);
			Assert.AreEqual(array.ElementAt(7), 15);
		}

		[Test]
		public void GetArray_ReturnsShuffledGlobalsArray_WhenCalledWithGlobalsSmallestNumberToLargestNumber()
		{
			// Arrange/Act
			var array = _sortedArrayService.GetArray(Globals.SmallestNumber, Globals.LargestNumber);

			// Assert
			Utils.VerifyArraysAreEqual(array, Globals.TenThousandItemArraySorted);
		}

		[Test]
		public void GetArray_ReturnsCorrectSortedArray_WhenCalledWithNegativeRange()
		{
			// Arrange
			const int minimumNumber = -275;
			const int maximumNumber = -35;

			// Act
			var array = _sortedArrayService.GetArray(minimumNumber, maximumNumber);

			// Assert
			Utils.VerifyArrayIsSortedFromMinimumNumberToMaximumNumber(minimumNumber, maximumNumber, array);
		}

		[Test]
		public void GetArray_ReturnsCorrectSortedArray_WhenCalledWithRangeFromNegativeToPositiveNumber()
		{
			// Arrange
			const int minimumNumber = -5432;
			const int maximumNumber = 987456;

			// Act
			var array = _sortedArrayService.GetArray(minimumNumber, maximumNumber);

			// Assert
			Utils.VerifyArrayIsSortedFromMinimumNumberToMaximumNumber(minimumNumber, maximumNumber, array);
		}

		public void GetArray_ReturnsCorrectSortedArray_WhenCalledWithLargeRange()
		{
			// Arrange
			const int minimumNumber = 1;
			const int maximumNumber = 6546549;

			// Act
			var array = _sortedArrayService.GetArray(minimumNumber, maximumNumber);

			// Assert
			Utils.VerifyArrayIsSortedFromMinimumNumberToMaximumNumber(minimumNumber, maximumNumber, array);
		}
	}
}
