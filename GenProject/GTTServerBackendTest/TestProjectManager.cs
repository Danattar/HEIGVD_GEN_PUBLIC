using GTTServerBackend;
using GTTServiceContract.ProjectImplementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTTServerBackendTest
{
    [TestClass]
    public class TestProjectManager
    {
        private ProjectManager _pm;
        [TestInitialize]
        public void setUp()
        {
            _pm = new ProjectManager();

        }
        [TestMethod]
        public void TestCreateNewProject()
        {
            Project p = _pm.GetProject("GEN");
            Assert.AreEqual(p.ProjectName, "School-GEN");
        }

        [TestMethod]
        public void LinkTaskToProject()
        {
            bool result = _pm.LinkTaskToProject("100", "GEN");
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void LinkRoomToProject()
        {
            bool result = _pm.LinkRoomToProject("GEN", "GEN");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CreateProject()
        {
            Project result = _pm.AddProject("SBC", "SBC Default Project");
            Assert.AreEqual("SBC", result.ID);
        }

        [TestCleanup]
        public void tearDown()
        {
        }
    }
}
