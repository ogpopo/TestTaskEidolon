using UnityEngine;

namespace CodeBase.Services.ServerRequesterService
{
    [CreateAssetMenu(fileName = "ServerConfig")]
    public class ServerConfig : ScriptableObject
    {
        [field: SerializeField] public string ServerURL { get; private set; }
    }
}