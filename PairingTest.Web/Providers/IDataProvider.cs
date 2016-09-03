using System.Collections.Generic;
using System.Threading.Tasks;

namespace PairingTest.Web.Providers
{
    public interface IDataProvider
    {
        Task<string> Get();

        Task<int> MarkAnswers(IEnumerable<string> answers);
        
    }
}