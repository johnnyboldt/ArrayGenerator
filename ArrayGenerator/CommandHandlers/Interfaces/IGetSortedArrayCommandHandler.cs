using System.Collections.Generic;
using ArrayGenerator.Commands;

namespace ArrayGenerator.CommandHandlers.Interfaces
{
	/// <summary>
	/// Command Handler for GetSortedArray Command
	/// </summary>
	public interface IGetSortedArrayCommandHandler
	{
		/// <summary>
		/// Executes a command to get a sorted array
		/// </summary>
		/// <param name="getSortedArrayCommand">Command to get a sorted array</param>
		/// <returns>A sorted Array</returns>
		IEnumerable<int> Execute(GetSortedArrayCommand getSortedArrayCommand);
	}
}
