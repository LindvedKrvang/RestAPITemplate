using System.Collections.Generic;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL
{
    public interface  IRepository<TEntity> where TEntity : class
    {
        //C
        TEntity Create(TEntity entity);
        
        //R
        List<TEntity> GetAll();
        TEntity Get(int id);
        List<TEntity> Search(string searchQuery);

        //D
        TEntity Delete(int idToRemove);

        void ClearAll();
    }
}
