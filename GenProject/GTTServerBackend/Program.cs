﻿using GTTServiceContract.Room;
using GTTServiceContract.Task;
using JKang.IpcServiceFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;

namespace GTTServerBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = ConfigureServices(new ServiceCollection());

            //            System.Net.IPAddress serverIP = IPAddress.Parse("192.168.0.248");
            System.Net.IPAddress serverIP = IPAddress.Loopback;
            new IpcServiceHostBuilder(services.BuildServiceProvider())
                .AddNamedPipeEndpoint<IRoomManager>(name: "endpoint1", pipeName: "pipeName")
                .AddNamedPipeEndpoint<ITaskManager>(name: "endpoint3", pipeName: "pipeName2")
                .AddTcpEndpoint<IRoomManager>(name: "endpoint2", ipEndpoint: serverIP, port: 45684)
                .AddTcpEndpoint<ITaskManager>(name: "endpoint4", ipEndpoint: serverIP, port: 45684)
                .Build()
                .Run();

        }

        private static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            return services.AddIpc(builder =>
                {
                    builder.AddNamedPipe
                    (
                        options => { options.ThreadCount = 2; }
                    ).AddService<IRoomManager, RoomManager>();
                }).AddIpc(builder => {
                    builder.AddNamedPipe
                    (
                        options => { options.ThreadCount = 2; }
                    ).AddService<ITaskManager, TaskManager>();
                });
        }
    }
}
