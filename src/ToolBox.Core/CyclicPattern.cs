using System.Text;

namespace ToolBox.Core;

public class CyclicPattern
{
	public static string Generate(int lenght)
	{
		if (lenght <= 0) return "";

		StringBuilder str = new();

		for (char maj = 'A'; maj <= 'Z'; maj++)
		{
			for (char min = 'A'; min <= 'Z'; min++)
			{
				for (char n = '0'; n <= '9'; n++)
				{
					str.Append(maj);
					str.Append(min);
					str.Append(n);
					if (str.Length == lenght) return str.ToString();
				}

			}
		}

		return str.ToString()[lenght..];
	}

	public static void FindOffset(int value)
	{

	}
}
