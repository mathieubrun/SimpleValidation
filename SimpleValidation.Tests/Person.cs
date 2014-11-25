using System;

namespace SimpleValidation.Tests
{
    public class Person
    {
        public DateTime DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Person Parent { get; set; }
    }
}