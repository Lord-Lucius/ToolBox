using ToolBox.Core;

namespace ToolBox.Tests;

public class CyclicPatternTests
{
	[Fact]
	public void Generate8Pattern()
	{
		string s = CyclicPattern.Generate(8);

		Assert.Equal(8, s.Length);
		Assert.Equal("Aa0Aa1Aa", s);
	}

	[Fact]
	public void Generate3Pattern()
	{
		string s = CyclicPattern.Generate(3);

		Assert.Equal(3, s.Length);
		Assert.Equal("Aa0", s);
	}

	[Fact]
	public void Generate0Pattern()
	{
		string s = CyclicPattern.Generate(0);

		Assert.Equal(0, s.Length);
		Assert.Equal("", s);
	}
}
