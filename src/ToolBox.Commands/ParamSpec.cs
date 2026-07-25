namespace ToolBox.Commands;

public record ParamSpec(string Name, string Description, bool Required = true, string Default = "");
