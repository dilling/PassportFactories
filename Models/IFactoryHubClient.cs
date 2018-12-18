using System.Threading.Tasks;

namespace PassportCodeChallenge.Models
{
    public interface IFactoryHubClient
    {
         Task BroadcastMessage(string type, Factory payload);
    }
}