namespace ToolBox.Commands;

public interface ICommandBase
{
	string Name {get;}
	string Description {get;}
	string Category {get;}
}

public interface IAction : ICommandBase
{
	IReadOnlyList<ParamSpec> Parameters {get;}

	CommandResult Execute(IReadOnlyList<string> args);
}

public interface IGroup : ICommandBase
{
	IReadOnlyList<IAction> SubCommands {get; }
}
