using Common.Models;
using Common.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.Interfaces
{
    public interface INewsService
    {
       Task<List<NewsModel>> GetNewsAsync(BasicPageFilter filter);
    }
}
