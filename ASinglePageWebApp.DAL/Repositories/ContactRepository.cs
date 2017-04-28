using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASinglePageWebApp.Model;

namespace ASinglePageWebApp.DAL.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(ContactContext context) : base(context)
        {
            
        }
    }

    public interface IContactRepository : IGenericRepository<Contact>
    {

    }
}
