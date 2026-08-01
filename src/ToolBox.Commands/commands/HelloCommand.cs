using ToolBox.Core;

namespace ToolBox.Commands.Commands;

public class HelloCommand : IAction
{
	public string Name => "hello";
	public string Description => "test command";
	public string Category => "Misc";
	public IReadOnlyList<ParamSpec> Parameters => Array.Empty<ParamSpec>();

	public CommandResult Execute(IReadOnlyList<string> args)
		=> CommandResult.Ok(Greeting.Build());
}
