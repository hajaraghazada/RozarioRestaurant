using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITagService
    {
        void AddTag(Tag tag);
        void DeleteTag(int id);
        List<TagDto> GetAllTags();
        string? GetTagById(int id);
        void UpdateTag(Tag tag);
    }
}
