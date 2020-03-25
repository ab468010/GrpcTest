using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcDemo
{
    public class UserService : User.UserBase
    {

        private static readonly List<string> Users = new List<string>() { "张三", "李四" };
        private static readonly Random Rand = new Random(DateTime.Now.Millisecond);

        public override Task<UserResult> ShowUserName(Empty request,ServerCallContext context)
        {
            return Task.FromResult(new UserResult()
            {
                Name = $"用户的姓名是{Users[Rand.Next(0, Users.Count)]}",
                Age = 17
            });
        }
    }
}
