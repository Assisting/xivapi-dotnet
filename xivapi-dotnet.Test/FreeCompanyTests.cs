using Microsoft.VisualStudio.TestTools.UnitTesting;
using xivapi;

namespace xivapi_dotnet.Test
{
    [TestClass]
    public class FreeCompanyTests
    {
        private XIVAPI? api;

        [TestInitialize]
        public void TestInit()
        {
            api = new XIVAPI("https://xivapi.com");
        }

        [TestMethod]
        public void TestSearchSuccess()
        {
            // arrange
            string fcSearchText = "Halcyon Wanderers";

            // act
            var result = api!.SearchFreeCompany(fcSearchText, ServerName.Leviathan).Result;

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Results.Count > 0);
            Assert.AreEqual(result.Results.Count, result.Pagination.ResultsTotal);
            Assert.AreEqual(result.Results[0].Name, fcSearchText);
        }

        [TestMethod]
        public void TestSearchManyResult()
        {
            // arrange
            string fcSearchText = "Wander";

            // act
            var result = api!.SearchFreeCompany(fcSearchText).Result;

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Results.Count > 0);
            Assert.IsTrue(result.Results.Count < result.Pagination.ResultsTotal);
        }

        [TestMethod]
        public void TestSearchNoResults()
        {
            // arrange
            string fcSearchText = "Super Specific FC Name";

            // act
            var result = api!.SearchFreeCompany(fcSearchText, ServerName.Hyperion).Result;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Results.Count, 0);
        }

        [TestMethod]
        public void TestGetFC()
        {
            // arrange
            string fcID = "9232379236109620308";

            // act
            var result = api!.GetFreeCompany(fcID).Result;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.FreeCompany.Name, "Halcyon Wanderers");
            Assert.IsNull(result.FreeCompanyMembers);
        }

        [TestMethod]
        public void TestGetFCWithMembers()
        {
            // arrange
            string fcID = "9232379236109620308";

            // act
            var result = api!.GetFreeCompany(fcID, includeMembers: true).Result;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.FreeCompany.Name, "Halcyon Wanderers");
            Assert.IsNotNull(result.FreeCompanyMembers);
            Assert.IsTrue(result.FreeCompanyMembers!.Count > 0);
        }
    }
}