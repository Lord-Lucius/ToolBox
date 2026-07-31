using System.Text;
using ToolBox.Commands;

namespace ToolBox.App;

public static class HelpText
{
    public static string Build(CommandRegistry registry)
    {
        var commands = registry.All()
            .OrderBy(c => c.Category)
            .ThenBy(c => c.Name)
            .ToList();

        if (commands.Count == 0)
            return "No commands available.\n";

        int width = commands.Max(c => c.Name.Length);

        var sb = new StringBuilder();
        sb.AppendLine("tbx <command> [args]");
        sb.AppendLine();

        foreach (var group in commands.GroupBy(c => c.Category))
        {
            sb.AppendLine($"{group.Key}:");
            foreach (var cmd in group)
                sb.AppendLine($"  {cmd.Name.PadRight(width)}  {cmd.Description}");
            sb.AppendLine();
        }

        return sb.ToString();
    }
}
