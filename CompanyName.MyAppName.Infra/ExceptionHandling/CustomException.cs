using System;

namespace CompanyName.MyAppName.Infra
{
    /// <summary>
    /// Provides member to handle custom exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CustomException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        public CustomException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CustomException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<see langword="Nothing" /> in Visual Basic) if no inner exception is specified.</param>
        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
