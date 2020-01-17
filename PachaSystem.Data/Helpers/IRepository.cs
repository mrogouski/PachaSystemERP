// <copyright file="IRepository.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity Get(Expression<Func<TEntity, bool>> expression = null);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}