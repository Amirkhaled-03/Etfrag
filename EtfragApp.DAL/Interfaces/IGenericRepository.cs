using EtfragApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAllDesc();

        TEntity GetEntityById(int id);

        public void AddEntity(TEntity entity);
        public int AddEntityWithReturnID(TEntity entity);
        public void AddRange(IEnumerable<TEntity> entities);

        void UpdateEntity(TEntity entity);

        void DeleteEntity(int id);

        public IEnumerable<TEntity> GetSpecificNumOfRecordsDescending(int num);

        public List<TResult> GetEntityData<TResult>(Func<TEntity, TResult> selector);
        public TEntity GetEntityAndRelatsById(int id, params Expression<Func<TEntity, object>>[] includes);

        public IEnumerable<TEntity> Getpage(int pageSize, int pageNo, out int? count, bool needTotalCount);
        
    }
}
