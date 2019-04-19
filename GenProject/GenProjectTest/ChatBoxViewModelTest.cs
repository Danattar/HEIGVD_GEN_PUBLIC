using System;
using GenProjectClientInterface.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenProjectTest
{
    [TestClass]
    public class ChatBoxViewModelTest
    {
       // private GenProjectClientInterface.Service _service;

        [TestInitialize]
        public void setUp()
        {
  //          _service = new GenProjectClientInterface.Service();
        }
        [TestCleanup]
        public void tearDown()
        {

        }

        [TestMethod]
        public void SendMessage__MessageListHas1MoreItem__OK()
        {
        //    ChatBoxViewModel a = new ChatBoxViewModel("A", 2, _service);
        //    ChatBoxViewModel b = new ChatBoxViewModel("B", 2, _service);
      /*      _service.MessageSent += a.MessageListenerHandler;
            _service.MessageSent += b.MessageListenerHandler;
             a.MessageBox = "Test Message";
            a.SendMessage();
            Assert.AreEqual(1, b.MessageList.Count);*/
        }
    }
}
