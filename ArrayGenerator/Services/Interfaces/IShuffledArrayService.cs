using System.Collections.Generic;

namespace ArrayGenerator.Services.Interfaces
{
	/// <summary>
	/// Generates an array of randomly shuffled numbers
	/// </summary>
	public interface IShuffledArrayService
	{

		/// <summary>
		/// Generates a random list of numbers from minimumNumber to maximumNumber 
		/// </summary>
		/// <param name="minimumNumber">The minimum number the array should be generated from</param>
		/// <param name="maximumNumber">The maximum number the array should be generated from</param>
		/// <returns>A random list of numbers from SmallestNumber to LargestNumber</returns>
		IEnumerable<int> GetArray(int minimumNumber, int maximumNumber);

		/// <summary>
		/// Generates a random array of numbers from Globals SmallestNumber to LargestNumber using an already
		/// initialized array in static memory
		/// </summary>
		/// <returns>A random array of numbers from Globals SmallestNumber to LargestNumber</returns>
		IEnumerable<int> GetArrayWithStaticMemory();

		/// <summary>
		/// Generates a random list of numbers from Globals SmallestNumber to LargestNumber using dynamic memory
		/// </summary>
		/// <returns>A random list of numbers from Globals SmallestNumber to LargestNumber</returns>
		IEnumerable<int> GetArrayWithDynamicMemory();
	}
}
