using Xunit;
using ToolBox.Commands;

namespace ToolBox.Tests;

public class CommandResultTests
{
	[Fact]
	public void Ok_SetsExitCodeZero()
	{
		var res = CommandResult.Ok("test");
		Assert.Equal("test", res.Output);
		Assert.Equal(0, res.ExitCode);
		Assert.Equal("", res.Error);
	}

	[Fact]
	public void Fail_SetsErrorAndCode()
	{
		var res = CommandResult.Fail("test", 2);
		Assert.Equal("", res.Output);
		Assert.Equal(2, res.ExitCode);
		Assert.Equal("test", res.Error);
	}
}
