using System;
using System.Linq;
using ArrayGenerator.Services;
using ArrayGenerator.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace ArrayGenerator.UnitTests.Services
{
	[TestFixture]
	public class ShuffledArrayServiceFixture
	{
		private IShuffledArrayService _shuffledArrayService;

		// I could have moq'd these and just checked their methods were called
		// But since this is the most crucial part of the requirements I thought
		// I would instantiate them and do some in-depth testing.
		private IArrayShufflerService _arrayShufflerService;
		private ISortedArrayService _sortedArrayService;

		[SetUp]
		public void SetUp()
		{
			_arrayShufflerService = new ArrayShufflerService();
			_sortedArrayService = new SortedArrayService();
			_shuffledArrayService = new ShuffledArrayService(_arrayShufflerService, _sortedArrayService);
		}

		[Test]
		public void GetArray_ShouldThrowAnError_WhenMaximumNumberSmallerThanMinimumNumber()
		{
			Assert.Throws<Exception>(() => _shuffledArrayService.GetArray(2, 1));
		}

		[Test]
		public void GetArray_ShouldThrowAnError_WhenMaximumNegativeNumberSmallerThanMinimumNumber()
		{
			Assert.Throws<Exception>(() => _shuffledArrayService.GetArray(-13, -52));
		}

		[Test]
		public void GetArrayWithDynamicMemory_ShouldThrowAnError_WhenMaximumNumberSmallerThanMinimumNumber()
		{
			Assert.Throws<Exception>(() => _shuffledArrayService.GetArray(2, 1));
		}

		[Test]
		public void GetArrayWithDynamicMemory_ShouldThrowAnError_WhenMaximumNegativeNumberSmallerThanMinimumNumber()
		{
			Assert.Throws<Exception>(() => _shuffledArrayService.GetArray(-13, -52));
		}

		[Test]
		public void GetArrayWithStaticMemory_ReturnsShuffledTenThousandItemArray()
		{
			// Arrange/Act
			var array = _shuffledArrayService.GetArrayWithStaticMemory();

			// Assert
			Utils.VerifyArraysAreNotEqual(Globals.TenThousandItemArraySorted, array);
			Utils.VerifyArraysIsNotSorted(array);
			var list = array.ToList();
			list.Sort();
			Utils.VerifyArraysAreEqual(list, Globals.TenThousandItemArraySorted); //Checks all numbers exist in the above unsorted array
		}

		[Test]
		public void GetArrayWithDynamicMemory_ReturnsShuffledTenThousandItemArray()
		{
			// Arrange/Act
			var array = _shuffledArrayService.GetArrayWithDynamicMemory();

			// Assert
			Utils.VerifyArraysAreNotEqual(Globals.TenThousandItemArraySorted, array);
			Utils.VerifyArraysIsNotSorted(array);
			var list = array.ToList();
			list.Sort();
			Utils.VerifyArraysAreEqual(list, Globals.TenThousandItemArraySorted); //Checks all numbers exist in the above unsorted array
		}

		[Test]
		public void GetArray_ReturnsArrayOfOneElement_WhenCalledWithOneNumber()
		{
			// Arrange
			const int number = 43;

			// Act
			var array = _shuffledArrayService.GetArray(number, number);

			// Assert
			Assert.IsTrue(array.Count() == 1);
			Assert.IsTrue(array.ElementAt(0) == number);
		}

		[Test]
		public void GetArray_ReturnsShuffledGlobalsArray_WhenCalledWithGlobalsSmallestNumberToLargestNumber()
		{
			// Arrange/Act
			var array = _shuffledArrayService.GetArray(Globals.SmallestNumber, Globals.LargestNumber);

			// Assert
			Utils.VerifyArraysAreNotEqual(Globals.TenThousandItemArraySorted,array);
			Utils.VerifyArraysIsNotSorted(array);
			var list = array.ToList();
			list.Sort();
			Utils.VerifyArraysAreEqual(Globals.TenThousandItemArraySorted, list); //Checks all numbers exist in the above unsorted array
		}

		[Test]
		public void GetArray_ReturnsShuffledArray_WhenCalledWithNegativeRange()
		{
			// Arrange
			const int minimumNumber = -275;
			const int maximumNumber = -35;

			// Act
			var array = _shuffledArrayService.GetArray(minimumNumber, maximumNumber);

			// Assert
			Utils.VerifyArraysIsNotSorted(array);
			var list = array.ToList();
			list.Sort();
			Utils.VerifyArrayIsSortedFromMinimumNumberToMaximumNumber(minimumNumber, maximumNumber, list); //Checks all numbers exist in the above unsorted array
		}

		[Test]
		public void GetArray_ReturnsShuffledArray_WhenCalledWithRangeFromNegativeToPositiveNumber()
		{
			// Arrange
			const int minimumNumber = -5432;
			const int maximumNumber = 987456;

			// Act
			var array = _shuffledArrayService.GetArray(minimumNumber, maximumNumber);

			// Assert
			Utils.VerifyArraysIsNotSorted(array);
			var list = array.ToList();
			list.Sort();
			Utils.VerifyArrayIsSortedFromMinimumNumberToMaximumNumber(minimumNumber, maximumNumber, list); //Checks all numbers exist in the above unsorted array
		}

		public void GetArray_ReturnsShuffledArray_WhenCalledWithLargeRange()
		{
			// Arrange
			const int minimumNumber = 1;
			const int maximumNumber = 6546549;

			// Act
			var array = _shuffledArrayService.GetArray(minimumNumber, maximumNumber);

			// Assert
			Utils.VerifyArraysIsNotSorted(array);
			array.ToList().Sort();
			Utils.VerifyArrayIsSortedFromMinimumNumberToMaximumNumber(minimumNumber, maximumNumber, array); //Checks all numbers exist in the above unsorted array
		}

	}
}
