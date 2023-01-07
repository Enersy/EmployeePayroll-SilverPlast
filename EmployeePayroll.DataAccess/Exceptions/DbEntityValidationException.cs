using System.Runtime.Serialization;

namespace EmployeePayroll.DataAccess.Exceptions
{
    [Serializable]
    internal class DbEntityValidationException : Exception
    {
        public DbEntityValidationException()
        {
        }

        public DbEntityValidationException(string? message) : base(message)
        {
        }

        public DbEntityValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DbEntityValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IEnumerable<object> EntityValidationErrors { get; internal set; }
    }
}