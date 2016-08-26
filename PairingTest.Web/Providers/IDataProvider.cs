using System.Threading.Tasks;

namespace PairingTest.Web.Providers
{
    public interface IDataProvider
    {
        Task<string> Get();
    }
}