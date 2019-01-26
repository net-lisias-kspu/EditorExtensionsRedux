using System.Diagnostics;
using KSPe.Util.Log;

namespace EditorExtensionsRedux
{
	public static class Log
	{
		private static readonly Logger logger = Logger.CreateForType<EditorExtensions>();

		[Conditional("DEBUG")]
		public static void Debug (string message)
		{
			logger.dbg(message);
		}
		[Conditional("DEBUG")]
		public static void Info(string message)
		{
			logger.info(message);
		}

		public static void Error(string message)
		{
			logger.error(message);
		}

		public static void Warn(string message)
		{
			logger.warn(message);
		}
	}
}

