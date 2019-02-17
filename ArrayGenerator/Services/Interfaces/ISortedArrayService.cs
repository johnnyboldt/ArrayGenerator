using System.Collections.Generic;

namespace ArrayGenerator.Services.Interfaces
{
	/// <summary>
	///  Generates an array of sorted numbers
	/// </summary>
	public interface ISortedArrayService
	{
		/// <summary>
		/// Generates a sorted list of numbers from minimumNumber to maximumNumber 
		/// </summary>
		/// <param name="minimumNumber">The minimum number the array should be generated from</param>
		/// <param name="maximumNumber">The maximum number the array should be generated from</param>
		/// <returns>A sorted list of numbers from SmallestNumber to LargestNumber</returns>
		IEnumerable<int> GetArray(int minimumNumber, int maximumNumber);
	}
}
