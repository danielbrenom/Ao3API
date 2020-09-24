using System.Collections.Generic;
using System.Threading.Tasks;
using Ao3Api.Models;
using Ao3Api.Models.Request;

namespace Ao3Api.Interfaces
{
    public interface IWorksService
    {
        public Task<List<Work>> Works();
        public Task<List<Work>> Search(SearchRequest request);
    }
}