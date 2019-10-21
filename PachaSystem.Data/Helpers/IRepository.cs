// <copyright file="IRepository.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity Obtener(Expression<Func<TEntity, bool>> filtro = null);

        IEnumerable<TEntity> ObtenerTodos(Expression<Func<TEntity, bool>> filtro = null);

        void Agregar(TEntity entidad);

        void Remover(TEntity entidad);
    }
}
