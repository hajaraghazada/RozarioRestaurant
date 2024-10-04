using Business.Abstract;
using Core.DataRepositories.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<TeamDto> GetTeams()
        {
            IBaseRepository<Team> teamRepository = _unitOfWork.GetRepository<Team>();   
            return teamRepository.GetAll().Select(p=> new TeamDto 
            { 
                ID = p.ID,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Speciality = p.Speciality,
            
            }).ToList();

        }
    }
}
