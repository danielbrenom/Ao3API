using System.Collections.Generic;
using System.Threading.Tasks;
using Ao3Domain.Models.Data;
using Ao3Domain.Models.Request;

namespace Ao3Api.Interfaces
{
    public interface IWorksService
    {
        Task<List<Work>> Works();
        Task<WorkIndexing> Work(int workId);
        Task<List<Work>> Search(SearchRequest request);
        Task<WorkChapter> WorkChapter(int workId, int workChapter);
    }
}