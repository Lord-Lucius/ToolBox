using ToolBox.Core;

namespace ToolBox.Commands.Commands;

public class PatternCreateCommand : IAction
{

	public string Name => "create";

	public string Description => "allow the creation of a pattern of size l";

	public string Category => "RE";

	public IReadOnlyList<ParamSpec> Parameters => [new ParamSpec("length", "the length of the needed pattern")];

	public CommandResult Execute(IReadOnlyList<string> args)
	{
		if (int.TryParse(args[0], out var _) == false)
			return CommandResult.Fail("length must be a number", 2);
		int n = int.Parse(args[0]);
		return CommandResult.Ok("Pattern created: \n" + CyclicPattern.Generate(n));
	}
}
