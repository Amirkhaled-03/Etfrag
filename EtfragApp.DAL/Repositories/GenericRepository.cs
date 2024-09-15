using EtfragApp.BLL.Interfaces;
using EtfragApp.DAL.Context;
using EtfragApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Repositories
{
    public class GenericRepository
        <TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly CinemaAppContextMVC _context;
        protected readonly DbSet<TEntity> _dbSet;
        public GenericRepository(CinemaAppContextMVC context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void AddEntity(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public int AddEntityWithReturnID(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return (int)entity.GetType().GetProperty("Id").GetValue(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void DeleteEntity(int id)
        {
            TEntity entity = _dbSet.Find(id);

            if (entity != null)
                _dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
         => _context.Set<TEntity>().ToList();

        public IEnumerable<TEntity> GetAllDesc()
         => _context.Set<TEntity>().OrderByDescending(e => e.AddedAt).ToList();

        public TEntity GetEntityById(int id)
         => _dbSet.Find(id);

        public void UpdateEntity(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public List<TResult> GetEntityData<TResult>(Func<TEntity, TResult> selector)
        {
            return _dbSet.Select(selector).ToList();
        }

        public IEnumerable<TEntity> GetSpecificNumOfRecordsDescending(int num)
            => _context.Set<TEntity>()
            .OrderByDescending(a => a.AddedAt)
            .Take(num)
            .ToList();

        // Explicit loading method
        public TEntity GetEntityAndRelatsById(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            var entity = _dbSet.Find(id);

            // If the entity is not null, explicitly load related data
            if (entity != null)
            {
                foreach (var include in includes)
                {
                    var memberExpression = include.Body as MemberExpression ?? ((UnaryExpression)include.Body).Operand as MemberExpression;

                    // Check if the navigation property is a collection or reference
                    var navigation = _context.Entry(entity).Navigations.FirstOrDefault(n => n.Metadata.Name == memberExpression.Member.Name);

                    if ((navigation?.Metadata.IsCollection) == true)
                    {
                        // Load a collection
                        _context.Entry(entity).Collection(memberExpression.Member.Name).Load();
                    }
                    else
                    {
                        // Load a reference
                        _context.Entry(entity).Reference(memberExpression.Member.Name).Load();
                    }
                }
            }
            return entity;
        }

        public IEnumerable<TEntity> Getpage(int pageSize, int pageNo, out int? count, bool needTotalCount)
        {
            count = needTotalCount ? _dbSet.Count() : null;

            return _dbSet.Skip((pageNo - 1) * pageSize).Take(pageSize);
        }

      


    }
}
