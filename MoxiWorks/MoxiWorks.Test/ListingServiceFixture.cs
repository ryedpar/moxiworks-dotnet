﻿using System;
using MoxiWorks.Platform;
using Xunit;

namespace MoxiWorks.Test
{
    public class ListingServiceFixture
    {
        [Fact]
        public void ShouldReturnACollectionOfListings()
        {
            var listingJson = StubDataLoader.LoadJsonFile("listings.json");  
           
            var service = new ListingService(new MoxiWorksClient(new StubContextClient(listingJson)));

            var response = service.GetListingsUpdatedSinceAsync("moxi_works_company_id", AgentIdType.AgentUuid,"some_uuid",DateTime.Now).Result;
            Assert.IsType<ListingResults>(response.Item);
            Assert.True(response.Item.Listings.Count == 1);
        }
        
     
          
    }
}