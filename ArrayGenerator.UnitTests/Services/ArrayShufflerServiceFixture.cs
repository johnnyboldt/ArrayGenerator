using System;
using System.Linq;
using ArrayGenerator.Services;
using ArrayGenerator.Services.Interfaces;
using NUnit.Framework;

namespace ArrayGenerator.UnitTests.Services
{
	[TestFixture]
	public class ArrayShufflerServiceFixture
	{
		private IArrayShufflerService _arrayShufflerService;
		private ISortedArrayService _sortedArrayService;

		[SetUp]
		public void SetUp()
		{
			_arrayShufflerService = new ArrayShufflerService();
			_sortedArrayService = new SortedArrayService();
		}

		[Test]
		public void FisherYatesShuffleArray_ReturnsShuffledArray_WhenArrayIs1To100()
		{
			// Arrange
			var array1 = _sortedArrayService.GetArray(1, 100).ToArray();
			var array2 = _sortedArrayService.GetArray(1, 100).ToArray();
			Utils.VerifyArraysAreEqual(array1, array2);

			// Act
			_arrayShufflerService.FisherYatesShuffleArray(array2);

			// Assert
			for (var i = 0; i < 100; i++) //Verify all elements are in the 1 to 100 range
			{
				Assert.IsTrue(array2.ElementAt(i) >= 1 && array2.ElementAt(i) <= 100);
			}

			
			Utils.VerifyArraysAreNotEqual(array1,array2); //Verify that the elements are not identical

			//Verify if we were to sort array2, it is now identical to array1 again
			Array.Sort(array2);
			Utils.VerifyArraysAreEqual(array1, array2);
		}

		[Test]
		public void FisherYatesShuffleArray_ReturnsUniqueShuffle_WhenArrayIs1To100()
		{
			// Arrange
			var array1 = _sortedArrayService.GetArray(1, 100).ToArray();
			var array2 = _sortedArrayService.GetArray(1, 100).ToArray();
			Utils.VerifyArraysAreEqual(array1, array2);

			// Act
			_arrayShufflerService.FisherYatesShuffleArray(array1);
			_arrayShufflerService.FisherYatesShuffleArray(array2);

			// Assert
			Utils.VerifyArraysAreNotEqual(array1, array2);
		}

		[Test]
		public void FisherYatesShuffleArray_ReturnsArray_WhenArrayIs1To1()
		{
			// Arrange
			var array1 = _sortedArrayService.GetArray(1, 1).ToArray();
			var array2 = _sortedArrayService.GetArray(1, 1).ToArray();
			Utils.VerifyArraysAreEqual(array1, array2);

			// Act
			_arrayShufflerService.FisherYatesShuffleArray(array1);

			// Assert
			Utils.VerifyArraysAreEqual(array1, array2);
		}

		[Test]
		public void FisherYatesShuffleList_ReturnsShuffledArray_WhenArrayIs1To100()
		{
			// Arrange
			var list1 = _sortedArrayService.GetArray(1, 100).ToList();
			var list2 = _sortedArrayService.GetArray(1, 100).ToList();
			Utils.VerifyArraysAreEqual(list1, list2);

			// Act
			_arrayShufflerService.FisherYatesShuffleList(list2);

			// Assert
			for (var i = 0; i < 100; i++) //Verify all elements are in the 1 to 100 range
			{
				Assert.IsTrue(list2.ElementAt(i) >= 1 && list2.ElementAt(i) <= 100);
			}
			
			Utils.VerifyArraysAreNotEqual(list1, list2); //Verify that the elements are not identical

			//Verify if we were to sort list2, it is now identical to list1 again
			list2.Sort();
			Utils.VerifyArraysAreEqual(list1, list2);
		}

		[Test]
		public void FisherYatesShuffleList_ReturnsUniqueShuffle_WhenArrayIs1To100()
		{
			// Arrange
			var list1 = _sortedArrayService.GetArray(1, 100).ToList();
			var list2 = _sortedArrayService.GetArray(1, 100).ToList();
			Utils.VerifyArraysAreEqual(list1, list2);

			// Act
			_arrayShufflerService.FisherYatesShuffleList(list1);
			_arrayShufflerService.FisherYatesShuffleList(list2);

			// Assert
			Utils.VerifyArraysAreNotEqual(list1, list2);
		}

		[Test]
		public void FisherYatesShuffleList_ReturnsArray_WhenArrayIs1To1()
		{
			// Arrange
			var list1 = _sortedArrayService.GetArray(1, 1).ToList();
			var list2 = _sortedArrayService.GetArray(1, 1).ToList();
			Utils.VerifyArraysAreEqual(list1, list2);

			// Act
			_arrayShufflerService.FisherYatesShuffleList(list1);

			// Assert
			Utils.VerifyArraysAreEqual(list1, list2);
		}
	}
}
