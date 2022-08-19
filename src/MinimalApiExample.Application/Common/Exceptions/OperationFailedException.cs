using MinimalApiExample.Application.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application.Common.Exceptions
{
    public class OperationFailedException : Exception
    {
        public OperationFailedException()
            : base(ErrorMessages.OperationFailed)
        {
            Source = "Application";
        }
    }
}
