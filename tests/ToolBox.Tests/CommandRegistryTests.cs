using ToolBox.Commands;
using ToolBox.Core;

namespace ToolBox.Tests;

public class CommandRegistryTests
{
	[Fact]
	public void MajusculeHUseHelloCommand()
	{
		var ret = new CommandRegistry().Run("Hello", []);
		Assert.Equal(Greeting.Build(), ret.Output);
		Assert.Equal(0, ret.ExitCode);
		Assert.Equal("", ret.Error);
	}

	[Fact]
	public void MinusculeHUseHelloCommand()
	{
		var ret = new CommandRegistry().Run("hello", []);
		Assert.Equal(Greeting.Build(), ret.Output);
		Assert.Equal(0, ret.ExitCode);
		Assert.Equal("", ret.Error);
	}

	[Fact]
	public void UnknownCommand()
	{
		var ret = new CommandRegistry().Run("test", []);
		Assert.Equal("", ret.Output);
		Assert.Equal(127, ret.ExitCode);
		Assert.Equal("unknown command: test", ret.Error);
	}

	private class TestCommandNoArgs : ICommand
	{
		public string Name => "noargs";
		public string Description => "test command";
		public string Category => "test";
		public IReadOnlyList<ParamSpec> Parameters => Array.Empty<ParamSpec>();

		public CommandResult Execute(IReadOnlyList<string> args)
			=> CommandResult.Ok("noargs ok");
	}

	private class TestCommandWithArgs : ICommand
	{
		public string Name => "withargs";
		public string Description => "test command";
		public string Category => "test";
		public IReadOnlyList<ParamSpec> Parameters => new ParamSpec[]
		{
			new("first", "desc"),
			new("second", "desc")
		};

		public CommandResult Execute(IReadOnlyList<string> args)
			=> CommandResult.Ok("withargs ok");
	}

	[Fact]
	public void Run_TooManyArguments_Fails()
	{
		var reg = new CommandRegistry();
		reg.Register(new TestCommandNoArgs());

		var ret = reg.Run("noargs", ["extra"]);

		Assert.Equal(2, ret.ExitCode);
		Assert.Equal("too many arguments", ret.Error);
		Assert.Equal("", ret.Output);
	}

	[Fact]
	public void Run_MissingArguments_Fails()
	{
		var reg = new CommandRegistry();
		reg.Register(new TestCommandWithArgs());

		var ret = reg.Run("withargs", []);

		Assert.Equal(2, ret.ExitCode);
		Assert.Equal("missing arguments", ret.Error);
		Assert.Equal("", ret.Output);
	}
}
