namespace ArrayGenerator.Commands
{
	/// <summary>
	/// Command to get a sorted array
	/// </summary>
	public class GetSortedArrayCommand : GetArrayCommand
	{
		public GetSortedArrayCommand(int minimumNumber, int maximumNumber) : base(minimumNumber, maximumNumber)
		{
		}
	}
}
