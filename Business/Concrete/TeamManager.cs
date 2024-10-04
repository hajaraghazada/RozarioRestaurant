using Business.Abstract;
using Core.DataRepositories.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTeamMember(Team teamMember)
        {
            var teamRepository = _unitOfWork.GetRepository<Team>();
            teamRepository.Add(teamMember);
            _unitOfWork.SaveChanges(); 
        }

        public void DeleteTeamMember(int id)
        {
            var teamRepository = _unitOfWork.GetRepository<Team>();
            var teamMember = teamRepository.GetById(id);

            if (teamMember != null)
            {
                teamRepository.Delete(teamMember);
                _unitOfWork.SaveChanges(); 
            }
        }

        public string? GetTeamMemberById(int id)
        {
            var teamRepository = _unitOfWork.GetRepository<Team>();
            var teamMember = teamRepository.GetById(id);

            if (teamMember != null)
            {
                return teamMember.Name; 
            }

            return null;
        }

        public List<TeamDto> GetTeams()
        {
            var teamRepository = _unitOfWork.GetRepository<Team>();
            return teamRepository.GetAll().Select(p => new TeamDto
            {
                ID = p.ID,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Speciality = p.Speciality,
            }).ToList();
        }

        public void UpdateTeamMember(Team teamMember)
        {
            var teamRepository = _unitOfWork.GetRepository<Team>();
            teamRepository.Update(teamMember);
            _unitOfWork.SaveChanges(); 
        }
    }
}
