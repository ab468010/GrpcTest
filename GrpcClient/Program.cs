using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcDemo;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GrpcClients
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var client2 = new PUserService.PUserServiceClient(channel);
            var reply =  client2.GetList(new UserQuery() { });
            foreach (var re in reply.Results)
            {
                Console.WriteLine("Greeter 服务返回数据: " + JsonConvert.SerializeObject(re));

                Console.WriteLine("Greeter 服务UnPack返回数据: " + JsonConvert.SerializeObject(re.Unpack<User>()));
            }


           // Console.WriteLine("Greeter 服务返回数据: " + JsonConvert.SerializeObject(reply.Results));
            Console.ReadKey();
        }
    }
}
