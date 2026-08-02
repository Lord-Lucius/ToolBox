namespace ToolBox.Commands.Commands;

public class PatternGroup : IGroup
{

	string ICommandBase.Name => "pattern";

	public string Description => "regroup all pattern functions";

	public string Category => "RE";

	public IReadOnlyList<IAction> SubCommands => [new PatternCreateCommand(), new PatternOffsetCommand()];

}
