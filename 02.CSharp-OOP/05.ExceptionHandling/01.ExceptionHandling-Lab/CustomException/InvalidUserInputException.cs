using System;
using System.Collections.Generic;
using System.Text;

namespace CustomException
{
    public class InvalidUserInputException : Exception
    {
        public InvalidUserInputException()
        {
        }

        public InvalidUserInputException(string message)
            :base(message)
        {
        }

        public InvalidUserInputException(Exception innerException)
            :base("Get inner exception", innerException)
        {
        }

        public string UserInput { get; set; } //get access to the user input
      


    }
}
