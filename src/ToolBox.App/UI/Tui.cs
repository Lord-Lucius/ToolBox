using Terminal.Gui.App;
using ToolBox.App.UI.Shell;
using ToolBox.Commands;

namespace ToolBox.App.UI;

public static class Tui
{
	public static void Run(CommandRegistry registry)
	{
		using IApplication app = Application.Create();
		app.Init();

		var shell = new ShellView();
		_ = new ShellController(registry, shell, app);

		app.Run(shell);
	}
}
