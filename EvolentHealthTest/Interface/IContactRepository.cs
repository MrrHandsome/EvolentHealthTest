using EvolentHealthTest.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvolentHealthTest.Interface
{
    /// <summary>
    /// Contact repository
    /// </summary>
    public interface IContactRepository : IRepository
    {
        #region Methods

        Task<List<Contact>> GetAllItemAsync();
        Task<Contact> UpdateItemAsync(Contact contactDetail);
        Task<Contact> AddItemAsync(Contact contactDetail);
        Task<bool> DeleteItemAsync(string contact);
        Task<bool> IsItemExistsAsync(string mailId);

        Task<Contact> GetItemAsync(string email);

        Task<Contact> GetContactAsync(string contact);

        #endregion
    }
}
