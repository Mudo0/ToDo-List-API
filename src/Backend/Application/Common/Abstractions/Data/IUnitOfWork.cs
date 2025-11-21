using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Abstractions.Data
{
    /// <summary>
    /// Contrato para la unidad de trabajo que maneja las transacciones de la base de datos.
    /// </summary>
    public interface IUnitOfWork
    {
        //método a exponer para el handler
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}