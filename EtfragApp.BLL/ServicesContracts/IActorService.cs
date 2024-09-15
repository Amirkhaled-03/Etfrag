using EtfragApp.BLL.DTOs.Actor;
using EtfragApp.BLL.DTOs.Pages;
using EtfragApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.ServicesContracts
{
    public interface IActorService
    {
        public IEnumerable<Actor> GetAll();
        public Actor GetById(int id);
        public IEnumerable<ActorDto> GetSpecificNumOfRecordsDescending(int num);
        public List<TResult> GetData<TResult>(Func<Actor, TResult> selector);
        public void Add(CreateActorDto actor);
        public void Delete(int id);
        public void Update(EditActorDto actorDto);
        public int GetTotalActorFilmsCount(int actorId);
        public int GetTotalActorSeriesCount(int actorId);
        public PageData<ActorDto> Getpage(int pageSize, int pageNo, bool needCount);
        public PageData<ActorDto> GetPageWithSearch(int pageSize, int pageNo, bool needCount, string searchName);


    }
}
