using Terminal.Gui.App;
using Terminal.Gui.Views;
using ToolBox.App.UI.Layout;
using ToolBox.Commands;

namespace ToolBox.App.UI.Shell;

public class ShellController
{
	private readonly CommandRegistry _registry;
	private readonly ShellView _shell;
	private readonly IApplication _app;

	public ShellController(CommandRegistry registry, ShellView shell, IApplication app)
	{
		_registry = registry;
		_shell = shell;
		_app = app;

		var names = registry.All().Select(c => c.Name).ToList();
		_shell.Sidebar.SetCommands(names);

		_shell.Sidebar.CommandSelected += OnCommandSelected;

		_shell.Footer.SetQuitAction(() => _app.RequestStop());

		_shell.Header.SetTitle("ToolBox");
		_shell.Workspace.ShowMessage("Select a command in the sidebar");
	}

	private void OnCommandSelected(string commandName)
	{
		var result = _registry.Run([commandName]);

		string text = string.IsNullOrEmpty(result.Error)
			? result.Output
			: result.Error;

		_shell.Workspace.ShowMessage(text);
		_shell.Header.SetTitle($"ToolBox — {commandName}");
		_shell.Footer.SetStatus($"Ran: {commandName}");
	}
}
