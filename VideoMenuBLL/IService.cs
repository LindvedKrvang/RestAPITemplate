using System.Collections.Generic;

namespace VideoMenuBLL
{
    public interface IService<TEntity>
    {
        //C
        TEntity Create(TEntity entity);

        List<TEntity> CreateAll(List<TEntity> entities);
        
        //R
        List<TEntity> GetAll();
        TEntity GetOne(int id);
        List<TEntity> Search(string searchQuery);

        //U
        void Update(TEntity entity);

        //D
        TEntity Delete(int idOfEntity);

        void ClearAll();
    }
}
