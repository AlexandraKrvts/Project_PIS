﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dekanat.DAL.Entities;
using Dekanat.DAL.Interfaces.Repositories;
using Dekanat.DAL.Interfaces;

namespace Dekanat.DAL.Repositories
{
    public class GroupRep : IGroupRep
    {
        IDekanatContext context;

        public GroupRep(IDekanatContext context)
        {
            this.context = context;
        }

        public void AddGroup(Group model)
        {
            this.context.Groups.Add(model);
            this.context.SaveChanges();
        }

        public void DeleteGroup(int groupId)
        {
            var model = GetGroupById(groupId);

            if (model == null)
            {
                return;
            }

            this.context.Groups.Remove(model);
            this.context.SaveChanges();
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return this.context.Groups.ToList();
        }

        public Group GetGroupById(int GroupId)
        {
            return this.context.Groups.ToList().Find(x => x.Id == GroupId);

        }

        public List<Group> SearchByFaculty(string faculty)
        {


            List<Group> groups = new List<Group>();
            var models = context.Groups.ToList();

            foreach (var model in models)
            {

                if (model.Faculty.ToLower().Contains(faculty))
                {
                    groups.Add(model);

                }
            }
                return groups;
            
        }

        public List<Group> SearchByName(string nam)
        {
            List<Group> groups = new List<Group>();
            var models = context.Groups.ToList();

            foreach (var model in models)
            {

                if (model.Name.ToLower().Contains(nam))
                {
                    groups.Add(model);

                }
            }
            return groups;
        }

        public void UpdateGroup(Group newGroup)
        {
            var oldGroup = GetGroupById(newGroup.Id);

            if (oldGroup == null)
            {
                return;
            }

            
            this.context.Groups.Remove(oldGroup);
            this.context.SaveChanges();
            newGroup.Name = oldGroup.Name;
            this.context.Groups.Add(newGroup);
            this.context.SaveChanges();
        }
    }
}
