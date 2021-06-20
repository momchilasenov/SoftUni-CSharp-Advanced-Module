using System;

namespace CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            InvalidUserInputException customException = new InvalidUserInputException();

            string userInput = Console.ReadLine();

            try
            {
                int.Parse(userInput);
            }
            catch (InvalidUserInputException ex)
            {
                throw new InvalidUserInputException() { UserInput = userInput }; 
                //setting the UserInput property value = userInput
            }
        }
    }
}
