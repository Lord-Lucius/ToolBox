using Xunit;
using ToolBox.Commands.Commands;
using ToolBox.Core;

namespace ToolBox.Tests.commands;

public class HelloCommandTests
{
	[Fact]
	public void HelloCommandCallGreeting()
	{
		var cmd = new HelloCommand().Execute([]);
		Assert.Equal(Greeting.Build(), cmd.Output);
		Assert.Equal(0, cmd.ExitCode);
		Assert.Equal("", cmd.Error);
	}
}
