﻿using System;


namespace WebApplicationSevenSuiteTest.exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }

        public NotFoundException(string message) : base(message) { }
    }
}