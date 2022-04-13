using Microsoft.VisualStudio.TestTools.UnitTesting;
using xivapi;

namespace xivapi_dotnet.Test
{
    [TestClass]
    public class CharacterTests
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
            string charSearchText = "Zora Memai";

            // act
            var result = api!.SearchCharacter(charSearchText, ServerName.Leviathan).Result;

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Results.Count > 0);
            Assert.AreEqual(result.Results.Count, result.Pagination.ResultsTotal);
            Assert.AreEqual(result.Results[0].Name, charSearchText);
        }

        [TestMethod]
        public void TestSearchByDataCenter()
        {
            // arrange
            string charSearchText = "Apollo Bastet";

            // act
            var result = api!.SearchCharacter(charSearchText, DataCentre.Primal).Result;

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Results.Count > 1);
            Assert.AreEqual(result.Results.Count, result.Pagination.ResultsTotal);
            Assert.AreEqual(result.Results[0].Name, charSearchText);
        }

        [TestMethod]
        public void TestRetrieveById()
        {
            // arrange
            int charID = 21348753;

            // act
            var result = api!.GetCharacter(charID).Result;

            // assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Character);
            Assert.AreEqual(result.Character.ID, charID);
            Assert.AreEqual(result.Character.Name, "Kyouy'a Shibari");
        }
    }
}