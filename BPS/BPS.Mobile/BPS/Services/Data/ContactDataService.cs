using System;
using System.Threading.Tasks;
using Akavache;
using BPS.Core.Constants;
using BPS.Core.Contracts.Repository;
using BPS.Core.Contracts.Services.Data;
using BPS.Core.Models;

namespace BPS.Core.Services.Data
{
    public class ContactDataService : BaseService, IContactDataService
    {
        private readonly IGenericRepository _genericRepository;

        public ContactDataService(IGenericRepository genericRepository, IBlobCache cache = null) : base(cache)
        {
            _genericRepository = genericRepository;
        }

        public async Task<ContactInfo> AddContactInfo(ContactInfo contactInfo)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.AddContactInfoEndpoint
            };

            var result = await _genericRepository.PostAsync(builder.ToString(), contactInfo);

            return result;
        }
    }
}
