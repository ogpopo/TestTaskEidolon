using System.Text;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Event = CodeBase.Services.EventService.Event;

namespace CodeBase.Services.ServerRequesterService
{
    public class ServerRequesterService : IServerEventRequesterService
    {
        private readonly ServerConfig _serverConfig;

        public ServerRequesterService(ServerConfig serverConfig)
        {
            _serverConfig = serverConfig;
        }

        public async UniTask<bool> Request(Event post)
        {
            var formData = new WWWForm();
            string json = JsonUtility.ToJson(post);
            
            UnityWebRequest request = UnityWebRequest.Post(_serverConfig.ServerURL, formData);
            
            byte[] postBytes = Encoding.UTF8.GetBytes(json);
            
            UploadHandler uploadHandler = new UploadHandlerRaw(postBytes);
            request.uploadHandler = uploadHandler;
            
            await request.SendWebRequest();

            if (request.responseCode == 200)
            {
                return true;
            }

            return false;
        }
    }
}