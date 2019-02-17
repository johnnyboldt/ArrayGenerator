using System.Collections.Generic;
using ArrayGenerator.CommandHandlers.Interfaces;
using ArrayGenerator.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ArrayGenerator.Controllers
{
	/// <summary>
	/// Controller for Sorted Arrays
	/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SortedArrayController : ControllerBase
	{
		private readonly IGetSortedArrayCommandHandler _getSortedArrayCommandHandler;

	    public SortedArrayController(IGetSortedArrayCommandHandler getSortedArrayCommandHandler)
	    {
		    _getSortedArrayCommandHandler = getSortedArrayCommandHandler;
	    }

		/// <summary>
		/// Gets a sorted array
		/// </summary>
		/// <param name="minimumNumber">The minimum number the array should be generated from</param>
		/// <param name="maximumNumber">The maximum number the array should be generated from</param>
		/// <returns></returns>
		// GET api/SortedArray/?minimumNumber=1&maximumNumber=10000
		[HttpGet]
	    public IEnumerable<int> Get(int minimumNumber, int maximumNumber)
		{
			var command = new GetSortedArrayCommand(minimumNumber, maximumNumber);
		    return _getSortedArrayCommandHandler.Execute(command);
	    }
	}
}
