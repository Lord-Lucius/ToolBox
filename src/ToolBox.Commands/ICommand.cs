namespace ToolBox.Commands;

public interface ICommand
{
	string Name {get;}
	string Description {get;}
	string Category {get;}
	IReadOnlyList<ParamSpec> Parameters {get;}

	CommandResult Execute(IReadOnlyList<string> args);
}
