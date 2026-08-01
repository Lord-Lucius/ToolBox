using System.Text;

namespace ToolBox.Core;

public class CyclicPattern
{
	public static string Generate(int length)
	{
		if (length <= 0) return "";

		StringBuilder str = new();

		for (char maj = 'A'; maj <= 'Z'; maj++)
		{
			for (char min = 'a'; min <= 'z'; min++)
			{
				for (char n = '0'; n <= '9'; n++)
				{
					str.Append(maj);
					str.Append(min);
					str.Append(n);
					if (str.Length >= length) return str.ToString()[..length];
				}

			}
		}

		return str.ToString()[..length];
	}

	public static void FindOffset(int value)
	{

	}
}
