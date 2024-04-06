using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Server.Examples
{
    public sealed class IPInfoServerHandler : ServerHandler
    {
        public async UniTask<string> GetIP()
        {
            var response = await SendRequest<IPResponse>("https://api.ipify.org?format=json", null);

            return response.ip;
        }
        
        private sealed class IPResponse
        {
            public string ip;
        }
    }
}