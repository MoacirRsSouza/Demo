using Demo.Prova.Core.Entities;
using System.Collections.Generic;

namespace Demo.Prova.Core.IRepositorys
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(int id);

        IList<TEntity> Select();

        TEntity Select(int id);
    }
}
