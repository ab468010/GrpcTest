using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcDemo;
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

            var client2 = new User.UserClient(channel);
            var reply = await client2.ShowUserNameAsync(new Empty());



            Console.WriteLine("Greeter 服务返回数据: " + reply.Name);
            Console.ReadKey();
        }
    }
}
