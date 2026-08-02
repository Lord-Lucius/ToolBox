using System.Text;
namespace ToolBox.Core;

public class CyclicPattern
{
	public static string Generate(int length)
	{
		if (length <= 0)
			return "";

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

					if (str.Length >= length)
						return str.ToString()[..length];
				}
			}
		}

		if (length > str.Length)
			return str.ToString();

		return str.ToString()[..length];
	}


	public static int FindOffset(string input)
	{
		string pattern = Generate(20280);

		string needle;

		if (input.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
		{
			needle = HexToLittleEndianString(input);
		}
		else
		{
			needle = input;
		}

		return pattern.IndexOf(needle, StringComparison.Ordinal);
	}


	private static string HexToLittleEndianString(string hex)
	{
		hex = hex[2..];

		uint value = Convert.ToUInt32(hex, 16);

		byte[] bytes = BitConverter.GetBytes(value);

		return Encoding.Latin1.GetString(bytes);
	}
}
