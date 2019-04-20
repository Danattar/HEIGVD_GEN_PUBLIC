using GTTServiceContract;
using JKang.IpcServiceFramework;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GTTServerBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = ConfigureServices(new ServiceCollection());

        }

        private static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            return services.AddIpc(builder =>
                {
                    builder.AddNamedPipe
                    (
                        options => { options.ThreadCount = 2; }
                    ).AddService<IGTTService, GTTService>();
                });
        }
    }
}
