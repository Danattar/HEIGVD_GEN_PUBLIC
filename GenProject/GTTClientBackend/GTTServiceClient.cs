using GTTServiceContract;
using JKang.IpcServiceFramework;
using System;

namespace GTTClientBackend
{
    public class GTTServiceClient
    {
        public async System.Threading.Tasks.Task<string> TestConnectionAsync(int v)
        {

            IpcServiceClient<IGTTService> client = new IpcServiceClientBuilder<IGTTService>()
                .UseNamedPipe("pipeName")
                .Build();
            string result = await client.InvokeAsync(x => x.TestConnection(v));
            return result;
        }
    }
}
