namespace ArrayGenerator.Commands
{
	/// <summary>
	/// Command to get a shuffled array
	/// </summary>
	public class GetShuffledArrayCommand : GetArrayCommand
	{
		public GetShuffledArrayCommand(int minimumNumber, int maximumNumber) : base(minimumNumber, maximumNumber)
		{
		}
	}
}
