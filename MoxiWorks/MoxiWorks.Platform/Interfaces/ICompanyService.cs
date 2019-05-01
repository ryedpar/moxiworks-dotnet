using System.Collections.Generic;
using System.Threading.Tasks;
namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    /// Wrapper around the service to allow stubbing of the service.
    /// </summary>
    public interface ICompanyService
    {
        IMoxiWorksClient Client { get; set; }
        Task<Response<Company>> GetCompanyAsync(string moxiWorksCompanyId);
        Response<Company> GetCompany(string moxiWorksCompanyId);
        Task<Response<List<Company>>> GetCompaniesAsync();
        Response<List<Company>> GetCompanies();
    }
}