using System;
using System.Runtime.Serialization;

namespace brioche
{
	/// <summary>
	/// TypeNotRegisteredException is thrown when requesting an instance of a type
	/// not previously registered.
	/// </summary>
	[Serializable]
	public class TypeNotRegisteredException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the TypeNotRegisteredException class
		/// </summary>
		public TypeNotRegisteredException()
			: base()
		{
		}

		/// <summary>
		/// Initializes a new instance of the TypeNotRegisteredException class with the provided message
		/// </summary>
		/// <param name="message"></param>
		public TypeNotRegisteredException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the TypeNotRegisteredException class with a specified
		/// error message and a reference to the inner exception that is the cause of
		/// this exception.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="innerException"></param>
		public TypeNotRegisteredException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the TypeNotRegisteredException class with serialized data.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected TypeNotRegisteredException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
    }
}
