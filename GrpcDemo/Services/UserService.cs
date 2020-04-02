using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcDemo
{
    public class UserService : PUserService.PUserServiceBase
    {

        private static readonly List<string> Users = new List<string>() { "张三", "李四" };
        private static readonly Random Rand = new Random(DateTime.Now.Millisecond);

        public override Task<User> Get(Int32Value a, ServerCallContext context)
        {
            a.Value = 1;
            return Task.FromResult(new User()
            {
                City = $"用户的姓名是{Users[Rand.Next(0, Users.Count)]}",
                Age = 17
            });
        }

        //public override async Task GetList(UserQuery userQuery, ServerCallContext context)
        //{
        //    var res = new Response();
        //    IEnumerable<User> users = new List<User>();
        //    var a = Any.Pack(new User() { Age = 11, Mobile = "13564368651" });
        //    res.Results.Add(a);
        //    res.Code = 1;
        //    res.Message = "OK";
        //    //Google.Protobuf.WellKnownTypes.Int32Value.ExtensionSet.S

        //    //await responseStream.WriteAsync(new User() { Age =11 });


        //    //return Task.FromResult(new User()
        //    //{
        //    //    City = $"用户的姓名是{Users[Rand.Next(0, Users.Count)]}",
        //    //    Age = 17
        //    //});
        //}
    }
}
