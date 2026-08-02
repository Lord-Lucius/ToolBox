using System.Collections.ObjectModel;
using Terminal.Gui.App;
using Terminal.Gui.Input;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;
using ToolBox.Commands;

namespace ToolBox.App.UI;

public class Tui
{
	public static void RunTui(CommandRegistry registry)
	{
		using IApplication app = Application.Create();
		app.Init();

		List<ICommandBase> commands = registry.All().ToList();
		ObservableCollection<string> names = new(commands.Select(c => c.Name));

		ListView view = new()
		{
			X = 0,
			Y = 0,
			Width = Dim.Percent(30),
			Height = Dim.Fill(1),
			Title = "Navigation (↑↓)"
		};
		view.SetSource(names);

		Label outPanel = new()
		{
			X = Pos.Right(view),
			Y = 0,
			Width = Dim.Fill(),
			Height = Dim.Fill(1),
			Text = "Output",
		};

		view.Accepting += (sender, args) =>
		{
			int index = view.SelectedItem ?? -1;
			if (index < 0 || index >= commands.Count)
				return;

			ICommandBase cmd = commands[index];
			CommandResult result = registry.Run([cmd.Name]);

			outPanel.Text = result.Error != "" ? result.Error : result.Output;
			outPanel.SetNeedsDraw();
		};

		StatusBar statusBar = new([
			new Shortcut(Key.Esc, "Quit", () => app.RequestStop()),
		]);

		Window window = new() { Title = "ToolBox (Esc to quit)" };
		window.Add(view);
		window.Add(outPanel);
		window.Add(statusBar);

		app.Run(window);
	}
}
