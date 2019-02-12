using Curso.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.Domain.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : Entity<TEntity>
    {
    }
}
