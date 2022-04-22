using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SITHEC.Application.Common.Exceptions
{
    public class SITHECValidationException : ApplicationException
    {
        public SITHECValidationException() : base("Se presentaron uno o más errores de validación")
               => Errors = new Dictionary<string, string[]>();

        public SITHECValidationException(IEnumerable<ValidationFailure> failures) : this()
            => Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup
                                .ToArray());
        public IDictionary<string, string[]> Errors { get; }
    }
}
