using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcDemo
{
    public class ProductService:PProductService.PProductServiceBase
    {
        public override Task<Product> GetList(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new Product()
            {
                Name = "",
                Price = 1.0
            }) ;
        }
    }
}
