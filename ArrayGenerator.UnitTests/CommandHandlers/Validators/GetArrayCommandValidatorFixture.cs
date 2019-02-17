using System;
using System.Collections.Generic;
using System.Text;
using ArrayGenerator.CommandHandlers.Validators;
using ArrayGenerator.CommandHandlers.Validators.Interfaces;
using ArrayGenerator.Commands;
using NUnit.Framework;

namespace ArrayGenerator.UnitTests.CommandHandlers.Validators
{
	[TestFixture]
	public class GetArrayCommandValidatorFixture
	{
		private IGetArrayCommandValidator _getArrayCommandValidator;

		[SetUp]
		public void SetUp()
		{
			_getArrayCommandValidator = new GetArrayCommandValidator();
		}

		[Test]
		public void AssertValid_ThrowsException_WhenGetShuffledArrayCommandMaximumNumberLessThanMinimumNumber()
		{
			// Arrange
			var command = new GetShuffledArrayCommand(53,2);

			// Act/Assert
			Assert.Throws<Exception>(() => _getArrayCommandValidator.AssertValid(command));
		}

		[Test]
		public void AssertValid_ThrowsException_WhenGetSortedArrayCommandMaximumNumberLessThanMinimumNumber()
		{
			// Arrange
			var command = new GetSortedArrayCommand(48, 12);

			// Act/Assert
			Assert.Throws<Exception>(() => _getArrayCommandValidator.AssertValid(command));
		}
	}
}
