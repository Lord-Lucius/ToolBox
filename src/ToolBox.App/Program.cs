using System;
using ToolBox.App.UI;
using ToolBox.Commands;

namespace ToolBox.App;

public class ToolBox
{
	public static int Main(string[]? args)
	{
		CommandRegistry registry = new();

		if (args == null || args.Length == 0)
		{
			Tui.RunTui(registry);
			return 0;
		}
		if (args == null || args[0] is "--help" or "-h")
		{
			Console.Write(HelpText.Build(registry));
			return 0;
		}
		CommandResult result = registry.Run(args);
		if (result.Output != "")
			Console.WriteLine(result.Output);
		if (result.Error != "")
			Console.Error.WriteLine(result.Error);
		return result.ExitCode;
	}
}
