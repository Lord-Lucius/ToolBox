using Xunit;
using ToolBox.Commands;
using ToolBox.Core;

namespace ToolBox.Tests;

public class CommandRegistryTests
{
	[Fact]
	public void MajusculeHUseHelloCommand()
	{
		var ret = new CommandRegistry().Run(["Hello"]);
		Assert.Equal(Greeting.Build(), ret.Output);
		Assert.Equal(0, ret.ExitCode);
		Assert.Equal("", ret.Error);
	}

	[Fact]
	public void MinusculeHUseHelloCommand()
	{
		var ret = new CommandRegistry().Run(["hello"]);
		Assert.Equal(Greeting.Build(), ret.Output);
		Assert.Equal(0, ret.ExitCode);
		Assert.Equal("", ret.Error);
	}

	[Fact]
	public void UnknownCommand()
	{
		var ret = new CommandRegistry().Run(["test"]);
		Assert.Equal("", ret.Output);
		Assert.Equal(127, ret.ExitCode);
		Assert.Equal("unknown command: test", ret.Error);
	}

	[Fact]
	public void Run_TooManyArguments_Fails()
	{
		var reg = new CommandRegistry();
		reg.Register(new TestCommandNoArgs());
		var ret = reg.Run(["noargs", "extra"]);
		Assert.Equal(2, ret.ExitCode);
		Assert.Equal("too many arguments", ret.Error);
	}

	[Fact]
	public void Run_MissingArguments_Fails()
	{
		var reg = new CommandRegistry();
		reg.Register(new TestCommandWithArgs());
		var ret = reg.Run(["withargs"]);
		Assert.Equal(2, ret.ExitCode);
		Assert.Equal("missing arguments", ret.Error);
	}

	[Fact]
	public void Run_Group_ExecutesSubCommand()
	{
		var reg = new CommandRegistry();
		reg.Register(new TestGroup());
		var ret = reg.Run(["grp", "sub"]);
		Assert.Equal(0, ret.ExitCode);
		Assert.Equal("sub ok", ret.Output);
	}

	[Fact]
	public void Run_Group_MissingSubCommand_Fails()
	{
		var reg = new CommandRegistry();
		reg.Register(new TestGroup());
		var ret = reg.Run(["grp"]);
		Assert.Equal(2, ret.ExitCode);
		Assert.Equal("missing subcommand for grp", ret.Error);
	}

	[Fact]
	public void Run_Group_UnknownSubCommand_Fails()
	{
		var reg = new CommandRegistry();
		reg.Register(new TestGroup());
		var ret = reg.Run(["grp", "nope"]);
		Assert.Equal(127, ret.ExitCode);
		Assert.Equal("unknown subcommand: nope", ret.Error);
	}

	// --- test doubles ---

	private class TestCommandNoArgs : IAction
	{
		public string Name => "noargs";
		public string Description => "test command";
		public string Category => "test";
		public IReadOnlyList<ParamSpec> Parameters => Array.Empty<ParamSpec>();
		public CommandResult Execute(IReadOnlyList<string> args) => CommandResult.Ok("noargs ok");
	}

	private class TestCommandWithArgs : IAction
	{
		public string Name => "withargs";
		public string Description => "test command";
		public string Category => "test";
		public IReadOnlyList<ParamSpec> Parameters => new ParamSpec[]
		{
			new("first", "desc"),
			new("second", "desc")
		};
		public CommandResult Execute(IReadOnlyList<string> args) => CommandResult.Ok("withargs ok");
	}

	private class TestSubCommand : IAction
	{
		public string Name => "sub";
		public string Description => "sub command";
		public string Category => "test";
		public IReadOnlyList<ParamSpec> Parameters => Array.Empty<ParamSpec>();
		public CommandResult Execute(IReadOnlyList<string> args) => CommandResult.Ok("sub ok");
	}

	private class TestGroup : IGroup
	{
		public string Name => "grp";
		public string Description => "test group";
		public string Category => "test";
		public IReadOnlyList<IAction> SubCommands => new IAction[] { new TestSubCommand() };
	}
}
