using System;
using System.Collections.Generic;
using System.Text;
using ArrayGenerator.CommandHandlers;
using ArrayGenerator.CommandHandlers.Interfaces;
using ArrayGenerator.CommandHandlers.Validators.Interfaces;
using ArrayGenerator.Commands;
using ArrayGenerator.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace ArrayGenerator.UnitTests.CommandHandlers
{
	[TestFixture]
	public class GetSortedArrayCommandHandlerFixture
	{
		//private Mock<IArrayShufflerService> _arrayShufflerService;
		//private Mock<ISortedArrayService> _sortedArrayService;

		private IGetSortedArrayCommandHandler _getSortedArrayCommandHandler;
		private Mock<IGetArrayCommandValidator> _getArrayCommandValidator;
		private Mock<ISortedArrayService> _sortedArrayService;

		[SetUp]
		public void SetUp()
		{
			_getArrayCommandValidator = new Mock<IGetArrayCommandValidator>();
			_sortedArrayService = new Mock<ISortedArrayService>();
			_getSortedArrayCommandHandler = new GetSortedArrayCommandHandler(_sortedArrayService.Object, _getArrayCommandValidator.Object);
		}

		[Test]
		public void Execute_ValidatesCommand()
		{
			// Arrange
			var command = new GetSortedArrayCommand(8, 90);

			// Act
			_getSortedArrayCommandHandler.Execute(command);

			// Assert
			_getArrayCommandValidator.Verify(g => g.AssertValid(command), Times.Once);
		}

		[Test]
		public void Execute_CallsGetArrayWithCorrectParameters()
		{
			// Arrange
			const int minimumNumber = 3;
			const int maximumNumber = 77;
			var command = new GetSortedArrayCommand(minimumNumber, maximumNumber);

			//Act
			_getSortedArrayCommandHandler.Execute(command);

			// Assert
			_sortedArrayService.Verify(s => s.GetArray(minimumNumber, maximumNumber), Times.Once);
		}
	}
}
