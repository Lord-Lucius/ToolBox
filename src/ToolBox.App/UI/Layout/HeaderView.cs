using Terminal.Gui.ViewBase;

namespace ToolBox.App.UI.Layout;

public class HeaderView : View
{
	private readonly Label _shell;

	public HeaderView()
	{
		_title = new Label { Text = "Header" };
		Add(_title);
	}

	public void SetTitle(string text) => _title.Text = text;
}

