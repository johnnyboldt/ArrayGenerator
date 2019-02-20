namespace ArrayGenerator.Commands
{
	/// <summary>
	/// An abstract command for getting an array
	/// </summary>
	public abstract class GetArrayCommand
	{
		/// <summary>
		/// The minimum number in the array being generated
		/// </summary>
		public int MinimumNumber { get; }

		/// <summary>
		/// The maximum number in the array being generated
		/// </summary>
		public int MaximumNumber { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		protected GetArrayCommand(int minimumNumber, int maximumNumber)
		{
			MinimumNumber = minimumNumber;
			MaximumNumber = maximumNumber;
		}
	}
}
