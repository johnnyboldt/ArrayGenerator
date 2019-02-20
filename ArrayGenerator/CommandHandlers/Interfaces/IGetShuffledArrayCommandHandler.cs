using System.Collections.Generic;
using ArrayGenerator.Commands;

namespace ArrayGenerator.CommandHandlers.Interfaces
{
	/// <summary>
	/// Command Handler for GetShuffledArray Command
	/// </summary>
	public interface IGetShuffledArrayCommandHandler
	{
		/// <summary>
		/// Executes a command to get a shuffled array
		/// </summary>
		/// <param name="getShuffledArrayCommand">Command to get a shuffled array</param>
		/// <returns>A shuffled Array</returns>
		IEnumerable<int> Execute(GetShuffledArrayCommand getShuffledArrayCommand);
	}
}
