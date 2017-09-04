using System.Collections.Generic;

namespace VideoMenuBLL
{
    public interface IService<TEntity>
    {
        //C
        TEntity Create(string nameOfEntity);

        List<TEntity> CreateAll(List<string> nameOfEntities);
        
        //R
        List<TEntity> GetAll();
        TEntity GetOne(int id);
        List<TEntity> Search(string searchQuery);

        //U
        void Update(TEntity video);

        //D
        TEntity Delete(int idOfVideo);

        void ClearAll();
    }
}
