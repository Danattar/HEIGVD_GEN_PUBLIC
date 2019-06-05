using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using GTTClientBackend.Models;
using GTTServiceContract.Room;
using GTTServiceContract.RoomImplementation;
using JKang.IpcServiceFramework;

namespace GTTClientBackend.Services
{
    public class ChatBoxService
    {
        private readonly List<ChatBox> _chatBoxList = new List<ChatBox>();
        private IpcServiceClient<IRoomManager> _client;
        private Guid _clientGuid;

        public ChatBoxService()
        {
            _clientGuid = Guid.NewGuid();
            ConnectToServer();
            ExposeClient();
            //            _chatboxManager = chatboxManager;
            //            _client.InvokeAsync(x => x.MessageAdded += AddMessage);
        }


        private void ConnectToServer()
        {
            _client = new IpcServiceClientBuilder<IRoomManager>()
                .UseNamedPipe("pipeName")
                .Build();

            /*            System.Net.IPAddress serverIP = IPAddress.Parse("192.168.0.248");
                        _client = new IpcServiceClientBuilder<IRoomManager>()
                            .UseTcp(serverIP, 45684)
                            .Build();
             */           //            192.168.0.248
        }

        public void AddMessage(string roomID, string author, string message)
        {
            //            _chatboxManager.AddRoomMessage(roomID, author, message);
            _client.InvokeAsync(x => x.AddRoomMessage(roomID, author, message));
        }
        /*        public async Task<ChatBox> GetChatBoxAsync(string roomID)
                {
                    IRoom room = await _client.InvokeAsync(x => x.GetRoom(roomID));
                    //            IRoom room = (IRoom)_chatboxManager.GetRoom(roomID);
                    ChatBox chatBox = AddChatBox(room);
                    room.RoomMessageList.ForEach(x => chatBox.RoomMessageList.Add(CreateChatBoxMessage(x.Author, x.Message)));
                    return chatBox;
                }
        */
        public async Task<ChatBox> GetNewChatBoxAsync()
        {
            IRoom room;
            try
            {
                room = await _client.InvokeAsync(x => x.AddRoom(_clientGuid));
            }
            catch (Exception e)
            {
                throw new Exception("An error occured while retrieving a new Room", e);
            }

            return AddChatBox(room);

            // return new ChatBox(10);
            // return AddChatBox(_chatboxManager.AddRoom());
        }

        public async Task<ChatBox> GetNewChatBoxAsync(string roomId)
        {
            IRoom room;
            try
            {
                room = await _client.InvokeAsync(x => x.GetRoom(roomId, _clientGuid));
            }
            catch (Exception e)
            {
                throw new Exception("An error occured while retrieving an existing Room", e);
            }

            return AddChatBox(room);
        }


        private async void AddMessage(string roomID, IRoomMessage roomMessage)
        {
            List<ChatBox> chatBoxLinkedToRoomList = _chatBoxList.Where(x => x.RoomID == roomID).ToList();
            var addedChatBoxMessageList = new List<ChatBoxMessage>();
            ChatBoxMessage chatBoxMessage;
            chatBoxLinkedToRoomList.ForEach(y =>
            {
                chatBoxMessage = CreateChatBoxMessage(roomMessage.Author, roomMessage.Message);
                y.RoomMessageList.Add(chatBoxMessage);
                MessageAdded?.Invoke(y, chatBoxMessage);
            });
        }

        private ChatBox AddChatBox(IRoom room)
        {
            ChatBox chatBox = CreateChatbox(room);
            _chatBoxList.Add(chatBox);
            return chatBox;
        }

        public event Action<ChatBox, ChatBoxMessage> MessageAdded;

        #region Factory

        private ChatBox CreateChatbox(IRoom room)
        {
            return new ChatBox(room.ID);
        }
        private ChatBoxMessage CreateChatBoxMessage(string author, string message)
        {
            return new ChatBoxMessage(author, message);
        }

        #endregion

        #region ClientService
        private BackgroundWorker _clientService;

        private void ExposeClient()
        {
            _clientService = new BackgroundWorker();
            _clientService.DoWork += StartServiceAsync;
            _clientService.RunWorkerCompleted += StopService;
            _clientService.WorkerSupportsCancellation = true;
            _clientService.RunWorkerAsync();
        }
        private async void StartServiceAsync(object sender, DoWorkEventArgs e)
        {
            while (!_clientService.CancellationPending)
            {
                //                System.Diagnostics.Trace.WriteLine("service running");
                Dictionary<string, List<RoomMessage>> newMessages= await _client.InvokeAsync(x => x.GetQueuedMessages(_clientGuid));
                if(newMessages != null) UpdateMessages(newMessages);
                Thread.Sleep(10000);
            }
        }

        private void UpdateMessages(Dictionary<string, List<RoomMessage>> newMessages)
        {
            foreach (string roomID in newMessages.Keys)
            {
                foreach (RoomMessage roomMessage in newMessages[roomID])
                {
                    AddMessage(roomID, roomMessage);
                }
            }
        }

        private void StopService(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Client Service Stopped");
        }


        #endregion

        public bool CancelWorkers()
        {
            _clientService.CancelAsync();
            return true;
        }

    }
}
