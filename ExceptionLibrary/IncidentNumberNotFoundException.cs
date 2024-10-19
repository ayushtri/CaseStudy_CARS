namespace ExceptionLibrary
{

	[Serializable]
	public class IncidentNumberNotFoundException : Exception
	{
		public IncidentNumberNotFoundException() { }
		public IncidentNumberNotFoundException(string message) : base(message) { }
		public IncidentNumberNotFoundException(string message, Exception inner) : base(message, inner) { }
		protected IncidentNumberNotFoundException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
