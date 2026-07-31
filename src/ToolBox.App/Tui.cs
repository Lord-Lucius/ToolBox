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

			Window window = new() { Title = "ToolBox (Esc to quit)" };
			Label label = new()
			{
				Text = "Hello, Terminal.Gui v2",
				X = Pos.Center(),
				Y = Pos.Center()
			};
			window.Add(label);
			app.Run(window);
		}
	}
}
