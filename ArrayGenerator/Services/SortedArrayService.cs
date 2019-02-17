using System;
using System.Collections.Generic;
using System.Linq;
using ArrayGenerator.Services.Interfaces;

namespace ArrayGenerator.Services
{
	/// <inheritdoc />
	public class SortedArrayService: ISortedArrayService
	{
		/// <inheritdoc />
		public IEnumerable<int> GetArray(int minimumNumber, int maximumNumber)
		{
			if (maximumNumber < minimumNumber)
			{
				throw new Exception("The maximumNumber in method GetArray can not be smaller than minimumNumber");
			}
			return Enumerable.Range(minimumNumber, maximumNumber - minimumNumber +1); // +1 because we count each number
		}
	}
}
