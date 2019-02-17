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
	public class GetShuffledArrayCommandHandlerFixture
	{
		private IGetShuffledArrayCommandHandler _getShuffledArrayCommandHandler;
		private Mock<IGetArrayCommandValidator> _getArrayCommandValidator;
		private Mock<IShuffledArrayService> _shuffledArrayService;

		[SetUp]
		public void SetUp()
		{
			_getArrayCommandValidator = new Mock<IGetArrayCommandValidator>();
			_shuffledArrayService = new Mock<IShuffledArrayService>();
			_getShuffledArrayCommandHandler = new GetShuffledArrayCommandHandler(_shuffledArrayService.Object, _getArrayCommandValidator.Object);
		}
		
		[Test]
		public void Execute_ValidatesCommand()
		{
			// Arrange
			var command = new GetShuffledArrayCommand(3, 20);

			// Act
			_getShuffledArrayCommandHandler.Execute(command);

			// Assert
			_getArrayCommandValidator.Verify(g => g.AssertValid(command), Times.Once);
		}

		[Test]
		public void Execute_CallsGetArrayWithCorrectParameters()
		{
			// Arrange
			const int minimumNumber = 4;
			const int maximumNumber = 17;

			// Act
			var command = new GetShuffledArrayCommand(minimumNumber, maximumNumber);

			// Assert
			_getShuffledArrayCommandHandler.Execute(command);
			_shuffledArrayService.Verify(s => s.GetArray(minimumNumber, maximumNumber), Times.Once);
		}
	}
}
