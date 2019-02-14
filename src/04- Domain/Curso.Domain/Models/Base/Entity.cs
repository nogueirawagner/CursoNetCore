using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Curso.Domain.Models.Base
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public Entity()
        {
            ValidationResult = new ValidationResult();
            ValidationErrors = new List<string>();
        }

        public Guid Id { get; set; }

        // Validações
        public abstract bool EhValido();
        public ValidationResult ValidationResult { get; protected set; }
        public List<string> ValidationErrors { get; protected set; }
    }
}
