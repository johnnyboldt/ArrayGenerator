using System.Collections.Generic;
using ArrayGenerator.CommandHandlers.Interfaces;
using ArrayGenerator.CommandHandlers.Validators.Interfaces;
using ArrayGenerator.Commands;
using ArrayGenerator.Services.Interfaces;

namespace ArrayGenerator.CommandHandlers
{
	/// <inheritdoc />
	public class GetSortedArrayCommandHandler : IGetSortedArrayCommandHandler
	{
		private readonly ISortedArrayService _sortedArrayService;
		private readonly IGetArrayCommandValidator _getArrayCommandValidator;

		public GetSortedArrayCommandHandler(ISortedArrayService sortedArrayService, IGetArrayCommandValidator getArrayCommandValidator)
		{
			_sortedArrayService = sortedArrayService;
			_getArrayCommandValidator = getArrayCommandValidator;
		}

		/// <inheritdoc />
		public IEnumerable<int> Execute(GetSortedArrayCommand getSortedArrayCommand)
		{
			_getArrayCommandValidator.AssertValid(getSortedArrayCommand);

			return _sortedArrayService.GetArray(getSortedArrayCommand.MinimumNumber,
				getSortedArrayCommand.MaximumNumber);
		}
	}
}
