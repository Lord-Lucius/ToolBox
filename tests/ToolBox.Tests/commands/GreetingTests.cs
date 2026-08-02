using Xunit;
using ToolBox.Core;

namespace ToolBox.Tests.commands;

public class GreetingTests
{
	[Fact]
	public void Build_ReturnsExpectedMessage()
	{
		var result = Greeting.Build();
		Assert.Equal("Hello from toolbox", result);
	}
}
