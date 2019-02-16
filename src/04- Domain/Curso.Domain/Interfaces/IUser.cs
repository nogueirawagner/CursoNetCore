using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Curso.Domain.Interfaces
{
    public interface IUser
    {
        string Nome { get; }
        Guid GetUserId();
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
    