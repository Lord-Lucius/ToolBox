using System.Collections.ObjectModel;
using Terminal.Gui.App;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;
using ToolBox.Commands;


namespace ToolBox.App
{
	public class Tui
	{
		static public void Run_tui(CommandRegistry registry)
		{
			using IApplication app = Application.Create();

			app.Init();

			ListView view = new()
			{
				X = 0,
				Y = 0,
				Width = Dim.Percent(30),
				Height = Dim.Fill()
			};
			view.SetSource(new ObservableCollection<string>(registry.All().Select(x => x.Name)));

			Label out_panel = new()
			{
				X = Pos.Right(view),
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill(),
				Text = "Placeholder to replace"
			};

			StatusBar status_bar = new()
			{

			};

			Window window = new() { Title = "ToolBox (Esc to quit)" };
			window.Add(view);
			window.Add(out_panel);
			app.Run(window);
		}
	}
}
