
using EtfragApp.BLL.DTOs.Actor;
using EtfragApp.BLL.DTOs.Pages;
using EtfragApp.BLL.FileManagement;
using EtfragApp.BLL.Interfaces;
using EtfragApp.BLL.ServicesContracts;
using EtfragApp.DAL.Entities;

namespace EtfragApp.BLL.Sevices
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(CreateActorDto actorDto)
        {
            Actor actor = new Actor
            {
                FirstName = actorDto.FirstName,
                LastName = actorDto.LastName,
                Nationality = actorDto.Nationality,
                ProfilePictureUrl = DocumentsSettings.UploadFile(actorDto.ProfilePicture, "Actors")
            };

            _unitOfWork.ActorRepository.AddEntity(actor);

            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            Actor actor = _unitOfWork.ActorRepository.GetEntityById(id);
            DocumentsSettings.DeleteFile(actor.ProfilePictureUrl, "Actors");

            _unitOfWork.ActorRepository.DeleteEntity(id);
            _unitOfWork.Save();
        }

        public IEnumerable<Actor> GetAll()
        {
            return _unitOfWork.ActorRepository.GetAll();
        }

        public Actor GetById(int id)
        {
            return _unitOfWork.ActorRepository.GetEntityById(id);
        }

        public List<TResult> GetData<TResult>(Func<Actor, TResult> selector)
        {
            return _unitOfWork.ActorRepository.GetEntityData<TResult>(selector);
        }

        public IEnumerable<ActorDto> GetSpecificNumOfRecordsDescending(int num)
        {
            var actors = _unitOfWork.ActorRepository.GetSpecificNumOfRecordsDescending(num);

            return actors.Select(a => new ActorDto
            {
                ActorId = a.ActorId,
                AddedAt = a.AddedAt,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Nationality = a.Nationality,
                ProfilePictureUrl = a.ProfilePictureUrl,
            }
            );
        }

        public void Update(EditActorDto actorDto)
        {
            Actor actor = _unitOfWork.ActorRepository.GetEntityById(actorDto.Id);

            actor.FirstName = actorDto.FirstName;
            actor.LastName = actorDto.LastName;
            actor.Nationality = actorDto.Nationality;

            if (actorDto.ProfilePicture != null)// the image changed
            {
                // remove the old image 
                DocumentsSettings.DeleteFile(actor.ProfilePictureUrl, "Actors");

                // add the new image 
                actor.ProfilePictureUrl = DocumentsSettings.UploadFile(actorDto.ProfilePicture, "Actors");
            }

            _unitOfWork.ActorRepository.UpdateEntity(actor);
            _unitOfWork.Save();
        }

        public int GetTotalActorFilmsCount(int actorId)
        {
            return _unitOfWork.ActorRepository.GetTotalActorFilmsCount(actorId);
        }

        public int GetTotalActorSeriesCount(int actorId)
        {
            return _unitOfWork.ActorRepository.GetTotalActorSeriesCount(actorId);
        }

        public PageData<ActorDto> Getpage(int pageSize, int pageNo, bool needCount)
        {
            int? totalCount;
            var actors = _unitOfWork.ActorRepository.Getpage(pageSize, pageNo, out totalCount, needCount);

            return new PageData<ActorDto>
            {
                Data = actors.Select(actor => new ActorDto
                {
                    ActorId = actor.ActorId,
                    FirstName = actor.FirstName,
                    LastName = actor.LastName,
                    Nationality = actor.Nationality,
                    ProfilePictureUrl = actor.ProfilePictureUrl,
                    AddedAt = actor.AddedAt

                }).ToList(),
                TotalRecords = totalCount
            };
        }

        public PageData<ActorDto> GetPageWithSearch(int pageSize, int pageNo, bool needCount,string searchName)
        {
            int? totalCount;
            var actors = _unitOfWork.ActorRepository.GetPageWithSearch(pageSize, pageNo, out totalCount, needCount, searchName);

            return new PageData<ActorDto>
            {
                Data = actors.Select(actor => new ActorDto
                {
                    ActorId = actor.ActorId,
                    FirstName = actor.FirstName,
                    LastName = actor.LastName,
                    Nationality = actor.Nationality,
                    ProfilePictureUrl = actor.ProfilePictureUrl,
                    AddedAt = actor.AddedAt

                }).ToList(),
                TotalRecords = totalCount
            };
        }

    }
}