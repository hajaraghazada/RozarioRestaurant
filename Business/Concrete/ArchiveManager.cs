using Business.Abstract;
using Core.DataRepositories.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class ArchiveManager : IArchiveService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArchiveManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ArchiveDTO> GetAllArchives()
        {
           IBaseRepository<Archive> archiveRepository = _unitOfWork.GetRepository<Archive>();
            return archiveRepository.GetAll().Select(p=> new ArchiveDTO
            {
                ID = p.ID,
                YearMonth=p.YearMonth
            }).ToList();
        }
    }
}
