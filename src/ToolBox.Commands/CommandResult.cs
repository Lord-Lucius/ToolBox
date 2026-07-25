namespace ToolBox.Commands {
	public record CommandResult(int ExitCode, string Output = "", string Error = "") {

		public static CommandResult Ok(string output) => new(0, output, "");

		public static CommandResult Fail(string message, int code) => new(code, "", message);
	}
}
