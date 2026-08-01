using ToolBox.Commands.Commands;

namespace ToolBox.Commands;

public class CommandRegistry
{
	private readonly Dictionary<string, ICommandBase> commands = new(StringComparer.OrdinalIgnoreCase);

	public CommandRegistry()
	{
		Register(new HelloCommand());
	}

	public void Register(ICommandBase cmd)
	{
		commands.Add(cmd.Name, cmd);
	}

	public IEnumerable<ICommandBase> All()
	{
		return commands.Values;
	}

	public ICommandBase? TryResolve(string name)
	{
		commands.TryGetValue(name, out ICommandBase? t);
		return t;
	}

	public CommandResult Run(IReadOnlyList<string> args)
	{
		if (args.Count == 0)
			return CommandResult.Fail("no command", 2);

		ICommandBase? entry = TryResolve(args[0]);

		if (entry is null)
			return CommandResult.Fail("unknown command: " + args[0], 127);

		if (entry is IAction action)
			return ExecuteAction(action, args.Skip(1).ToList());

		if (entry is IGroup group)
		{
			if (args.Count < 2)
				return CommandResult.Fail("missing subcommand for " + args[0], 2);

			IAction? sub = group.SubCommands
				.FirstOrDefault(c => string.Equals(c.Name, args[1], StringComparison.OrdinalIgnoreCase));

			if (sub is null)
				return CommandResult.Fail("unknown subcommand: " + args[1], 127);

			return ExecuteAction(sub, args.Skip(2).ToList());
		}

		return CommandResult.Fail("unknown command: " + args[0], 127);
	}

	private static CommandResult ExecuteAction(IAction action, IReadOnlyList<string> args)
	{
		string error = Validate(action, args);
		if (error != "")
			return CommandResult.Fail(error, 2);

		return action.Execute(args);
	}

	public static string Validate(IAction action, IReadOnlyList<string> args)
	{
		int required = action.Parameters.Count(param => param.Required);

		if (args.Count < required)
			return "missing arguments";
		if (args.Count > action.Parameters.Count)
			return "too many arguments";

		return "";
	}
}
