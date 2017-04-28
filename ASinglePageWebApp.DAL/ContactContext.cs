using ASinglePageWebApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASinglePageWebApp.DAL
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("ContactEntities")
        {

        }

        public DbSet<Contact> MyProperty { get; set; }
    }
}
