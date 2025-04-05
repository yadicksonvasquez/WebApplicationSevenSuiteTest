using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationSevenSuiteTest.scriptsSQL
{
    public class ValidationException : Exception
    {
        public ValidationException() : base() { }

        public ValidationException(string message) : base(message) { }
    }
}