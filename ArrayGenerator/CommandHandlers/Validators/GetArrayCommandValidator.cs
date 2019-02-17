using System;
using ArrayGenerator.CommandHandlers.Validators.Interfaces;
using ArrayGenerator.Commands;

namespace ArrayGenerator.CommandHandlers.Validators
{
	/// <inheritdoc />
	public class GetArrayCommandValidator : IGetArrayCommandValidator
	{
		/// <inheritdoc />
		public void AssertValid(GetArrayCommand command)
		{
			if (command.MinimumNumber > command.MaximumNumber)
			{
				throw new Exception(
					$"Array Minimum Number {command.MinimumNumber} can not be larger than Array Maximum Number {command.MaximumNumber}");
			}
		}
	}
}
