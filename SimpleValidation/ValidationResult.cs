namespace SimpleValidation
{
    public class ValidationResult
    {
        public bool IsSuccess { get; set; }

        public static ValidationResult Success(string message = null)
        {
            return new ValidationResult
            {
                IsSuccess = true
            };
        }

        public static ValidationResult Failure(string message = null)
        {
            return new ValidationResult
            {
                IsSuccess = false
            };
        }
    }
}