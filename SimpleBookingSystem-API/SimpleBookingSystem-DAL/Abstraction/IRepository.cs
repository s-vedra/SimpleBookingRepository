﻿namespace SimpleBookingSystem_DAL.Abstraction
{
    public interface IRepository<T, K>
    {
        T GetEntity(K id);
        IQueryable<T> GetEntities();
        K AddEntity(T entity);
        void RemoveEntity(T entity);
        void UpdateEntity(T entity);
    }
}
