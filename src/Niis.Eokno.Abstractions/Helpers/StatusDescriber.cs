using Niis.Eokno.Abstractions.Responses;

namespace Niis.Eokno.Abstractions.Helpers
{
	public static class StatusDescriber
	{
		public static Status Success()
		{
			return new Status
			{
				Code = "SCSS001",
				Message = "Message has been processed successfully"
			};
		}

		public static Status Failed()
		{
			return new Status
			{
				Code = "SCSE001",
				Message = "Failed to process message"
			};
		}
	}
}
