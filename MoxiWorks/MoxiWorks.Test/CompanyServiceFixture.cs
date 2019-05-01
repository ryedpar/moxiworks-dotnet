using System;
using System.Collections.Generic;
using MoxiWorks.Platform;
using MoxiWorks.Platform.Interfaces;
using Xunit;

namespace MoxiWorks.Test
{
    public class CompanyServiceFixture
    {
        [Fact]
        public void ShouldReturnACompany()
        {
            var companyJson = StubDataLoader.LoadJsonFile("Company.json");  
           
            ICompanyService service = new CompanyService(new MoxiWorksClient(new StubContextClient(companyJson)));

            var response = service.GetCompanyAsync("some_moxiworks_company_id").Result;
            Assert.IsType<Company>(response.Item);
            Assert.NotNull(response.Item.MoxiWorksCompanyId);
            Assert.NotNull(response.Item.Name);
        }

        [Fact]
        public void ShouldReturnACompanySync()
        {
            var companyJson = StubDataLoader.LoadJsonFile("Company.json");

            ICompanyService service = new CompanyService(new MoxiWorksClient(new StubContextClient(companyJson)));

            var response = service.GetCompany("some_moxiworks_company_id");
            Assert.IsType<Company>(response.Item);
            Assert.NotNull(response.Item.MoxiWorksCompanyId);
            Assert.NotNull(response.Item.Name);

        }

        [Fact]
        public void ShouldReturnACollectionOfCompanies()
        {
            var companyJson = StubDataLoader.LoadJsonFile("Companies.json");

            ICompanyService service = new CompanyService(new MoxiWorksClient(new StubContextClient(companyJson)));

            var response = service.GetCompaniesAsync().Result;
            Assert.IsType<List<Company>>(response.Item);
            Assert.True(response.Item.Count == 1);
            Assert.NotNull(response.Item[0].MoxiWorksCompanyId);
            Assert.NotNull(response.Item[0].Name);
            
        }
        
        [Fact]
        public void ShouldReturnACollectionOfCompaniesSync()
        {
            var companyJson = StubDataLoader.LoadJsonFile("Companies.json");

            ICompanyService service = new CompanyService(new MoxiWorksClient(new StubContextClient(companyJson)));

            var response = service.GetCompanies();
            Assert.IsType<List<Company>>(response.Item);
            Assert.True(response.Item.Count == 1);
            Assert.NotNull(response.Item[0].MoxiWorksCompanyId);
            Assert.NotNull(response.Item[0].Name);

        }
    }
}