using Curso.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Curso.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        TEntity PegarPorId(Guid id);
        IEnumerable<TEntity> PegarTodos();
        IEnumerable<TEntity> Pegar(Expression<Func<TEntity, bool>> predicate);
        void Remover(Guid id);
        void Remover(List<Guid> ids);
        int SaveChanges();
        void Dispose();
    }
}
