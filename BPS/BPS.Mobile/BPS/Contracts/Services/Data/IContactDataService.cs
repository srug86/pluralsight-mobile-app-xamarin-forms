using System.Threading.Tasks;
using BPS.Core.Models;

namespace BPS.Core.Contracts.Services.Data
{
    public interface IContactDataService
    {
        Task<ContactInfo> AddContactInfo(ContactInfo contactInfo);
    }
}
