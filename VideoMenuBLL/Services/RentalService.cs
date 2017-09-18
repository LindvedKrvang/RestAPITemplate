using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuBLL.Converters;
using VideoMenuDAL;

namespace VideoMenuBLL.Services
{
    internal class RentalService : IService<RentalBO>
    {
        private readonly DalFacade _facade;
        private readonly RentalConverter _rentalConverter = new RentalConverter();
        private readonly VideoConverter _videoConverter = new VideoConverter();
        private readonly UserConverter _userConverter = new UserConverter();

        public RentalService(DalFacade facade)
        {
            _facade = facade;
        }

        public RentalBO Create(RentalBO entity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rental = uow.RentalRepository.Create(_rentalConverter.Convert(entity));
                uow.Complete();
                return _rentalConverter.Convert(rental);
            }
        }

        public List<RentalBO> CreateAll(List<RentalBO> entities)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentals = entities.Select(entity => _rentalConverter.Convert(uow.RentalRepository.Create(_rentalConverter.Convert(entity)))).ToList();
                uow.Complete();
                return rentals;
            }
        }

        public List<RentalBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.RentalRepository.GetAll().Select(_rentalConverter.Convert).ToList();
            }
        }

        public RentalBO GetOne(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rental = _rentalConverter.Convert(uow.RentalRepository.Get(id));
                rental.Video = _videoConverter.Convert(uow.VideoRepository.Get(rental.VideoId));
                rental.User = _userConverter.Convert(uow.UserRepository.Get(rental.UserId));
                return rental;
            }
        }

        public List<RentalBO> Search(string searchQuery)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.RentalRepository.Search(searchQuery).Select(_rentalConverter.Convert).ToList();
            }
        }

        public RentalBO Update(RentalBO entity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rental = uow.RentalRepository.Get(entity.Id);
                rental.From = entity.From;
                rental.To = entity.To;
                rental.UserId = entity.UserId;
                rental.VideoId = entity.VideoId;

                uow.Complete();
                return _rentalConverter.Convert(rental);
            }
        }

        public RentalBO Delete(int idOfEntity)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rental =_rentalConverter.Convert(uow.RentalRepository.Delete(idOfEntity));
                uow.Complete();
                return rental;
            }
        }

        public void ClearAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                uow.RentalRepository.ClearAll();
                uow.Complete();
            }
        }
    }
}