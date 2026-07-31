using System;
using ToolBox.Commands;

namespace ToolBox.App;

public class ToolBox
{
	public static int Main(string[]? args)
	{
		CommandRegistry registry = new CommandRegistry();

		if (args == null || args.Length == 0)
		{
			Console.Write(HelpText.Build(registry));
			return 0;
		}
		if (args[0] == "--help" || args[0] == "-h")
		{
			Console.Write(HelpText.Build(registry));
			return 0;
		}
		CommandResult result = registry.Run(args[0], args[1..]);
		if (result.Output != "")
			Console.WriteLine(result.Output);
		if (result.Error != "")
			Console.Error.WriteLine(result.Error);
		return result.ExitCode;
	}
}
