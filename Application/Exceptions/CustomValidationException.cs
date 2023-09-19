using FluentValidation.Results;

namespace Application.Exceptions;

public class CustomValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public CustomValidationException() : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public CustomValidationException(IEnumerable<ValidationFailure> validationFailures) : this()
    {
        Errors = validationFailures
            .GroupBy(validationFailure => validationFailure.PropertyName,
                validationFailure => validationFailure.ErrorMessage)

            .ToDictionary(failureGroup => failureGroup.Key, 
                failureGroup => failureGroup.ToArray());
    }
}