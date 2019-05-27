using System.Net;
using GTTServerBackend;
using GTTServiceContract.ProjectImplementation;
using GTTServiceContract.Room;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTTServerBackendTest
{
    [TestClass]
    public class TestProjectManager
    {
        [TestInitialize]
        public void setUp()
        {
    
        }
       [TestMethod]
        public void TestCreateNewProject()
        {
            ProjectManager pm = new ProjectManager();
            Project p = pm.GetProject("GEN");
            Assert.AreEqual(p.ProjectName, "School-GEN");
        }
        [TestCleanup]
        public void tearDown()
        {
        }
     }
}
