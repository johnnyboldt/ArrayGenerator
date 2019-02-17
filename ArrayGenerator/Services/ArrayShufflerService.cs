using System;
using System.Collections.Generic;
using ArrayGenerator.Services.Interfaces;

namespace ArrayGenerator.Services
{
	/// <inheritdoc />
	public class ArrayShufflerService: IArrayShufflerService
	{
		/// <inheritdoc />
		public void FisherYatesShuffleArray(int[] array)
		{
			var random = new Random();
			var n = array.Length;
			while (n > 1)
			{
				var k = random.Next(n--);
				var temp = array[n];
				array[n] = array[k];
				array[k] = temp;
			}
		}

		/// <inheritdoc />
		public void FisherYatesShuffleList(List<int> list)
		{
			var random = new Random();
			var n = list.Count;
			while (n > 1)
			{
				var k = random.Next(n--);
				var temp = list[n];
				list[n] = list[k];
				list[k] = temp;
			}
		}
	}
}
