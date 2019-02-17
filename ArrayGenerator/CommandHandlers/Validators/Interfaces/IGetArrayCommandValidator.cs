using ArrayGenerator.Commands;

namespace ArrayGenerator.CommandHandlers.Validators.Interfaces
{
	/// <summary>
	/// Validates the GetArrayCommand
	/// </summary>
	public interface IGetArrayCommandValidator
	{
		/// <summary>
		/// Asserts the GetArrayCommand is valid. If it is not, an exception will be thrown.
		/// </summary>
		/// <param name="command">The command to get an array</param>
		void AssertValid(GetArrayCommand command);
	}
}
