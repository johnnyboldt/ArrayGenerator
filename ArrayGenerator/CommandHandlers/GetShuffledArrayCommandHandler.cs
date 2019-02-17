using System.Collections.Generic;
using ArrayGenerator.CommandHandlers.Interfaces;
using ArrayGenerator.CommandHandlers.Validators.Interfaces;
using ArrayGenerator.Commands;
using ArrayGenerator.Services.Interfaces;

namespace ArrayGenerator.CommandHandlers
{
	/// <inheritdoc />
	public class GetShuffledArrayCommandHandler : IGetShuffledArrayCommandHandler
	{
		private readonly IShuffledArrayService _shuffledArrayService;
		private readonly IGetArrayCommandValidator _getArrayCommandValidator;

		public GetShuffledArrayCommandHandler(IShuffledArrayService shuffledArrayService, IGetArrayCommandValidator getArrayCommandValidator)
		{
			_shuffledArrayService = shuffledArrayService;
			_getArrayCommandValidator = getArrayCommandValidator;
		}

		/// <inheritdoc />
		public IEnumerable<int> Execute(GetShuffledArrayCommand getSortedArrayCommand)
		{
			_getArrayCommandValidator.AssertValid(getSortedArrayCommand);

			return _shuffledArrayService.GetArray(getSortedArrayCommand.MinimumNumber,
				getSortedArrayCommand.MaximumNumber);
		}
	}
}
