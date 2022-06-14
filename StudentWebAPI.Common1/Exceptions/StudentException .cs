using System;
using System.Collections.Generic;
using System.Text;

namespace Commonlibrary.Exceptions
{
    public class StudentException:Exception
    {
        public StudentException()
        {

        }

        public StudentException(string message) : base(message)
        {

        }

        public StudentException(string message, Exception innerEx) : base(message, innerEx)
        {

        }
    }
}
