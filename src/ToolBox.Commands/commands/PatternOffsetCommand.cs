using ToolBox.Core;

namespace ToolBox.Commands.Commands;

public class PatternOffsetCommand : IAction
{

	public string Name => "offset";

	public string Description => "return the index of the offset";

	public string Category => "RE";

	public IReadOnlyList<ParamSpec> Parameters => [new ParamSpec("value", "Substring or hexadecimal value")];

	public CommandResult Execute(IReadOnlyList<string> args)
	{
		int offset = CyclicPattern.FindOffset(args[0]);

		if (offset < 0)
			return CommandResult.Fail("not found in pattern", 1);
		return CommandResult.Ok("Offset found at: " + offset);
	}
}
