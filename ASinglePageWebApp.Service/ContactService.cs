using ASinglePageWebApp.DAL;
using ASinglePageWebApp.DAL.Repositories;
using ASinglePageWebApp.Data.Common;
using ASinglePageWebApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASinglePageWebApp.Service
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository ContactRepository)
        {
            _contactRepository = ContactRepository;
        }

        public IEnumerable<Contact> GetAllContacts(int? page, int pageSize, out int totalCount)
        {
            var contacts = _contactRepository.GetPagedList(out totalCount, page, pageSize, null, null,
                new SortExpression<Contact>(s => s.ContactID, ListSortDirection.Ascending));
            return contacts;
        }

        public Contact GetContactById(int id)
        {
            return _contactRepository.GetById(id);
        }

        public IEnumerable<Contact> GetContactByName(string name)
        {
            return _contactRepository.GetMany(s => s.LastName.Contains(name) || s.FirstName.Contains(name)).ToList();
        }

        public Contact GetContactByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public void CreateContact(Contact contact)
        {
            _contactRepository.Add(contact);
            _contactRepository.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            _contactRepository.Update(contact);
            _contactRepository.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            var contact = _contactRepository.GetById(id);
            _contactRepository.Delete(contact);
            _contactRepository.SaveChanges();
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }
    }

    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts(int? page, int pageSize, out int totalCount);
        IEnumerable<Contact> GetAll();
        Contact GetContactById(int id);
        IEnumerable<Contact> GetContactByName(string name);
        Contact GetContactByCode(string employeeCode);
        void CreateContact(Contact student);
        void UpdateContact(Contact student);
        void DeleteContact(int id);
    }
}
