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


	[Fact]
	public void BeginOffset()
	{
		int index = CyclicPattern.FindOffset("Aa0A");

		Assert.Equal(0, index);
	}


	[Fact]
	public void FindOffset_MiddlePattern()
	{
		int index = CyclicPattern.FindOffset("Ab0A");

		Assert.Equal(30, index);
	}


	[Fact]
	public void FindOffset_LittleEndianHex()
	{
		int ascii = CyclicPattern.FindOffset("Aa0A");
		int hex = CyclicPattern.FindOffset("0x41306141");

		Assert.Equal(ascii, hex);
	}


	[Fact]
	public void FindOffset_NotFound()
	{
		int index = CyclicPattern.FindOffset("zzzz");

		Assert.Equal(-1, index);
	}
}
