namespace Sales_Web_Mvc.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base(message) 
        {
        }
    }
}
