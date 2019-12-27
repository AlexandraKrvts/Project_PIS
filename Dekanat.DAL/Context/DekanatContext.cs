using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dekanat.DAL.Entities;
using Dekanat.DAL.Interfaces;

namespace Dekanat.DAL.Context
{
     public class DekanatContext : DbContext, IDekanatContext
    {
        public DekanatContext() : base("DevConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DekanatContext>());

            //this.context.Dormitories.Add(new Dormitory {Number = 20, Amount_of_rooms = 500, Amount_of_students = 2000 });

            // Dormitories.Add(new Dormitory { Number = 4, Amount_of_rooms = 250, Amount_of_students = 800 });
           // Dormitories.Add(new Dormitory { Number = 3, Amount_of_rooms = 300, Amount_of_students = 900 });
          

        }
        public DbSet<Dormitory> Dormitories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

      
        void IDekanatContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
