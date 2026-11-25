using Microsoft.Extensions.Logging;

namespace SharedShadowRepro;

public static class WarningLog
{
	public static List<string> Messages { get; } = new();
}

public sealed class WarningLogProvider : ILoggerProvider
{
	public ILogger CreateLogger(string categoryName) => new WarningLogger(categoryName);

	public void Dispose() { }

	sealed class WarningLogger(string category) : ILogger
	{
		public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

		public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Warning;

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			if (!IsEnabled(logLevel))
				return;

			var message = $"[{logLevel}] {category}: {formatter(state, exception)}";
			WarningLog.Messages.Add(message);
			Console.WriteLine(message);
		}
	}
}
