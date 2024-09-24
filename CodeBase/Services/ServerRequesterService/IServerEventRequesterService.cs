using CodeBase.Services.EventService;
using Cysharp.Threading.Tasks;

namespace CodeBase.Services.ServerRequesterService
{
    public interface IServerEventRequesterService
    {
        public UniTask<bool> Request(Event post);
    }
}