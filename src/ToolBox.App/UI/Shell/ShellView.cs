using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;
using ToolBox.App.UI.Layout;

namespace ToolBox.App.UI.Shell;

public class ShellView : Window
{
	public HeaderView Header { get; }
	public SidebarView Sidebar { get; }
	public WorkspaceView Workspace { get; }
	public FooterView Footer { get; }

	public ShellView()
	{
		Title = "ToolBox (Esc to quit)";

		Header = new HeaderView
		{
			X = 0,
			Y = 0,
			Width = Dim.Fill(),
			Height = 1
		};

		Sidebar = new SidebarView
		{
			X = 0,
			Y = Pos.Bottom(Header),
			Width = Dim.Percent(30),
			Height = Dim.Fill(1)
		};

		Workspace = new WorkspaceView
		{
			X = Pos.Right(Sidebar),
			Y = Pos.Bottom(Header),
			Width = Dim.Fill(),
			Height = Dim.Fill(1)
		};

		Footer = new FooterView
		{
			X = 0,
			Y = Pos.AnchorEnd(1),
			Width = Dim.Fill(),
			Height = 1
		};

		Add(Header, Sidebar, Workspace, Footer);
	}
}
