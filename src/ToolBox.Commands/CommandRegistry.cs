using ToolBox.Commands.Commands;

namespace ToolBox.Commands;

public class CommandRegistry
{
	private readonly Dictionary<string, ICommand> commands = new(StringComparer.OrdinalIgnoreCase);

	public CommandRegistry()
	{
		Register(new HelloCommand());
	}

	public void Register(ICommand cmd)
	{
		commands.Add(cmd.Name, cmd);
	}

	public IEnumerable<ICommand> All()
	{
		return commands.Values;
	}

	public ICommand? TryResolve(string name)
	{
		ICommand? t = null;

		commands.TryGetValue(name, out t);
		return t;
	}

	public CommandResult Run(string name, IReadOnlyList<string> args)
	{
		ICommand? cmd = TryResolve(name);

		if (cmd == null)
			return CommandResult.Fail("unknown command: " + name, 127);

		string error = Validate(cmd, args);

		if(error != "")
			return CommandResult.Fail(error, 2);


		return cmd.Execute(args);
	}

	public static string Validate(ICommand cmd, IReadOnlyList<string> args)
	{
		int required = cmd.Parameters.Count<ParamSpec>(param => param.Required);

		if (args.Count < required)
			return "missing arguments";
		if (args.Count > cmd.Parameters.Count)
			return "too many arguments";

		return "";
	}
}
