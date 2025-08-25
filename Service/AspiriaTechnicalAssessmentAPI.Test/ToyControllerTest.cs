using AspiriaTechnicalAssessment.Controllers;
using AspiriaTechnicalAssessment.Core.Toys.Toys.Application.Dto;
using AspiriaTechnicalAssessment.Core.Transversal.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace AspiriaTechnicalAssessmentAPI.Test
{
    public class ToyControllerTest : IClassFixture<WebApplicationFactory<ToyController>>
    {
        private readonly WebApplicationFactory<ToyController> _factory;

        public ToyControllerTest(WebApplicationFactory<ToyController> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Test to get all toys from the API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllTest()
        {
            using var client = _factory.CreateClient();

            PreloadData();
            var result = await client.GetAsync("/api/Toy/GetAll");
            var response = await result.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<Response<List<ToyDto>>>(response);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.True(responseObject != null && responseObject.IsSuccess);
        }

        /// <summary>
        /// Test to get a toy by id from the API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetByIdTest()
        {
            using var client = _factory.CreateClient();

            PreloadData();
            var result = await client.GetAsync("/api/Toy/GetById/1");
            var response = await result.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<Response<ToyDto>>(response);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.True(responseObject != null && responseObject.IsSuccess);
        }

        /// <summary>
        /// Test to create a toy using the API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateTest()
        {
            using var client = _factory.CreateClient();

            var result = await client.PostAsJsonAsync("/api/Toy/Create", new ToyDto
            {
                Name = "Test Toy",
                Description = "This is a test toy",
                AgeRestriction = 9,
                Price = 19.99,
                Company = "Test Company"
            });
            var response = await result.Content.ReadAsStringAsync();
            var resultObject = JsonConvert.DeserializeObject<Response<bool>>(response);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.True(resultObject != null && resultObject.IsSuccess);
            Assert.Equal("Toy inserted successfully", resultObject.Message);
        }

        /// <summary>
        /// Test to update a toy using the API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateTest()
        {
            using var client = _factory.CreateClient();

            PreloadData();
            var result = await client.PutAsJsonAsync("/api/Toy/Update", new ToyDto
            {
                Id = 1,
                Name = "Test Toy - Test 2",
                Description = "This is a test toy - Test 2",
                AgeRestriction = 9,
                Price = 19.99,
                Company = "Test Company"
            });
            var response = await result.Content.ReadAsStringAsync();
            var resultObject = JsonConvert.DeserializeObject<Response<bool>>(response);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.True(resultObject != null && resultObject.IsSuccess);
            Assert.Equal("Toy updated successfully", resultObject.Message);
        }

        /// <summary>
        /// Test to delete a toy using the API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteTest()
        {
            using var client = _factory.CreateClient();

            PreloadData();
            var result = await client.DeleteAsync("/api/Toy/Delete/1");
            var response = await result.Content.ReadAsStringAsync();
            var resultObject = JsonConvert.DeserializeObject<Response<bool>>(response);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.True(resultObject != null && resultObject.IsSuccess);
            Assert.Equal("Toy deleted successfully", resultObject.Message);
        }

        /// <summary>
        /// Executes CreateTest to ensure there is at least one record in the database
        /// </summary>
        private void PreloadData()
        {
            this.CreateTest().GetAwaiter().GetResult();
        }
    }
}
