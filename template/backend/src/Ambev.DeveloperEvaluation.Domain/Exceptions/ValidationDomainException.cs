using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;
using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Domain.Exceptions
{
    public class ValidationDomainException : ValidationException
    {
        public ValidationDomainException(IEnumerable<ValidationErrorDetail> errors)
            : base(errors.Select(e => new ValidationFailure { ErrorCode = e.Error, ErrorMessage = e.Detail })) { }
    }
}
