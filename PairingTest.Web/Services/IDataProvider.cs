using System.Threading.Tasks;

namespace PairingTest.Web.Services
{
    public interface IDataProvider
    {
        Task<string> Get();
    }
}