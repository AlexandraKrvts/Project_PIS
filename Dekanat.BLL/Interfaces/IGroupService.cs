using Dekanat.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dekanat.BLL.Interfaces
{
    public interface IGroupService
    {
        List<GroupDTO> GetAllGroups();

        void AddGroup(GroupDTO model);
        GroupDTO GetGroupById(int GroupId);
        void UpdateGroup(GroupDTO newGroup);
        void DeleteGroup(int groupId);
        List<GroupDTO> SearchByFaculty(string faculty);
        List<GroupDTO> SearchByName(string nam);
    }
}
