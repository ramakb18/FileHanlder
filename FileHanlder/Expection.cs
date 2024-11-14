using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHanlder
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException() : base("Navn må ikke være tomt.") // "Name cannot be empty."
        {
        }
    }

    public class InvalidAgeException : Exception
    {
        public InvalidAgeException() : base("Alder skal være mellem 18 og 50.") // "Age must be between 18 and 50."
        {
        }
    }

    public class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base("E-mailen er ugyldig.") // "Email is invalid."
        {
        }

        public InvalidEmailException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
