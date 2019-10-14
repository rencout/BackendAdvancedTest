using BackendAdvancedTest.ViewModel;
using Liquid.Base.Domain;
using Liquid.Domain;
using Liquid.Domain.API;
using Liquid.Runtime;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace BackendAdvancedTest.UnitTest
{
    /// <summary>
    /// BackendAdvancedUnitTest test class
    /// </summary>
    public partial class BackendAdvancedUnitTest : IClassFixture<LightApiMock<Startup>>
    {
        readonly LightApiMock<Startup> _lightTest;

        /// <summary>
        /// Constructor for unit tests
        /// </summary>
        /// <param name="lightTest"></param>
        public BackendAdvancedUnitTest(LightApiMock<Startup> lightTest)
        {
            _lightTest = lightTest;
        }

        /// <summary>
        /// Unit Test validate playlistByCoordinate
        /// </summary>s
        [Fact]
        public void PlaylistByCityNameTest()
        {
            //Arrange
            HttpStatusCode expectedResultCode = HttpStatusCode.OK;
            LightApi api = _lightTest.GetLightApi("PlaylistSuggest");
            CityVM mockData = new MockData().GetMockData<CityVM>(nameof(PlaylistByCityNameTest) + "_Request");

            //Action
            HttpResponseMessage response = api.PostAsync<HttpResponseMessage>($"/playlistByCityName", mockData.ToJsonCamelCase()).Result;
            DomainResponse domainResponse = response.ConvertToDomainAsync().Result;

            //Assert
            Assert.Equal(expectedResultCode, response.StatusCode);
            Assert.Empty(domainResponse.Critics);
            Assert.NotEmpty(domainResponse.PayLoad);
        }

        /// <summary>
        /// Unit Test validate playlistByCoordinate
        /// </summary>s
        [Fact]
        public void PlaylistByCoordinateTest()
        {
            //Arrange
            HttpStatusCode expectedResultCode = HttpStatusCode.OK;
            LightApi api = _lightTest.GetLightApi("PlaylistSuggest");
            CoordinateVM mockData = new MockData().GetMockData<CoordinateVM>(nameof(PlaylistByCoordinateTest) + "_Request");

            //Action
            HttpResponseMessage response = api.PostAsync<HttpResponseMessage>($"/playlistByCoordinate", mockData.ToJsonCamelCase()).Result;
            DomainResponse domainResponse = response.ConvertToDomainAsync().Result;

            //Assert
            Assert.Equal(expectedResultCode, response.StatusCode);
            Assert.Empty(domainResponse.Critics);
            Assert.NotEmpty(domainResponse.PayLoad);
        }
    }
}
