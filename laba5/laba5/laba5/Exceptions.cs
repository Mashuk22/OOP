using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5
{
    public class Exceptions
    {
        public class WrongDataException : Exception
        {
            
            public WrongDataException() : base() { }
            public WrongDataException(string message) : base(message) { }

        }

        public class NegativeNumberException : WrongDataException
        {
            public NegativeNumberException() : base() { }
            public NegativeNumberException(string message) : base(message) { }
        }

        public class NoProductNameException : WrongDataException
        {
            public NoProductNameException() : base() { }
            public NoProductNameException(string message) : base(message) { }
        }
    }
}
