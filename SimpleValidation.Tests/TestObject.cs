using System;

namespace SimpleValidation.Tests
{
    public class TestObject
    {
        public DateTime Date { get; set; }

        public DateTime? NullDate { get; set; }

        public string String { get; set; }

        public string Email { get; set; }

        public TestObject Parent { get; set; }
    }
}