namespace ToolBox.Commands {
	public record CommandResult {
		public int ExitCode {get; init;}
		public string Output {get; init;}
		public string Error {get; init;}

		public CommandResult(int code, string output, string error) {
			ExitCode = code;
			Output = output;
			Error = error;
		}
	}

	static CommandResult Ok(string output) {
		return (CommandResult(0, output, ""));
	}

	static CommandResult Fail(string message, int code) {
		return (CommandResult(code, "", message));
	}
}
