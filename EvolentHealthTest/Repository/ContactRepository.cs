using EvolentHealthTest.DbContexts;
using EvolentHealthTest.Entities;
using EvolentHealthTest.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentHealthTest.Repository
{
    /// <summary>
    /// Item repository
    /// </summary>
    public class ContactRepository : Repository, IContactRepository
    {
        #region Private Member

        private readonly EvolentHealthDatabaseContext _dbContext;

        #endregion

        #region Public Constructor

        public ContactRepository(EvolentHealthDatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public async Task<List<Contact>> GetAllItemAsync()
        {
            var query = _dbContext.contacts
                .AsNoTracking();

            var contacts = await query.ToListAsync();

            return new List<Contact>(contacts);
        }

        public async Task<Contact> UpdateItemAsync(Contact contactDetails)
        {
            _dbContext.Entry(contactDetails).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return contactDetails;
        }

        public async Task<Contact> AddItemAsync(Contact contactDetails)
        {
            await _dbContext.contacts.AddAsync(contactDetails);
            return contactDetails;
        }

        public async Task<bool> DeleteItemAsync(string contact)
        {
            var ItemTobeDeleted = await _dbContext.contacts.Where(u => u.PhoneNumber.ToLower() == contact.ToLower())
             .FirstOrDefaultAsync();

            if (ItemTobeDeleted != null)
            {
                _dbContext.contacts.Remove(ItemTobeDeleted);
                return true;
            }

            return false;
        }

        public Task<bool> IsItemExistsAsync(string mailId)
        {
            return _dbContext.contacts?.AsNoTracking().AnyAsync(u => u.Email.ToLower() == mailId.ToLower());
        }

        public async Task<Contact> GetItemAsync(string email)
        {
            var Item = await _dbContext.contacts
            .AsNoTracking()
            .Where(u => u.Email.ToLower() == email.ToLower())
            .FirstOrDefaultAsync();

            return Item;
        }
        
        public async Task<Contact> GetContactAsync(string contact)
        {
            var Item = await _dbContext.contacts
            .AsNoTracking()
            .Where(u => u.PhoneNumber.ToLower() == contact.ToLower())
            .FirstOrDefaultAsync();

            return Item;
        }

        #endregion
    }
}
