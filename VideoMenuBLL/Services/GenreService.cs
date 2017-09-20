using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuBLL.Converters;
using VideoMenuDAL;

namespace VideoMenuBLL.Services
{
    internal class GenreService : IService<GenreBO>
    {
        private readonly GenreConverter _genreConverter = new GenreConverter();
        private readonly DalFacade _facade;

        public GenreService(DalFacade facade)
        {
            _facade = facade;
        }

        public GenreBO Create(GenreBO entity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genre = uow.GenreRepository.Create(_genreConverter.Convert(entity));
                uow.Complete();
                return _genreConverter.Convert(genre);
            }
        }

        public List<GenreBO> CreateAll(List<GenreBO> entities)
        {
            throw new NotImplementedException();
        }

        public List<GenreBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.GenreRepository.GetAll().Select(_genreConverter.Convert).ToList();
            }
        }

        public GenreBO GetOne(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return _genreConverter.Convert(uow.GenreRepository.Get(id));
            }
        }

        public List<GenreBO> Search(string searchQuery)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.GenreRepository.Search(searchQuery).Select(_genreConverter.Convert).ToList();
            }
        }

        public GenreBO Update(GenreBO entity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genre = uow.GenreRepository.Get(entity.Id);
                genre.Name = entity.Name;

                uow.Complete();
                return _genreConverter.Convert(genre);
            }
        }

        public GenreBO Delete(int idOfEntity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genre = uow.GenreRepository.Delete(idOfEntity);
                uow.Complete();
                return _genreConverter.Convert(genre);
            }
        }

        public void ClearAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                uow.GenreRepository.ClearAll();
                uow.Complete();
            }
        }
    }
}