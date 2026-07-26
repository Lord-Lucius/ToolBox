using ToolBox.Commands;
using ToolBox.Core;

namespace ToolBox.Commands.Commands
{
	public class HelloCommand : ICommand
	{
		public string Name => "hello";
		public string Description => "test command";
		public string Category => "Misc";
		public IReadOnlyList<ParamSpec> Parameters => Array.Empty<ParamSpec>();

		public CommandResult Execute(IReadOnlyList<string> args)
		{
			return CommandResult.Ok(Greeting.Build());
		}
	}
}
