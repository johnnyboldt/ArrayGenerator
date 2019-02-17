using System.Collections.Generic;
using ArrayGenerator.CommandHandlers.Interfaces;
using ArrayGenerator.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ArrayGenerator.Controllers
{
	/// <summary>
	/// Controller for Shuffled Arrays
	/// </summary>
	[Route("api/[controller]")]
    [ApiController]
    public class ShuffledArrayController : ControllerBase
    {
		private readonly IGetShuffledArrayCommandHandler _getShuffledArrayCommandHandler;

	    public ShuffledArrayController(IGetShuffledArrayCommandHandler getShuffledArrayCommandHandler)
	    {
		    _getShuffledArrayCommandHandler = getShuffledArrayCommandHandler;
	    }

		/// <summary>
		/// Gets a shuffled array
		/// </summary>
		/// <param name="minimumNumber">The minimum number the array should be generated from</param>
		/// <param name="maximumNumber">The maximum number the array should be generated from</param>
		/// <returns></returns>
		// GET api/ShuffledArray/?minimumNumber=1&maximumNumber=10000
		[HttpGet]
	    public IEnumerable<int> Get(int minimumNumber, int maximumNumber)
	    {
		    var command = new GetShuffledArrayCommand(minimumNumber, maximumNumber);
		    return _getShuffledArrayCommandHandler.Execute(command);
		}
	}
}
