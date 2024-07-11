using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Sales_Web_Mvc.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        { 
        }
    }
}
