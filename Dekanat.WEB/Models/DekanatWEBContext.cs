using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dekanat.WEB.Models
{
    public class DekanatWEBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DekanatWEBContext() : base("name=DekanatWEBContext")
        {
        }

        public System.Data.Entity.DbSet<Dekanat.WEB.Models.StudentViewModel> StudentViewModels { get; set; }

        public System.Data.Entity.DbSet<Dekanat.WEB.Models.DormitoryViewModel> DormitoryViewModels { get; set; }

        public System.Data.Entity.DbSet<Dekanat.WEB.Models.GroupViewModel> GroupViewModels { get; set; }
    }
}
