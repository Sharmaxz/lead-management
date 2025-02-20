namespace LeadManagement.Domain.Events
{
	public class BaseEvent
	{
		public int Id { get; set; }             
		public string EventType { get; set; }   // Tipo do evento (ex: "LeadCreated", "UserUpdated")
		public DateTime Timestamp { get; set; }
		public string Data { get; set; }

		public BaseEvent() { }

		public BaseEvent(string eventType, string data)
		{
			EventType = eventType;
			Data = data;
			Timestamp = DateTime.UtcNow;
		}
	}
}
