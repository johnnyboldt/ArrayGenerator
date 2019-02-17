using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArrayGenerator.Services.Interfaces
{
	/// <summary>
	/// Shuffles a given array
	/// </summary>
	public interface IArrayShufflerService
	{
		/// <summary>
		/// Shuffles in O(n) time.
		/// https://stackoverflow.com/questions/1287567/is-using-random-and-orderby-a-good-shuffle-algorithm
		/// </summary>
		/// <param name="array">The array to be shuffled</param>
		/// <returns>A shuffled array</returns>
		void FisherYatesShuffleArray(int[] array);

		/// <summary>
		/// Shuffles in O(n) time.
		/// https://stackoverflow.com/questions/1287567/is-using-random-and-orderby-a-good-shuffle-algorithm
		/// </summary>
		/// <param name="source">The List to be shuffled</param>
		/// <returns>A shuffled List</returns>
		void FisherYatesShuffleList(List<int> list);
	}
}
