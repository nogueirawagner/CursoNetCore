using System;

namespace Curso.Domain.Models.Base
{
    public abstract class Entity<T> where T : Entity<T>
    {
        public Guid Id { get; set; }
    }
}
