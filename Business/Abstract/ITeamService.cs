using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITeamService
    {
        void AddTeamMember(Team teamMember);
        void DeleteTeamMember(int id);
        string? GetTeamMemberById(int id);
        List<TeamDto>GetTeams();
        void UpdateTeamMember(Team teamMember);
    }
}
