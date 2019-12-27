using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dekanat.DAL.Entities;
using Dekanat.DAL.Interfaces.Repositories;
using Dekanat.DAL.Interfaces;

namespace Dekanat.DAL.Repositories
{
   public class DormitoryRep : IDormitoryRep
    {
        IDekanatContext context { get; set; }
        public DormitoryRep(IDekanatContext dekContext)
        {
            context = dekContext;
            //this.context.Dormitories.Add(new Dormitory {Id=1, Number = 20, Amount_of_rooms = 500, Amount_of_students = 1500 });
           //this.context.Dormitories.Add(new Dormitory { Id = 2, Number = 6, Amount_of_rooms =300, Amount_of_students = 500 });
          // this.context.Dormitories.Add(new Dormitory { Id = 3, Number = 2, Amount_of_rooms = 400, Amount_of_students = 800 });
             //this.context.Dormitories.Add(new Dormitory { Id = 4,Number = 14, Amount_of_rooms = 350, Amount_of_students = 1000 });
          // this.context.Dormitories.Add(new Dormitory { Id = 5, Number = 3, Amount_of_rooms = 420, Amount_of_students = 900});
           // this.context.Dormitories.Add(new Dormitory { Id = 6, Number = 17, Amount_of_rooms = 500, Amount_of_students = 800 });

          // context.SaveChanges();

        }
        public List<Dormitory> GetAllDormitories()
        {
           
            return this.context.Dormitories.ToList();
        }

        public Dormitory GetDormitoryById(int DormId)
        {
            return this.context.Dormitories.ToList().Find(x => x.Id == DormId);

        }

        public List<Dormitory> SearchByRoomsAmount(int amount)
        {
            List<Dormitory> Dormitories = new List<Dormitory>();
            var models = context.Dormitories.ToList();

            foreach (var model in models)
            {
                if (model.Amount_of_rooms==amount)
                {
                    Dormitories.Add(model);
                }
            }
            return Dormitories;
        }

        public void UpdateDormitory(Dormitory newDorm)
        {
            var oldDorm = GetDormitoryById(newDorm.Id);

            if (oldDorm == null)
            {
                return;
            }

            
            this.context.Dormitories.Remove(oldDorm);
            this.context.SaveChanges();
           newDorm.Number = oldDorm.Number;
            this.context.Dormitories.Add(newDorm);
            this.context.SaveChanges();
        }

        public List<Dormitory> SearchByNumber(int num)
        {
            List<Dormitory> dorms = new List<Dormitory>();
            var models = context.Dormitories.ToList();

            foreach (var model in models)
            {

                if (model.Number == num)
                {
                    dorms.Add(model);

                }
            }
            return dorms;
        }
    }
}
