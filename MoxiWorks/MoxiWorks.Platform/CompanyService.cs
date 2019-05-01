using System.Collections.Generic;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;
namespace MoxiWorks.Platform
{

    /// <summary>
    /// Finding an Company using the Moxi Works platform.
    /// </summary>
    public class CompanyService : ICompanyService
    {
        public IMoxiWorksClient Client { get; set; }

        public CompanyService(IMoxiWorksClient client)
        {
            Client = client; 
        }

        /// <summary>
        /// Finding an Company using the Moxi Works platform.
        /// </summary>
        /// <param name="moxiWorksCompanyId">
        /// A valid Moxi Works Company ID. Use Company Endpoint to 
        /// determine what MoxiWorksCompanyId you can use.
        /// </param>
        /// <returns>a company or and empty Company object</returns>
        public async Task<Response<Company>> GetCompanyAsync(string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"/companies/{moxiWorksCompanyId}");
            return await Client.GetRequestAsync<Company>(builder.GetUrl());
        }

        /// <summary>
        /// Synchronous wrapper for GetCompanyAsync
        /// </summary>
        public Response<Company> GetCompany(string moxiWorksCompanyId)
        {
            return System.Threading.Tasks.Task.Run(() => GetCompanyAsync(moxiWorksCompanyId)).Result;

        }

        /// <summary>
        /// Returns CompanyResults that contains associated Companies for the request query
        /// </summary>
        /// <returns>List of Companies and associated company ids that you can use.</returns>
        public async Task<Response<List<Company>>> GetCompaniesAsync()
        {
            var builder = new UriBuilder($"companies");
            return await Client.GetRequestAsync<List<Company>>(builder.GetUrl());
        }

        /// <summary>
        /// Synchronous wrapper for GetCompaniesAsync
        /// </summary>
        public Response<List<Company>> GetCompanies()
        {
            return System.Threading.Tasks.Task.Run(() => GetCompaniesAsync()).Result;

        }

    }
}
